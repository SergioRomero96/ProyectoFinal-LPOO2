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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using ClasesBases;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para GestionCliente.xaml
    /// </summary>
    public partial class GestionCliente : UserControl
    {
        public static GestionCliente _instance;
        private AltaCliente _viewAltaCliente;
        private Cliente _clientUpdate;
        private IUnitOfWork _unitOfWork;
        public GestionCliente()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }
        public static GestionCliente GetInstance()
        {
            if (_instance == null)
                _instance = new GestionCliente();
            return _instance;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           //mostrar alta de clientes

            AltaCliente abrir = AltaCliente.GetInstancia();
            abrir.ShowDialog();
        }
        public void LoadClientes() {
            dgClientes.ItemsSource = _unitOfWork.Clientes.GetAll().DefaultView;
            dgClientes.UpdateLayout();
        }

        private void ucGestionCliente_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClientes();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem != null)
            {
                _viewAltaCliente = new AltaCliente();
                SelectedClient();
                _viewAltaCliente.setClient(_clientUpdate, true);
                _viewAltaCliente.ShowDialog();

            }
            else { MessageBox.Show("Seleccione un Cliente.", "Editar Cliente", MessageBoxButton.OK, MessageBoxImage.Stop); }
        }
        private void SelectedClient() {
            _clientUpdate = new Cliente();
            DataRowView row = (DataRowView)dgClientes.SelectedItem;
            _clientUpdate.Id = Convert.ToInt32(row["CLI_Id"]);
            _clientUpdate.Dni = Convert.ToInt32(row["CLI_Dni"]);
            _clientUpdate.Nombre = row["CLI_Nombre"].ToString();
            _clientUpdate.Apellido = row["CLI_Apellido"].ToString();
            _clientUpdate.Telefono = row["CLI_Telefono"].ToString();
            _clientUpdate.Email = row["CLI_Email"].ToString();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            { LoadClientes(); }
            else
            {
                DataTable resultado;
                resultado = _unitOfWork.Clientes.FindClient(txtBuscar.Text);
                if (resultado.Rows.Count > 0)
                    dgClientes.ItemsSource = resultado.DefaultView;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem != null)
            {
                MessageBoxResult opcion = MessageBox.Show("¿Seguro que desea eliminar cliente?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                {
                    deleteClient();
                    LoadClientes();
                }
            }
            else { MessageBox.Show("Seleccione un Cliente.", "Eliminar Cliente", MessageBoxButton.OK, MessageBoxImage.Stop); }
        }
        private void deleteClient()
        {
            SelectedClient();
            _unitOfWork.Clientes.Delete(_clientUpdate);
            MessageBox.Show("Cliente eliminado", "Eliminar Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
