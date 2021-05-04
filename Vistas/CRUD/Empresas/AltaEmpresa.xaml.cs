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
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;

namespace Vistas.CRUD.Empresas
{
    /// <summary>
    /// Interaction logic for AltaEmpresa.xaml
    /// </summary>
    public partial class AltaEmpresa : Window
    {
        private Empresa _empresa;
        private EmpresaService _empresaService;
        private Response _response;
        private bool _update = false;
        public static AltaEmpresa _instancia;


        public static AltaEmpresa GetInstancia()
        {
            if (_instancia == null)
                _instancia = new AltaEmpresa();
            return _instancia;
        }
        public AltaEmpresa()
        {
            InitializeComponent();
            _empresaService = new EmpresaService();
            _empresa = new Empresa();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            loadCompany();
            MessageBoxResult opcion = MessageBox.Show("¿Desea Guardar?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                if (!_update)
                    insertCompany();
                else
                    updateCompany();
                DataContext = _empresa;
            }
        }

        private void updateCompany()
        {
            _response = _empresaService.Update(_empresa);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Modificar Empresa", MessageBoxButton.OK, MessageBoxImage.Information);
                loadDataGrid();
                this.Close();
            }
            else
                MessageBox.Show(_response.Msg, "Modificar Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void insertCompany()
        {
            _response = _empresaService.Add(_empresa);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Alta Empresa", MessageBoxButton.OK, MessageBoxImage.Information);
                loadDataGrid();
                this.Close();
            }
            else
                MessageBox.Show(_response.Msg, "Alta Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void loadCompany()
        {   if(txtCodigo.Text!="")
            _empresa.Codigo = Convert.ToInt32(txtCodigo.Text);
            _empresa.Nombre = txtNombre.Text.ToUpper();
            _empresa.Direccion = txtDireccion.Text.ToUpper();
            _empresa.Telefono = txtTelefono.Text;
            _empresa.Email = txtEmail.Text;
        }
        private void loadDataGrid() {
            GestionEmpresa gestionEmpresa = GestionEmpresa.GetInstance();
            gestionEmpresa.loadCompanies();
        }

        public void loadCompanyToUpdate(Empresa empresa, bool update) {
            _update = update;
            DataContext = empresa;
            _empresa.Id = empresa.Id;
        }
    }
}
