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
using ClasesBases.Commons.Cache;
using Vistas.CRUD.Ciudades;
using Vistas.CRUD.Users;
using Vistas.CRUD.Terminales;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using Vistas.UserControls;
using System.Windows.Threading;
using System.Data;
using System.IO;
using Vistas.CRUD.Services;
using Vistas.CRUD.Empresas;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _dispatcherTimer;
        private IUnitOfWork _unitOfWork;
        DataTable _data;
        private static MainWindow _instancia;
        public MainWindow()
        {
            
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _dispatcherTimer = new DispatcherTimer();
            
        }
        public static MainWindow GetInstancia()
        {

            if (_instancia == null)
                _instancia = new MainWindow();

            return _instancia;
        }

        private void ocultarBotones()
        {
            if (UserLoginCache.Rol.Equals("1"))
            {
                ocultarBotonesOperador();
            }
            else
            {
                ocultarBotonesAdmin();
            }
        }
        private void ocultarBotonesOperador()
        {
            btnClientes.Visibility = System.Windows.Visibility.Collapsed;
            btnViaje.Visibility = System.Windows.Visibility.Collapsed;
            btnPasaje.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ocultarBotonesAdmin()
        {
            btnAutoBus.Visibility = System.Windows.Visibility.Collapsed;
             btnCiudad.Visibility = System.Windows.Visibility.Collapsed;
             btnTerminal.Visibility = System.Windows.Visibility.Collapsed;
             btnUsuarios.Visibility = System.Windows.Visibility.Collapsed;
             btnEmpresas.Visibility = System.Windows.Visibility.Collapsed;
        }


        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            GestionCliente gestionCliente = GestionCliente.GetInstance();
            OpenInPanel(gestionCliente);
        }

        private void OpenInPanel(UserControl element)
        {
            HideSubMenu();
            if (pnlContenedor.Children.Count > 0)
                pnlContenedor.Children.Clear();
            pnlContenedor.Children.Add(element);
        }

        private void btnAutobus_Click(object sender, RoutedEventArgs e)
        {
            GestionAutobus gestionAutobus = GestionAutobus.GetInstance();
            OpenInPanel(gestionAutobus);

        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }


        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            if (pnlMenu.ActualWidth == 225)
                pnlMenu.Width = new GridLength(75, GridUnitType.Pixel);
            else
                pnlMenu.Width = new GridLength(225, GridUnitType.Pixel);


        }

        private void btnPasaje_Click(object sender, RoutedEventArgs e)
        {
            GestionPasajes pasajes = new GestionPasajes();
            OpenInPanel(pasajes);

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult opcion = MessageBox.Show("¿Desea Cerrar Sesion?", "Log out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                Login log = new Login();
                pnlContenedor.Children.Clear();//para q no explote
                _instancia = null;
                log.Show();

                this.Close();
            }
        }

        public void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            OpenInPanel(new UCInicio());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.SystemKey == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;*/
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            _dispatcherTimer.Tick += (a, b) =>
            {
                lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
                lblFecha.Text = DateTime.Now.ToLongDateString();
            };
            _dispatcherTimer.Start();
            ocultarBotones();
            OpenInPanel(new UCInicio());
            lblUser.Text += UserLoginCache.UserName;

            lblRol.Text += _unitOfWork.Usuarios.GetRol(UserLoginCache.Rol);
            HideSubMenu();
            loadImage();

            
        }

        private void HideSubMenu()
        {
            if (pnlAyuda.Visibility == Visibility.Visible)
                pnlAyuda.Visibility = Visibility.Collapsed;
            if (pnlConfiguracion.Visibility == Visibility.Visible)
                pnlConfiguracion.Visibility = Visibility.Collapsed;
        }

        private void ShowMenu(DockPanel panel)
        {
            if (panel.Visibility == Visibility.Collapsed)
            {
                HideSubMenu();
                panel.Visibility = Visibility.Visible;
            }
            else
                panel.Visibility = Visibility.Collapsed;

        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu(pnlAyuda);
        }

        private void btnManual_Click(object sender, RoutedEventArgs e)
        {
            HideSubMenu();
            
        }

        private void btnAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            HideSubMenu();
            ViewAcercaDe viewAcercaDe = new ViewAcercaDe();
            viewAcercaDe.ShowDialog();
            
        }

        private void btnCiudad_Click(object sender, RoutedEventArgs e)
        {
            OpenInPanel(GestionCiudades.GetInstance());
        }

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void pnlContenedor_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UCGestionUsuario gestionUsuario = UCGestionUsuario.GetInstance();
            OpenInPanel(gestionUsuario);
        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu(pnlConfiguracion);
        }

        private void btnCambiarTema_Click(object sender, RoutedEventArgs e)
        {
            HideSubMenu();
            ViewThemeSwitcher viewTheme = new ViewThemeSwitcher();
            viewTheme.ShowDialog();
        }

        private void lblFecha_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnTerminal_Click(object sender, RoutedEventArgs e)
        {
            GestionTerminal terminal = GestionTerminal.GetInstancia();
            OpenInPanel(terminal);
        }

        private void btnActualizarPerfil_Click(object sender, RoutedEventArgs e)
        {
            UCperfil perfil = new UCperfil();
            OpenInPanel(perfil);
        }
        public void loadImage()
        {
            _data = _unitOfWork.Usuarios.FindUserById(UserLoginCache.Id);
            if (_data.Rows[0]["USU_Imagen"].ToString() != "")
            {
                ImageBrush imagen = new ImageBrush();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                MemoryStream ms = new MemoryStream((byte[])_data.Rows[0]["USU_Imagen"]);
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                imagen.ImageSource = bitmap;
                imgPerfil.Fill = imagen;

            }
        }

        private void btnViaje_Click(object sender, RoutedEventArgs e)
        {
            GestionServicio servicio = GestionServicio.GetInstance();
            OpenInPanel(servicio);
        }

        private void btnEmpresas_Click(object sender, RoutedEventArgs e)
        {
            GestionEmpresa empresa = GestionEmpresa.GetInstance();
            OpenInPanel(empresa);
        }
    }
}

