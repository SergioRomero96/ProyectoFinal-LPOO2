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
using ClasesBases.Services.Implementation;
using System.Data;
using ClasesBases;
using ClasesBases.Services.DTOs;
using Vistas.CRUD.Pasajes;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para GestionPasajes.xaml
    /// </summary>
    public partial class GestionPasajes : UserControl
    {
        private ServicioService _services;
        private TerminalService _terminalServices;
        private Servicio _servicioSelected;
        private VerPasajes _verPasajes;
        private CollectionViewSource vistaColeccionFiltrada; // vista de colección filtrada
        private IUnitOfWork _unitOfWork;
        public GestionPasajes()
        {
            InitializeComponent();
            _services = new ServicioService();
            _terminalServices = new TerminalService();
            _unitOfWork = new UnitOfWork();
            // Se accede al Recurso CollectionViewSource
            vistaColeccionFiltrada = Resources["VISTA_SERVICES"] as CollectionViewSource; // x:Key del CollectionViewSource (XAML)
        }

        private void SelectedServicio()
        {
            
            _servicioSelected = (Servicio)dgServicios.SelectedItem;
           /* _servicioSelected = new ServicioDto();
            _servicioSelected.Codigo = Convert.ToInt32(rowSelected["SER_Codigo"]);
            _servicioSelected.FechaHora = Convert.ToDateTime(rowSelected["SER_FechaHora"]);
            _servicioSelected.Autobus = new AutobusDto { 
                Codigo = Convert.ToInt32(rowSelected["AUT_Codigo"]),
                NroAutobus = Convert.ToInt32(rowSelected["AUT_Nro"]),
                Capacidad = Convert.ToInt32(rowSelected["AUT_Capacidad"])
            };
            _servicioSelected.TipoServicio = rowSelected["AUT_TipoServicio"].ToString();
            _servicioSelected.Origen = rowSelected["CIU_Origen"].ToString();
            _servicioSelected.Destino = rowSelected["CIU_Destino"].ToString();
            _servicioSelected.Estado = rowSelected["SER_Estado"].ToString();*/
            
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
           
            if (dgServicios.SelectedItem != null)
            {
                ShowLoading();
            }
            else
                MessageBox.Show("Seleccione un Servicio", "Gestion de Pasajes", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowVentaPasajes()
        {
            VentaDePasajes viewVentaPasaje = VentaDePasajes.GetInstancia();
            SelectedServicio();
            viewVentaPasaje.SetServicio(_servicioSelected);

            viewVentaPasaje.ShowDialog();
        }
        private void ShowLoading()
        {
            //loading.IsOpen = true;
            ViewBus loading = new ViewBus();
            loading.Show();
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(2)
            };

            timer.Tick += delegate(object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                if (loading.IsActive) loading.Close();
                ShowVentaPasajes();//retrasa esta tarea
            };

            timer.Start();
        }

        private void btnImpr_Click(object sender, RoutedEventArgs e)
        {
            new ImpresionPasaje().ShowDialog();
        }

        private void ucGestionPasajes_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateServices();
            LoadServicios();
        }
        private void UpdateServices()
        {
            _unitOfWork.Servicios.UpdateStates(DateTime.Now);
        }

        private void LoadServicios()
        {
            //if (_services.GetAll().Status)
                //dgServicios.ItemsSource = ((DataTable)_services.GetAll().Data).DefaultView; 
            
            
        }

        private void btnPasajesVendidos_Click(object sender, RoutedEventArgs e)
        {
            _verPasajes = new VerPasajes();
            _verPasajes.ShowDialog();
        }

        private void dpFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                // Se invoca al método eventVistaUsuario_Filter a medida que escriba en el TextBox
                vistaColeccionFiltrada.Filter += eventVistaServicio_Filter;
            }
        }

        private void eventVistaServicio_Filter(object sender, FilterEventArgs e)
        {
            Servicio servicio = e.Item as Servicio;

            // Se realiza la búsqueda
            if (dpFecha != null || txtOrigen != null)
            {
                if (servicio.Ser_FechaHora.ToString().StartsWith(dpFecha.Text) &&
                    servicio.TerminalOrigen.Ciudad.Ciu_Nombre.Contains(txtOrigen.Text) &&
                    servicio.TerminalDestino.Ciudad.Ciu_Nombre.Contains(txtDestino.Text))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        

        private void txtOrigen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                // Se invoca al método eventVistaUsuario_Filter a medida que escriba en el TextBox
                vistaColeccionFiltrada.Filter += eventVistaServicio_Filter;
            }
        }

        private void txtDestino_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                // Se invoca al método eventVistaUsuario_Filter a medida que escriba en el TextBox
                vistaColeccionFiltrada.Filter += eventVistaServicio_Filter;
            }
        }
    }
}
