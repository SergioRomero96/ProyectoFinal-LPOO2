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
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;

namespace Vistas.CRUD.Services
{
    /// <summary>
    /// Interaction logic for GestionServicio.xaml
    /// </summary>
    public partial class GestionServicio : UserControl
    {
        public static GestionServicio _instance;
        private IUnitOfWork _unitOfWork;
        private ServicioService _serviciosService;
        private Response _response;
        public AltaServicio _altaServicio;
        public Servicio _servicioUpdate;
        private DateTime _hoy;
       

        public GestionServicio()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _serviciosService = new ServicioService();
            _hoy = DateTime.Now;
        }

        public static GestionServicio GetInstance()
        {
            if (_instance == null)
                _instance = new GestionServicio();
            return _instance;
        }
        /*
        public void LoadViajes()
        {
            dgServicios.ItemsSource = _unitOfWork.Servicios.GetAll().DefaultView;
            dgServicios.UpdateLayout();
        }
        */
        private void ucGestionViajes_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadViajes();
            UpdateServices();
            CargarServicios();
          
        }

        private void UpdateServices()
        {
            _unitOfWork.Servicios.UpdateStates(DateTime.Now);
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            _altaServicio = new AltaServicio();
            _altaServicio.ShowDialog();
        }
       
      
        private void SelectedServicio()
        {

            _servicioUpdate = new Servicio();
            DataRowView rowSelected = (DataRowView)dgServicios.SelectedItem;
            _servicioUpdate.Ser_Codigo = Convert.ToInt32(rowSelected["SER_Codigo"]);
            
            _servicioUpdate.Aut_Codigo = Convert.ToInt32(rowSelected["AUT_Codigo"]);
            _servicioUpdate.Ser_FechaHora = Convert.ToDateTime(rowSelected["SER_FechaHora"]);
         
            _servicioUpdate.Ter_Codigo_Origen = Convert.ToInt32(rowSelected["TER_Codigo_Origen"]);
          
            _servicioUpdate.Ter_Codigo_Destino = Convert.ToInt32(rowSelected["TER_Codigo_Destino"]);
            _servicioUpdate.Ser_Estado = rowSelected["SER_Estado"].ToString();
            _servicioUpdate.Autobus.Empresa.Codigo =(int)rowSelected["EMP_Codigo"];


        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            _altaServicio = new AltaServicio();

            if (dgServicios.SelectedItem != null)
            {
                SelectedServicio();

                _altaServicio.SetServicio(_servicioUpdate,true);
                _altaServicio.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione un Usuario.", "Editar Usuario", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
        public void CargarServicios()
        {
            dgServicios.ItemsSource = _unitOfWork.Servicios.GetAlls().DefaultView;
            dgServicios.UpdateLayout();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgServicios.SelectedItem != null)
            {

                SelectedServicio();
                MessageBoxResult opcion = MessageBox.Show("Desea eliminar la servicio con codigo:  " + _servicioUpdate.Ser_Codigo, "Eliminar Servicio", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                {
                   // _unitOfWork.Servicios.Delete(_servicioUpdate);
                    deleteService();
                  
                }
            }
            else
                MessageBox.Show("Seleccione una servicio", "Eliminar Servicio", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void deleteService()
        {
            _response = _serviciosService.Delete(_servicioUpdate);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Eliminar Servicio", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarServicios();
            }
            else
            {
                MessageBox.Show(_response.Msg, "Eliminar Servicio", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
                CargarServicios();
            else
            {
                DataTable results;
                results = _unitOfWork.Servicios.BuscarCodigoAutobus(Convert.ToInt32(txtBuscar.Text));
                if (results.Rows.Count > 0)
                    dgServicios.ItemsSource = results.DefaultView;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }      
    }
}
