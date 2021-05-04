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
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;
using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para AltaAutoBus.xaml
    /// </summary>
    public partial class AltaAutoBus : Window
    {
        private IUnitOfWork _unitOfWork;
        private AutobusService _autobusService;
        private Response _response;
        private Autobus _autobus;
        private string _pathImg;
        private bool _update = false;
        private string _tipoServicio;
        private List<int> _butacas;
        private int _max = 60;
        private int _min = 10;
        private GestionAutobus _ucGestionAutobus;
        

        public static AltaAutoBus _instancia;

        public static AltaAutoBus GetInstancia()
        {
            if (_instancia == null)
                _instancia = new AltaAutoBus();
            return _instancia;
        }

        public AltaAutoBus()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _autobusService = new AutobusService();
            _autobus = new Autobus();
            _butacas = new List<int>();
        }

        private void AgregarAutobus()
        {
            _response = _autobusService.Add(_autobus);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Agregar Autobus", MessageBoxButton.OK, MessageBoxImage.Information);
                refresh();
            }
            else
                MessageBox.Show(_response.Msg, "Agregar Autobus", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ActualizarAutobus()
        {
          
            _response = _autobusService.Update(_autobus);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Modificar Autobus", MessageBoxButton.OK, MessageBoxImage.Information);
                refresh();
            }
            else
                MessageBox.Show(_response.Msg, "Modificar autobus", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CargarDatos()
        {
            if (txtCodigo.Text != "")
                _autobus.Codigo = Convert.ToInt32(txtCodigo.Text);
            else
                _autobus.Codigo = 0;
            if (txtCapacidad.Text != "")
                _autobus.Capacidad = Convert.ToInt32(txtCapacidad.Text);
            else
                _autobus.Capacidad = 0;
            _autobus.TipoServicio = cmbTipo.Text;
            _autobus.Matricula = txtMatricula.Text.ToUpper();
            _autobus.Empresa.Codigo = Convert.ToInt32(cmbEmpresa.SelectedValue);
            _autobus.CantidadPisos = Convert.ToInt32(cmbPisos.Text);
        }

        private void loadImage()
        {
            if (_pathImg != null)
                _autobus.Imagen = File.ReadAllBytes(_pathImg);//convierte la imagen a cadena de bytes
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            CargarDatos();
            MessageBoxResult opcion = MessageBox.Show("¿Desea Guardar?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                if (!_update)
                    AgregarAutobus();
                else
                    ActualizarAutobus();              
                DataContext = _autobus;
            }
        }

        private void refresh()
        {
            _ucGestionAutobus = GestionAutobus.GetInstance();
            _ucGestionAutobus.LoadAutobuses();
            this.Close();
        }

        public void SetAutobus(Autobus autobus, bool update)
        {
            _update = update;
            _autobus = autobus;
            _tipoServicio = autobus.TipoServicio;
            _autobus.Id = autobus.Id;
            DataContext = autobus;
            cargarImagen();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadCompanies();
            cmbPisos.ItemsSource = new int[2] { 1, 2 };

            if (_update)
            {
                cmbTipo.SelectedValue = _tipoServicio;
                cmbEmpresa.SelectedValue = _autobus.Empresa.Codigo.ToString();
            }
        }

        private void loadCompanies()
        {
            cmbEmpresa.ItemsSource = _unitOfWork.Autobus.getEmpresas().DefaultView;
            cmbEmpresa.DisplayMemberPath = "EMP_Nombre";
            cmbEmpresa.SelectedValuePath = "EMP_Codigo";
            cmbEmpresa.SelectedIndex = 0;            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Imagen (*.bmp, *.jpg, *.png , *.img)|*.bmp;*.jpg;*.png;*.img";

            if (img.ShowDialog() == true)
            {
                _pathImg = img.FileName;
                _autobus.Imagen = File.ReadAllBytes(_pathImg);//convierte la imagen a cadena de bytes
                cargarImagen();
            }

        }

        private void cargarImagen()
        {
            if (_autobus.Imagen != null)
            {
                ImageBrush imagen = new ImageBrush();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                MemoryStream ms = new MemoryStream(_autobus.Imagen);
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                imagen.ImageSource = bitmap;
                mediaFoto.Fill = imagen;
            }
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DefinirMinMax();
        }

        private void DefinirMinMax()
        {
            if (cmbTipo.SelectedValue != null)
            {
                switch (cmbTipo.SelectedValue.ToString())
                {
                    case "Cama Suite":
                        LoadComboBoxCama();
                        break;
                    case "Cama Vip":
                        LoadComboBoxCama();
                        break;
                    case "Cama":
                        LoadComboBoxCama();
                        break;
                    case "Semi Cama":
                        LoadComboBoxSemiCama();
                        break;
                    case "Normal":
                        LoadComboBoxSemiCama();
                        break;
                }
            }
        }

        private void LoadComboBoxSemiCama()
        {
            if (cmbPisos.SelectedValue.ToString() == "1")
            {
                _min = 20;
                _max = 40;
            }
            else
            {
                _min = 40;
                _max = 60;
            }
            GenerateCapacity();
        }

        private void LoadComboBoxCama()
        {
            if (cmbPisos.SelectedValue.ToString() == "1")
            {
                _min = 14;
                _max = 30;
            }
            else
            {
                _min = 30;
                _max = 46;
            }
            GenerateCapacity();
        }


        private void GenerateCapacity()
        {
            _butacas = new List<int>();
            for (int i = _min; i <= _max; i++)
            {
                if (i % 2 == 0)
                    _butacas.Add(i);
            }
            txtCapacidad.ItemsSource = _butacas;
            txtCapacidad.SelectedIndex = 0;
        }

        private void cmbPisos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DefinirMinMax();
        }





    }
}
