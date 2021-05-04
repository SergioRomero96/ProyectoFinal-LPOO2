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
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases;

namespace Vistas.CRUD.Ciudades
{
    /// <summary>
    /// Lógica de interacción para UCGestionCiudades.xaml
    /// </summary>
    public partial class GestionCiudades : UserControl
    {
        //private List<Ciudad> ciudades;

        private AltaCiudad _viewAltaCiudad;
        public static GestionCiudades _instance;
        private Ciudad _ciudadUpdate;
        private IUnitOfWork _unitOfWork;

        public GestionCiudades()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            //LoadCiudades();
        }

        public static GestionCiudades GetInstance()
        {
            if (_instance == null)
                _instance = new GestionCiudades();
            return _instance;
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            _viewAltaCiudad = new AltaCiudad();
            _viewAltaCiudad.ShowDialog();
        }

        public void LoadCiudades()
        {
            dgCities.ItemsSource = _unitOfWork.Ciudades.GetAll().DefaultView;
            dgCities.UpdateLayout();
        }

        private void SelectedCiudad()
        {
            _ciudadUpdate = new Ciudad();
            DataRowView rowSelected = (DataRowView)dgCities.SelectedItem;
            _ciudadUpdate.Ciu_Id = Convert.ToInt32(rowSelected["CIU_Id"]);
            _ciudadUpdate.Ciu_Codigo = Convert.ToInt32(rowSelected["CIU_Codigo"]);
            _ciudadUpdate.Ciu_Nombre = rowSelected["CIU_Nombre"].ToString();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            _viewAltaCiudad = new AltaCiudad();

            if (dgCities.SelectedItem != null)
            {
                SelectedCiudad();
                _viewAltaCiudad.SetCiudad(_ciudadUpdate, true);
                _viewAltaCiudad.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione una Ciudad.", "Modificar Ciudad", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgCities.SelectedItem != null)
            {
                SelectedCiudad();
                MessageBoxResult opcion = MessageBox.Show("Desea eliminar la ciudad con código " + _ciudadUpdate.Ciu_Codigo, "Eliminar Ciudad", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                {
                    if (_unitOfWork.Ciudades.ValidarCiudadTieneTerminal(Convert.ToInt32(_ciudadUpdate.Ciu_Id)) > 0)
                        MessageBox.Show("No se puede eliminar ciudad porque tiene terminal asignada", "Eliminar Ciudad", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        _unitOfWork.Ciudades.Delete(_ciudadUpdate);
                        LoadCiudades();
                    }
                }
            }
            else
                MessageBox.Show("Seleccione una ciudad", "Eliminar Ciudad", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ucGestionCiudades_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCiudades();
        }

        private void txtBuscarCiudad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscarCiudad.Text.Length == 0)
            {
                LoadCiudades();
            }
            else
            {
                DataTable results;
                results = _unitOfWork.Ciudades.BuscarNombreCiudad(txtBuscarCiudad.Text);
                if (results.Rows.Count > 0)
                    dgCities.ItemsSource = results.DefaultView;
            }
        }
    }
}