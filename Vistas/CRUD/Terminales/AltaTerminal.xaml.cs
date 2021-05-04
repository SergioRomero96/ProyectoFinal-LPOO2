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
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;

namespace Vistas.CRUD.Terminales
{
    /// <summary>
    /// Lógica de interacción para AltaTerminal.xaml
    /// </summary>
    public partial class AltaTerminal : Window
    {
        private IUnitOfWork _unitOfWorK;
        private Terminal _terminal;
        private Terminal _terminalAuxiliar;
        private bool _update = false;
        public static AltaTerminal _instancia;
        private GestionTerminal _ucGestionTerminal;
        private int _id, _codigoCiudad;

        public static AltaTerminal GetInstancia()
        {
            if (_instancia == null)
                _instancia = new AltaTerminal();
            return _instancia;
        }

        public AltaTerminal()
        {
            InitializeComponent();
            _unitOfWorK = new UnitOfWork();
            _terminal = new Terminal();
            DataContext = _terminal;
        }

        private void cmbCiudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbCiudad_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCiudad.ItemsSource = _unitOfWorK.Ciudades.GetAll().DefaultView;

            cmbCiudad.DisplayMemberPath = "CIU_Nombre";
            cmbCiudad.SelectedValuePath = "CIU_Id";
            cmbCiudad.SelectedIndex = 0;

            if (_update)
                cmbCiudad.SelectedValue = _codigoCiudad;
        }

        private void AgregarTerminal()
        {
            _unitOfWorK.Terminales.Add(_terminal);
            MessageBox.Show("Terminal registrado con exito", "Alta Terminal", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ActualizarTerminal()
        {
            _terminal.Ter_Id = _id;
            _terminal.Ter_Codigo = Convert.ToInt32(txtCodigoTerminal.Text);
            _terminal.Ter_Nombre = txtNombreTerminal.Text.ToUpper();
            _terminal.Ciu_Codigo = Convert.ToInt32(cmbCiudad.SelectedValue.ToString());
            _unitOfWorK.Terminales.Update(_terminal);
            MessageBox.Show("Terminal actualizado con exito", "Modificar Terminal", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ObtenerInstancia()
        {
            _ucGestionTerminal = GestionTerminal.GetInstancia();
            _ucGestionTerminal.CargarTerminales();
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposVacios())
            {
                CargarDatos();
                if (!_update)
                {
                    if (ValidarCodigoTerminal() && _terminal.Ter_Codigo > 0)
                    {
                        AgregarTerminal();
                        ObtenerInstancia();
                    }
                    else
                        MessageBox.Show("Ya existe codigo de terminal", "Agregar Ciudad", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (TieneCambio())
                    {
                        ValidarActualizar();
                    }
                    else
                    {
                        MostrarMensajeInformacion("Terminal actualizada con exito", "Modificar Terminal");
                        ObtenerInstancia();
                    }
                }
            }
            else
                MessageBox.Show("Algunos campos estan vacios!!", "Terminal", MessageBoxButton.OK, MessageBoxImage.Error);
            //MessageBox.Show(cmbCiudad.SelectedValue.ToString());
        }

        private void ValidarActualizar()
        {
            if (EsIgualCodigo())
            {
                ActualizarTerminal();
                ObtenerInstancia();
            }
            else
            {
                if (ObtenerValidacionCodigo())
                {
                    ActualizarTerminal();
                    ObtenerInstancia();
                }
                else
                    MostrarMensajeError("Ya existe codigo de terminal", "Modificar Terminal");
            }
        }

        private bool TieneCambio()
        {
            return _terminalAuxiliar.Ter_Nombre != _terminal.Ter_Nombre.ToUpper() || _terminalAuxiliar.Ciu_Codigo != _terminal.Ciu_Codigo || _terminalAuxiliar.Ter_Codigo != _terminal.Ter_Codigo;
        }

        private bool EsIgualCodigo()
        {
            return _terminal.Ter_Codigo == _terminalAuxiliar.Ter_Codigo;
        }

        private bool ObtenerValidacionCodigo()
        {
            return ValidarCodigoTerminal() && EsDistintoCodigo();
        }

        private bool EsDistintoCodigo()
        {
            return _terminal.Ter_Codigo != _terminalAuxiliar.Ter_Codigo;
        }

        private bool ValidarCamposVacios()
        {
            return txtCodigoTerminal.Text != "" && cmbCiudad.Text != "" && txtNombreTerminal.Text != "";
        }

        private bool ValidarCodigoTerminal()
        {
            return _unitOfWorK.Terminales.ValidarCodigoTerminal(_terminal.Ter_Codigo).Rows.Count == 0;
        }

        private void CargarDatos()
        {
            _terminal.Ter_Codigo = Convert.ToInt32(txtCodigoTerminal.Text);
            _terminal.Ciu_Codigo = Convert.ToInt32(cmbCiudad.SelectedValue.ToString());
            _terminal.Ter_Nombre = txtNombreTerminal.Text.ToUpper();
        }

        public void SetTerminal(Terminal terminal, int codigoCiudad, bool update)
        {
            _terminalAuxiliar = new Terminal(terminal.Ter_Codigo, terminal.Ciu_Codigo, terminal.Ter_Nombre);
            Title = "Editar Terminal";
            _update = update;
            DataContext = terminal;
            /*txtCodigoTerminal.Text = terminal.Ter_Codigo.ToString();
            txtNombreTerminal.Text = terminal.Ter_Nombre.ToString();*/
            this._codigoCiudad = codigoCiudad;
            _id = terminal.Ter_Id;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }

        private void txtCodigoTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
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
