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
using ClasesBases.Commons.Cache;
using System.Collections;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Data;
using System.Speech.Synthesis;
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private IUnitOfWork _unitOfWork;
        ArrayList listaUsuarios = new ArrayList();
        
        public Login()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
        }

        private bool VerificarUsuario()
        {
            foreach (Usuario usu in listaUsuarios) {
                if (usu.NombreUsuario.Equals(login.Usuario) && usu.Contraseña.Equals(login.Password))
                {
                    UserLoginCache.UserName = usu.NombreUsuario;
                    UserLoginCache.Rol = usu.Rol.Codigo == "1" ? "Administrador" : "Operador";
                    return true;
                }
            }
            return false;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            ViewLoading loading = new ViewLoading();
            loading.Show();
            timeShow(loading);
        }

        private void timeShow(ViewLoading loading)
        {
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1.5)
            };

            timer.Tick += delegate(object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                if (loading.IsActive) loading.Close();
                OpenHome();
            };

            timer.Start();
        }

        private void OpenHome()
        {
            DataTable dataTable = _unitOfWork.Usuarios.ValidarLogin(login.txtUsuario.Text, login.txtPassword.Password);
            if (dataTable.Rows.Count == 1)
            {
                Speak();
                MainWindow abrir = MainWindow.GetInstancia();
                abrir.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos erroneos, intente nuevamente", "Ingreso al Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                login.txtUsuario.Text = "";
                login.txtPassword.Password = "";
            }
        }

        private void Speak()
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.SpeakAsync("bienvenido " + login.txtUsuario.Text);
        }

        private void login_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void passRecu_Click(object sender, RoutedEventArgs e)
        {
            new RecuperarCuenta().ShowDialog();
        }
    }
}
