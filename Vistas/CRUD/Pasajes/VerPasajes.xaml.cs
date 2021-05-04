using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Data;
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;
using ClasesBases;

namespace Vistas.CRUD.Pasajes
{
    /// <summary>
    /// Lógica de interacción para VerPasajes.xaml
    /// </summary>
    public partial class VerPasajes : Window
    {
        private IUnitOfWork _unitOfWork;
        private PasajeSevice _pasajeService;
        private Response _response;
        private Pasaje _pasaje;
        public static VerPasajes _instancia;
        private bool _seleccion = false;
        private PrintPasajes _print;
        private int _cantidadPasajes = 0;
        private decimal _precioPasajes = 0;

        public VerPasajes()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _pasajeService = new PasajeSevice();
            _pasaje = new Pasaje();
        }

        public static VerPasajes GetInstancia()
        {
            if (_instancia == null)
                _instancia = new VerPasajes();
            return _instancia;
        }

        public void LoadPasajes()
        {
            dgPasajes.ItemsSource = _unitOfWork.Pasajes.GetAll().DefaultView;
            dgPasajes.UpdateLayout();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPasajes();
            txtMontoTotal.Text = _cantidadPasajes.ToString();
            txtPasajesVendidos.Text = _precioPasajes.ToString();
        }

        private void rbEmpresa_Checked(object sender, RoutedEventArgs e)
        {
            _seleccion = true;
            LoadPasajes();
            CargarEmpresas();
            LimpiarFecha();
        }

        private void rbDNI_Checked(object sender, RoutedEventArgs e)
        {
            _seleccion = true;
            LoadPasajes();
            LimpiarFecha();
        }

        private void rbTipoServicio_Checked(object sender, RoutedEventArgs e)
        {
            _seleccion = true;
            LoadPasajes();
            LimpiarFecha();
        }

        private void rbFechaHora_Checked(object sender, RoutedEventArgs e)
        {
            _seleccion = true;
        }

        private void rbDefecto_Checked(object sender, RoutedEventArgs e)
        {
            if (_seleccion)
            {
                LoadPasajes();
                LimpiarFecha();
            }
        }

