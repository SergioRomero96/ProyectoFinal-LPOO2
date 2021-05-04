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
using ClasesBases.Domain.UnitOfWork;
using System.Net.Mail;
using ClasesBases;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Net;
using System.Data;
using ClasesBases.Services.Extension;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for RecuperarCuenta.xaml
    /// </summary>
    public partial class RecuperarCuenta : Window
    {
        private IUnitOfWork _unitOfWork;
        private string _remitente = "apussjbus@gmail.com";
        private string _mensaje;
        private int _newPassword;
        private MailMessage _mail;
        private Usuario _usuario;

        public RecuperarCuenta()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _usuario = new Usuario();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            _usuario.Email = txtEmail.Text;
            _usuario.NombreUsuario = txtUsuario.Text;
            if (validateEmail())
            {
                sendEmail();
                updatePassword();
            }
            else
                MessageBox.Show("Email o usuarios invalidos", "Recuperar Cuenta", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void updatePassword()
        {
            _usuario.Contraseña = _newPassword.ToString();
            _unitOfWork.Usuarios.Update(_usuario);
            this.Close();
        }

        private bool validateEmail()
        {
            DataTable dt = new DataTable();
            dt = _unitOfWork.Usuarios.FindUserByEmail(_usuario);
            if (dt.Rows.Count > 0)
            {
                _usuario = (Usuario)UsuarioMapper.ToUser(dt);
                return true;

            }
            else
                return false;
        }

        private void sendEmail()
        {
            createMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_remitente, "yarbicapo");//contraseña no cambiar
            smtp.Send(_mail);
            _mail.Dispose();
            MessageBox.Show("Contraseña enviada al correo", "Recuperar Cuenta", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void createMessage()
        {
            Random numero = new Random();
            _newPassword = numero.Next(100000, 999999);
            _mensaje = "Se nueva Contraseña es " + _newPassword + " Luego de ingresar la podra modificar editando su perfil";
            _mail = new MailMessage(_remitente, _usuario.Email, "ApuJujuBus", _mensaje);
        }
    }

}