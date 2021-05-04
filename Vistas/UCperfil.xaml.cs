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
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Data;
using ClasesBases.Commons.Cache;
using System.IO;
using Microsoft.Win32;
using ClasesBases;
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para UCperfil.xaml
    /// </summary>
    public partial class UCperfil : UserControl
    {
        public static UCperfil _instance;
        private IUnitOfWork _unitOfWork;
        private UsuarioService _usuarioService;
        private bool _enabled = false;
        private DataTable data;
        private Usuario _usuario;
        int value = 0;//value del progres bar

        public UCperfil()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _usuarioService = new UsuarioService();
            _usuario = new Usuario();
        }
        public static UCperfil GetInstance()
        {
            if (_instance == null)
                _instance = new UCperfil();
            return _instance;
        }


        private void ucPerfil_Loaded(object sender, RoutedEventArgs e)
        {
            cargarDatos();
            DataContext = _usuario;
            txtContraseña.Password = _usuario.Contraseña;
            txtContraseña.ToolTip = "Ingrese contraseña para hacer cualquier tipo de cambios";
            disabledButtons();
        }

        private void disabledButtons()
        {
            txtApellidoYnombre.IsEnabled = _enabled;
            txtEmail.IsEnabled = _enabled;
            txtNueva.IsEnabled = _enabled;

            txtContraseña.IsEnabled = _enabled;
            btnImg.IsEnabled = _enabled;

        }

        private void cargarDatos()
        {

            data = _unitOfWork.Usuarios.FindUserById(UserLoginCache.Id);
            _usuario.ID = UserLoginCache.Id;
            _usuario.ApellidoNombre = data.Rows[0]["USU_ApellidoNombre"].ToString();
            _usuario.NombreUsuario = data.Rows[0]["USU_NombreUsuario"].ToString();
            _usuario.Contraseña = data.Rows[0]["USU_Contraseña"].ToString();
            Rol rol = new Rol(data.Rows[0]["ROL_Codigo"].ToString(), "");
            _usuario.Rol = rol;
            if (data.Rows[0]["USU_Imagen"].ToString() != "")
                cargarImagen((byte[])data.Rows[0]["USU_Imagen"]);
            _usuario.Email = data.Rows[0]["USU_Email"].ToString();
        }

        private void cargarImagen(byte[] perfil)
        {
            ImageBrush imagen = new ImageBrush();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            MemoryStream ms = new MemoryStream(perfil);
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            imagen.ImageSource = bitmap;
            fotoPerfil.Fill = imagen;
            _usuario.Imagen = perfil;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Usu_Imagen (*.bmp, *.jpg, *.png , *.img)|*.bmp;*.jpg;*.png;*.img";

            if (img.ShowDialog() == true)
            {
                string _pathImg = img.FileName;
                _usuario.Imagen = File.ReadAllBytes(_pathImg);//convierte la imagen a cadena de bytes
                cargarImagen(_usuario.Imagen);

            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (_usuario.Contraseña == txtContraseña.Password)
            {
                if (txtRepetir.IsEnabled)
                {
                    if (txtRepetir.Password == txtNueva.Password && txtRepetir.Password.Length >= 5)
                    {
                        _usuario.Contraseña = txtNueva.Password;
                        updateUser();
                        BackToHome(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Debil pruebe con otra", "Modificar Perfil", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNueva.Password = "";
                        txtRepetir.Password = "";
                    }
                }
                else
                {
                    updateUser();
                    BackToHome(sender, e);
                }
            }
            else
                MessageBox.Show("Contraseña incorrecta", "Modificar Perfil", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void updateUser()
        {
            Response _response = new Response();
            _response = _usuarioService.Update(_usuario);
            if (_response.Status)
            {
                MessageBox.Show(_response.Msg, "Modificar Perfil", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow m = MainWindow.GetInstancia();
                m.loadImage();

            }
            else
                MessageBox.Show(_response.Msg, "Modificar Perfil", MessageBoxButton.OK, MessageBoxImage.Error);
            
            
        }




        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            _enabled = true;
            disabledButtons();
            txtContraseña.Password = "";
            HiddenButtons();

        }

        private void HiddenButtons()
        {
            link.Visibility = System.Windows.Visibility.Hidden;
            btnEditar.Visibility = System.Windows.Visibility.Visible;
            btnCancelar.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BackToHome(sender, e);
        }

        private void BackToHome(object sender, RoutedEventArgs e)
        {
            MainWindow mw = MainWindow.GetInstancia();
            mw.btnInicio_Click(sender, e);
        }



        private void txtNueva_PasswordChanged(object sender, RoutedEventArgs e)
        {
            value = txtNueva.Password.Length * 10;
            if (!txtRepetir.IsEnabled)
            {
                MessageBoxResult opcion = MessageBox.Show("¿Desea Modificar Contraseña?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                {
                    txtRepetir.IsEnabled = true;
                    pgBar.Visibility = System.Windows.Visibility.Visible;
                }
                else { txtRepetir.IsEnabled = false; }
            }
            pgBar.Value = value;


        }

        private void txtRepetir_PasswordChanged(object sender, RoutedEventArgs e)
        {
            value = value + txtRepetir.Password.Length * 10;
            pgBar.Value = value;
            if (txtRepetir.Password == txtNueva.Password)
            {
                pgBar.ToolTip = "Correcto";

                pgBar.BorderBrush = Brushes.Green;
            }
            else
            {
                pgBar.BorderBrush = Brushes.Red;
                pgBar.ToolTip = "Error";
            }

        }


    }
}
