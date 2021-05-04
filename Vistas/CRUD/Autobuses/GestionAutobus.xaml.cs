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
using System.IO;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para GestionAutobus.xaml
    /// </summary>
    public partial class GestionAutobus : UserControl
    {
        public static GestionAutobus _instance;
        private Autobus _autobusUpdate;
        private AltaAutoBus _viewAltaAutoBus;
        private IUnitOfWork _unitOfWork;

        public GestionAutobus()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        public static GestionAutobus GetInstance() 
        {
            if (_instance == null)
                _instance = new GestionAutobus();
            return _instance;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            _viewAltaAutoBus = new AltaAutoBus();
            _viewAltaAutoBus.ShowDialog();
        }

        private void ucGestionAutobus_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAutobuses();
        }

        public void LoadAutobuses() 
        {
            dgAutobuses.ItemsSource = _unitOfWork.Autobus.GetAll().DefaultView;
            dgAutobuses.UpdateLayout();
        }

        private void SelectedAutobus()
        {
            _autobusUpdate = new Autobus();
            DataRowView rowSelected = (DataRowView)dgAutobuses.SelectedItem;
            _autobusUpdate.Id = Convert.ToInt32(rowSelected["AUT_Id"]);
            _autobusUpdate.Codigo = Convert.ToInt32(rowSelected["AUT_Codigo"]);
            _autobusUpdate.Capacidad = Convert.ToInt32(rowSelected["AUT_Capacidad"]);
            _autobusUpdate.Matricula = rowSelected["AUT_Matricula"].ToString();
            _autobusUpdate.TipoServicio = rowSelected["AUT_TipoServicio"].ToString();
            _autobusUpdate.Empresa.Codigo = Convert.ToInt32(rowSelected["EMP_Codigo"]);
            if (rowSelected["AUT_Imagen"].ToString() != "")
                _autobusUpdate.Imagen = (byte[])rowSelected["AUT_Imagen"];
            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            _viewAltaAutoBus = new AltaAutoBus();

            if (dgAutobuses.SelectedItem != null)
            {
                SelectedAutobus();
                _viewAltaAutoBus.SetAutobus(_autobusUpdate, true);
                _viewAltaAutoBus.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione un Autobus.", "Editar Autobus", MessageBoxButton.OK, MessageBoxImage.Stop);
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgAutobuses.SelectedItem != null)
            {
                SelectedAutobus();
                MessageBoxResult opcion = MessageBox.Show("Desea Eliminar al Autobus con Id: " + _autobusUpdate.Codigo, "Eliminar Autobus", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                {
                    _unitOfWork.Autobus.Delete(_autobusUpdate);
                    LoadAutobuses();
                }
            }
            else
                MessageBox.Show("Seleccione un Autobus.", "Eliminar Autobus", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void txtMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtMatricula.Text.Length == 0)
                LoadAutobuses();
            else
            {
                DataTable results;
                results = _unitOfWork.Autobus.BuscarMatricula(txtMatricula.Text);
                if (results.Rows.Count > 0)
                    dgAutobuses.ItemsSource = results.DefaultView;
            }
        }
    }
}
