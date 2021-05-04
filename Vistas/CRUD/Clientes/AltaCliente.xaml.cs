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
using System.ComponentModel;
using System.Data;
using ClasesBases;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Services.Implementation;

using ClasesBases.Commons;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para AltaCliente.xaml
    /// </summary>
    public partial class AltaCliente : Window
    {
        public Cliente _cliente;
        public static AltaCliente _instance;
        public bool _save = false;
        private bool _update = false;
        private IUnitOfWork _unitOfWork;
        private ClienteService _clienteService;
        private GestionCliente _ucGestionCliente;
        private Response _response;

        public static AltaCliente GetInstancia()
        {
            if (_instance == null)
                _instance = new AltaCliente();
            return _instance;
        }

        public AltaCliente()
        {
            InitializeComponent();
            _cliente = new Cliente();
            _unitOfWork = new UnitOfWork();
            _clienteService = new ClienteService();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            llenarCampos(); //llena el objeto para poder validarlo
            MessageBoxResult opcion = MessageBox.Show("¿Desea Guardar?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                if (!_update)
                    addClient();
                else
                    updateClient();
                DataContext = _cliente;
            }
        }

        private void finish() {
            _ucGestionCliente = GestionCliente.GetInstance();
            _ucGestionCliente.LoadClientes();
            this.Close();
        }
        
        private void llenarCampos() {
            if (txtDni.Text != "")
                _cliente.Dni = Convert.ToInt32(txtDni.Text);
            else 
                _cliente.Dni = 0;
            _cliente.Nombre = txtNombre.Text.ToUpper();
            _cliente.Apellido = txtApellido.Text.ToUpper();
            _cliente.Telefono = txtTelefono.Text;
            _cliente.Email = txtEmail.Text;
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else 
                e.Handled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instance = null;
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
       
      /**  private void txtTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BorderBrush = original;
        }**/

        private void txtNombre_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else 
                e.Handled = true;
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else 
                e.Handled = true;
        }

        private void addClient() {
            _save = true;
            /*_unitOfWork.Clientes.Add(_cliente);
            MessageBox.Show("Cliente registrado con exito", "Alta Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
        */
            _response = _clienteService.Add(_cliente);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Alta Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                finish();
            }
            else
                MessageBox.Show(_response.Msg, "Alta Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void updateClient()
        {
            _response = _clienteService.Update(_cliente);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Alta Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                finish();
            }
            else
                MessageBox.Show(_response.Msg, "Alta Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void setClient(Cliente client,bool update) {
            _update = update;
            _cliente = client;
            DataContext = _cliente;
        }

        private void TextChanged()
        {
            if (_update)
            {
                if (txtDni.Text.Length == 8)
                {
                    DataTable resultado;
                    resultado = _unitOfWork.Clientes.FindClientByDni(Convert.ToInt32(txtDni.Text));
                    if (resultado.Rows.Count > 0)
                    {
                        MessageBoxResult opcion = MessageBox.Show("Este Dni ya existe presione Ok para cambiar a ese Cliente ", "Cambiar de cliente", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (opcion == MessageBoxResult.OK)
                            loadResult(resultado);
                        else
                            txtDni.Text = txtDni.Text.Remove(7);
                    }

                }
            }
        }

        private void loadResult(DataTable resultado)
        {
            txtDni.Text = resultado.Rows[0]["CLI_Dni"].ToString();
            txtNombre.Text = resultado.Rows[0]["CLI_Nombre"].ToString();
            txtApellido.Text = resultado.Rows[0]["CLI_Apellido"].ToString();
            txtTelefono.Text = resultado.Rows[0]["CLI_Telefono"].ToString();
            txtEmail.Text = resultado.Rows[0]["CLI_Email"].ToString();
            _cliente.Id = Convert.ToInt32(resultado.Rows[0]["CLI_Id"].ToString());
        }

        private void txtDni_KeyUp(object sender, KeyEventArgs e)
        {
            TextChanged();
        }
    }
}