        private void txtDni_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDni.Text.Length == 0)
                LoadPasajes();
            else
            {
                DataTable results;
                if (txtDni.Text.Length > 8)
                    LoadPasajes();
                else
                {
                    results = _unitOfWork.Pasajes.ObtenerPasajeDniCliente(Convert.ToInt32(txtDni.Text));
                    if (results.Rows.Count > 0)
                        dgPasajes.ItemsSource = results.DefaultView;
                }
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            DataTable results;
            results = _unitOfWork.Pasajes.ObtenerPasajeNombreEmpresa(cmbEmpresa.Text);
            if (results.Rows.Count > 0)
                dgPasajes.ItemsSource = results.DefaultView;
            else
            {
                MostrarMensajeInformacion("No hay venta de pasajes para la empresa seleccionada", "Busqueda de Pasajes");
                LoadPasajes();
            }
        }

        private void CargarEmpresas()
        {
            cmbEmpresa.ItemsSource = _unitOfWork.Autobus.getEmpresas().DefaultView;
            cmbEmpresa.DisplayMemberPath = "EMP_Nombre";
            cmbEmpresa.SelectedValuePath = "EMP_Codigo";
            cmbEmpresa.SelectedIndex = 0;
        }

        private void txtMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataTable results;
            results = _unitOfWork.Pasajes.ObtenerPasajeTipoServicio(txtMatricula.Text);
            if (results.Rows.Count > 0)
                dgPasajes.ItemsSource = results.DefaultView;
            else
            {
                MostrarMensajeInformacion("No hay matricula de autobus de este tipo de servicio", "Busqueda de Pasajes");
                LoadPasajes();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = (DataRowView)dgPasajes.SelectedItem;
            if (rowSelected != null)
            {
                LoadPasaje(rowSelected);
                MessageBoxResult opcion = MessageBox.Show("¿Desea Cancelar?", "Cancelar Pasaje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                    deletePasaje();
            }
            else
                MostrarMensajeError("Ningún pasaje seleccionado", "Ver Pasajes");
         }

        private void deletePasaje()
        {
            _response = _pasajeService.Delete(_pasaje);
            if (_response.Status)
            {
                MostrarMensajeInformacion(_response.Msg, "Cancelar Pasaje");
                this.Close();
            }
            else
                MostrarMensajeError(_response.Msg, "Cancelar Pasaje");
        }

        private void LoadPasaje(DataRowView rowSelected)
        {
            _pasaje.Pas_Codigo = Convert.ToInt32(rowSelected["PAS_Codigo"]);
            _pasaje.Ser_Codigo = Convert.ToInt32(rowSelected["SER_Codigo"]);
            _pasaje.Pas_FechaHora = (DateTime)rowSelected["PAS_FechaHora"];
        }

        private void btnPreView_Click(object sender, RoutedEventArgs e)
        {
            _print = PrintPasajes.GetInstancia();
            _print.printFilter(dgPasajes.ItemsSource);

            _print.ShowDialog();
        }

        private void btnBuscarFechas_Click(object sender, RoutedEventArgs e)
        {
            if (dtpFechaInicial.Text.Length > 0 && dtpFechaFinal.Text.Length > 0)
            {
                if (Convert.ToDateTime(dtpFechaFinal.ToString()) > Convert.ToDateTime(dtpFechaInicial.ToString()))
                    ValidacionBusquedaEntreFechas();
                else
                    MostrarMensajeError("La fecha final debe ser mayor a la fecha menor", "Busqueda de Pasajes");
            }
            else
                MostrarMensajeError("Ingrese una fecha válida", "Busqueda de Pasajes");
        }

        private void ValidacionBusquedaEntreFechas()
        {
            DataTable results;
            results = _unitOfWork.Pasajes.ObtenerPasajeFechaServicio(Convert.ToDateTime(dtpFechaInicial.ToString().Substring(0, 10)), Convert.ToDateTime(dtpFechaFinal.ToString().Substring(0, 10)));
            if (results.Rows.Count > 0)
            {
                _cantidadPasajes = _unitOfWork.Pasajes.ObtenerCantidadPasajesVendidos(Convert.ToDateTime(dtpFechaInicial.ToString().Substring(0, 10)), Convert.ToDateTime(dtpFechaFinal.ToString().Substring(0, 10)));
                _precioPasajes = _unitOfWork.Pasajes.ObtenerTotalPrecio(Convert.ToDateTime(dtpFechaInicial.ToString().Substring(0, 10)), Convert.ToDateTime(dtpFechaFinal.ToString().Substring(0, 10)));
                dgPasajes.ItemsSource = results.DefaultView;
                txtPasajesVendidos.Text = _cantidadPasajes.ToString();
                txtMontoTotal.Text = _precioPasajes.ToString();
                txtHora.Text = _unitOfWork.Pasajes.HorarioDeMasVentas(Convert.ToDateTime(dtpFechaInicial.ToString().Substring(0, 10)), Convert.ToDateTime(dtpFechaFinal.ToString().Substring(0, 10))).ToString("dd/MM/yyyy HH:mm");
          
            }
            else
            {
                MostrarMensajeInformacion("No hay venta de pasajes para este rango de fechas", "Busqueda de Pasajes");
                txtPasajesVendidos.Text = 0.ToString();
                txtMontoTotal.Text = 0.ToString();
                LoadPasajes();
            }
        }

        private void LimpiarFecha()
        {
            txtPasajesVendidos.Text = "0".ToString();
            txtMontoTotal.Text = "0".ToString();
            dtpFechaInicial.Text = "".ToString();
            dtpFechaFinal.Text = "".ToString();
        }

        private void MostrarMensajeInformacion(String mensaje, String titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MostrarMensajeError(String mensaje, String titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

