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

namespace Vistas.CRUD.Terminales
{
    /// <summary>
    /// Lógica de interacción para GestionTerminalxaml.xaml
    /// </summary>
    public partial class GestionTerminal : UserControl
    {
        private AltaTerminal _altaTerminal;
        public static GestionTerminal _instancia;
        private Terminal _terminalUpdate;
        private IUnitOfWork _unitOfWork;
        private int _codigoCiudad;

        public GestionTerminal()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        public static GestionTerminal GetInstancia()
        {
            if (_instancia == null)
                _instancia = new GestionTerminal();
            return _instancia;
        }

        private void ucGestionTerminal_Loaded(object sender, RoutedEventArgs e)
        {
            CargarTerminales();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            _altaTerminal = new AltaTerminal();
            _altaTerminal.ShowDialog();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            _altaTerminal = new AltaTerminal();

            if (dgTerminales.SelectedItem != null)
            {
                SelectedTerminal();
                _altaTerminal.SetTerminal(_terminalUpdate, _codigoCiudad, true);
                _altaTerminal.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione una Terminal", "Modificar Terminal", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTerminales.SelectedItem != null)
            {
                SelectedTerminal();
                if (_unitOfWork.Terminales.ValidarTerminalTieneServicio(_terminalUpdate.Ter_Id) > 0)
                {
                    MessageBox.Show("No se puede eliminar terminal asignada a servicio", "Eliminar Terminal", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBoxResult opcion = MessageBox.Show("Desea eliminar la terminal con codigo:  " + _terminalUpdate.Ter_Codigo, "Eliminar Terminal", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (opcion == MessageBoxResult.Yes)
                    {
                        _unitOfWork.Terminales.Delete(_terminalUpdate);
                        CargarTerminales();
                    }
                }
            }
            else
                MessageBox.Show("Seleccione una terminal", "Eliminar Terminal", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SelectedTerminal()
        {
            _terminalUpdate = new Terminal();
            DataRowView rowSelected = (DataRowView)dgTerminales.SelectedItem;
            _terminalUpdate.Ter_Id = Convert.ToInt32(rowSelected["TER_Id"]);
            _terminalUpdate.Ter_Codigo = Convert.ToInt32(rowSelected["TER_Codigo"]);
            _codigoCiudad = Convert.ToInt32(rowSelected["CIU_Codigo"]);
            _terminalUpdate.Ter_Nombre = rowSelected["TER_Nombre"].ToString();
        }

        public void CargarTerminales()
        {
            dgTerminales.ItemsSource = _unitOfWork.Terminales.GetAll().DefaultView;
            dgTerminales.UpdateLayout();
        }

        private void txtNombreTerminal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNombreTerminal.Text.Length == 0)
                CargarTerminales();
            else
            {
                DataTable results;
                results = _unitOfWork.Terminales.BuscarNombreTerminal(txtNombreTerminal.Text);
                if (results.Rows.Count > 0)
                    dgTerminales.ItemsSource = results.DefaultView;
            }
        }

    }
}
