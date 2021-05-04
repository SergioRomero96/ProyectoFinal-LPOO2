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
using ClasesBases;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;
using System.Data;

namespace Vistas.CRUD.Services
{
    /// <summary>
    /// Interaction logic for AltaServicio.xaml
    /// </summary>
    public partial class AltaServicio : Window
    {
        private IUnitOfWork _unitOfWorK;
        private DateTime _hoy;
        public Servicio _servicio;
        public static AltaServicio _instancia;
        private GestionServicio _ucGestionServicio;
        private bool _update = false;
  
        private ServicioService _servicioService;
        private Response _response;

        public static AltaServicio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new AltaServicio();
            return _instancia;
        }

        public AltaServicio()
        {
            InitializeComponent();
            _hoy = DateTime.Now;
            _unitOfWorK = new UnitOfWork();
            _servicio = new Servicio();
            _servicioService = new ServicioService();
            dpFecha.DisplayDateStart = _hoy;
            disabledRadioButton();
           
        }

        private void disabledRadioButton()
        {
            if (_update)
            {
                cancelado.IsEnabled = true;
            }
            else {
                cancelado.IsEnabled = false;
                activo.IsChecked = true;
            }
        }

        private void cmbCiudadOrigen_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCiudadOrigen.ItemsSource = _unitOfWorK.Terminales.GetAll().DefaultView;
            cmbCiudadOrigen.DisplayMemberPath = "CIU_Nombre";
            cmbCiudadOrigen.SelectedValuePath = "TER_Id";
            cmbCiudadOrigen.SelectedIndex = 0;
            if (_update)
                cmbCiudadOrigen.SelectedValue = _servicio.Ter_Codigo_Origen;
        }

        private void cmbCiudadDestino_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCiudadDestino.ItemsSource = _unitOfWorK.Terminales.GetAll().DefaultView;

            cmbCiudadDestino.DisplayMemberPath = "CIU_Nombre ";
            cmbCiudadDestino.SelectedValuePath = "TER_Id";
            cmbCiudadDestino.SelectedIndex = 0;

            if (_update)
                cmbCiudadDestino.SelectedValue = _servicio.Ter_Codigo_Destino;
        }

        private void AgregarServicio(bool semanal)
        {
            _response = _servicioService.Add(_servicio,semanal);
         
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Alta Terminal", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGrid();
            }
            else {
                MessageBox.Show(_response.Msg, "Alta Terminal", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          }

        private void LoadDataGrid()
        {
            _ucGestionServicio = GestionServicio.GetInstance();
            _ucGestionServicio.CargarServicios();
            this.Close();
        }

        private bool ValidarCamposVaciosServicio()
        {
            return dpFecha.Text != "" && cmbAutobus.Text != "" && cmbCiudadOrigen.Text != "" && cmbCiudadDestino.Text != "";
        }

        private string obtenerEstado()
        {
            string estado = null;
            if (activo.IsChecked == true)
                estado = "ACTIVO";
            else
            {
                if (cancelado.IsChecked == true)
                    estado = "CANCELADO";
            }
            return estado;
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposVaciosServicio())
            {
                CargarDatos();
                if (!_update)
                    DecidirSemanal();
                else
                    ActualizarServicio();
                DataContext = _servicio;
            }
            else
                MessageBox.Show("Algunos campos estan vacíos", "Servicio", MessageBoxButton.OK, MessageBoxImage.Error);  
        }

        private void DecidirSemanal()
        {
            MessageBoxResult opcion = MessageBox.Show("¿Desea Guardar viajes para una semana? si preciona NO, guardara un solo registro", "Guardar", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                AgregarServicio(true);
            }
            if (opcion == MessageBoxResult.No)
            {
                AgregarServicio(false);
            }
        }

        private void ActualizarServicio()
        {
            _response=_servicioService.Update(_servicio);
            if (_response.Status) {
                MessageBox.Show(_response.Msg, "Modificar Servicio", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataGrid();
            }
            else {
               MessageBox.Show(_response.Msg, "Modificar Servicio", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CargarDatos()
        {
            //txtEstado.Text = "ACTIVO";
            if (dpFecha.Text != "")
                _servicio.Ser_FechaHora = (DateTime)dpFecha.SelectedDate;

            _servicio.Aut_Codigo = Convert.ToInt32(cmbAutobus.SelectedValue.ToString());
            _servicio.Ter_Codigo_Origen = Convert.ToInt32(cmbCiudadOrigen.SelectedValue.ToString());
            _servicio.Ter_Codigo_Destino = Convert.ToInt32(cmbCiudadDestino.SelectedValue.ToString());
            _servicio.Ser_Estado = obtenerEstado();

        }
       
       

        public void SetServicio(Servicio servicio, bool update)
        {
            _update = update;
            DataContext = servicio;
            _servicio = servicio;
            _servicio.Ser_Codigo = servicio.Ser_Codigo;
            dpFecha.SelectedDate = servicio.Ser_FechaHora;
            seleccionarEstado(servicio);
            disabledRadioButton();
           // servicio.Ser_Estado = Convert.ChangeType(activo.IsChecked);
        }

        private void seleccionarEstado(Servicio servicio)
        {
            if (servicio.Ser_Estado.Equals("ACTIVO"))
               activo.IsChecked = true;
            else
              cancelado.IsChecked = true;
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ValidarCamposVacios()
        {
            return dpFecha.Text != "" ;
        }

        private void cmbEmpresas_Loaded(object sender, RoutedEventArgs e)
        {
            cmbEmpresas.ItemsSource = _unitOfWorK.Empresas.GetAll().DefaultView;
            cmbEmpresas.DisplayMemberPath = "EMP_Nombre";
            cmbEmpresas.SelectedValuePath = "EMP_Codigo";
            cmbEmpresas.SelectedIndex = 0;
            if (_update)
                cmbEmpresas.SelectedValue = _servicio.Autobus.Empresa.Codigo;
        }

        private void cargarAutobus(DataTable result)
        {

            cmbAutobus.ItemsSource = result.DefaultView;
            cmbAutobus.DisplayMemberPath = "AUT_Codigo";
            cmbAutobus.SelectedValuePath = "AUT_Id";
            cmbAutobus.SelectedIndex = 0;

        }

        private void cmbEmpresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable result = new DataTable();
            if (_update)
            {
                result = _unitOfWorK.Autobus.FindByEmpresas(Convert.ToInt32(_servicio.Autobus.Empresa.Codigo));

            }
            else
            {
                result = _unitOfWorK.Autobus.FindByEmpresas(Convert.ToInt32(cmbEmpresas.SelectedValue.ToString()));
            }
            if (result.Rows.Count != 0)
            {

                cargarAutobus(result);


            }
            else
            {
                MessageBox.Show("Esta empresa no posee coches registrados", "Empresa", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbEmpresas.SelectedIndex = 0;
            }
           

        }

    }
}
