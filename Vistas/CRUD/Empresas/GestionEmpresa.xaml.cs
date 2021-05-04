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
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases;
using System.Data;
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;

namespace Vistas.CRUD.Empresas
{
    /// <summary>
    /// Interaction logic for GestionEmpresa.xaml
    /// </summary>
    public partial class GestionEmpresa : UserControl
    {
        public static GestionEmpresa _instance;
        private IUnitOfWork _unitOfWork;
        private Empresa _empresaUpdate;
        private EmpresaService _empresaService;
        private Response _response;
        public static GestionEmpresa GetInstance()
        {
            if (_instance == null)
                _instance = new GestionEmpresa();
            return _instance;
        }
        public GestionEmpresa()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _empresaService = new EmpresaService();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AltaEmpresa altaEmpresa = AltaEmpresa.GetInstancia();
            altaEmpresa.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadCompanies();
        }

        public void loadCompanies()
        {
            dgEmpresas.ItemsSource = _unitOfWork.Empresas.GetAll().DefaultView;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            AltaEmpresa alta = new AltaEmpresa();
            if (dgEmpresas.SelectedItem != null)
            {
                SelectedCompany();
                alta.loadCompanyToUpdate(_empresaUpdate, true);
                alta.ShowDialog();
            }

        }

        private void SelectedCompany()
        {
            _empresaUpdate = new Empresa();
            DataRowView rowSelected = (DataRowView)dgEmpresas.SelectedItem;
            _empresaUpdate.Id = Convert.ToInt32(rowSelected["EMP_Id"]);
            _empresaUpdate.Codigo = Convert.ToInt32(rowSelected["EMP_Codigo"]);
            _empresaUpdate.Nombre = rowSelected["EMP_Nombre"].ToString();
            _empresaUpdate.Direccion = rowSelected["EMP_Direccion"].ToString();
            _empresaUpdate.Telefono = rowSelected["EMP_Telefono"].ToString();
            _empresaUpdate.Email = rowSelected["EMP_Email"].ToString();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmpresas.SelectedItem != null)
            {
                SelectedCompany();
                MessageBoxResult opcion = MessageBox.Show("Desea Eliminar al Autobus con Id: " + _empresaUpdate.Id, "Eliminar Empresa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                {
                    deleteCompany();  
                }
            }
            else
                MessageBox.Show("Seleccione un Autobus.", "Eliminar Empresa", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void deleteCompany()
        {
            _response = _empresaService.Delete(_empresaUpdate);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Eliminar Empresa", MessageBoxButton.OK, MessageBoxImage.Information);
                loadCompanies();
            }
            else {
                MessageBox.Show(_response.Msg, "Eliminar Empresa", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void txtNombreEmpresa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNombreEmpresa.Text.Length == 0)
                loadCompanies();
            else
            {
                DataTable results;
                results = _unitOfWork.Empresas.BuscarNombreEmpresa(txtNombreEmpresa.Text);
                if (results.Rows.Count > 0)
                    dgEmpresas.ItemsSource = results.DefaultView;
            }
        }

    }
}

