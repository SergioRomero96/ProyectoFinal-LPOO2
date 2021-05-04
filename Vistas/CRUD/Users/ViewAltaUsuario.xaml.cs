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
using ClasesBases.Commons;
using ClasesBases;
using ClasesBases.DataAccess.UnitOfWorkImpl;

using ClasesBases.Services.Implementation;
using System.Data;

namespace Vistas.CRUD.Users
{
    /// <summary>
    /// Interaction logic for ViewAltaUsuario.xaml
    /// </summary>
    public partial class ViewAltaUsuario : Window
    {
        private IUnitOfWork _unitOfWork;
        private UsuarioService _usuarioService;
        private Response _transactions;
        private Usuario _usuario;
        private bool _update = false;
        private UCGestionUsuario _ucGestionUsuario;
        private static ViewAltaUsuario _instancia;
        private string _rol;

        public static ViewAltaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ViewAltaUsuario();
            return _instancia;
        }

        public ViewAltaUsuario()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _usuarioService = new UsuarioService();
            _usuario = new Usuario();
        }

        private void cargar_Roles()
        {
            cmbRol.ItemsSource = _unitOfWork.Usuarios.GetRoles().Tables["Rol"].DefaultView;
            cmbRol.DisplayMemberPath = "ROL_Descripcion";
            cmbRol.SelectedValuePath = "ROL_Codigo";
        }

        private void AgregarUsuario()
        {
            _transactions = _usuarioService.Add(_usuario); //con esto se ahorra la validacion de Nombre usuario unico ya que la base no permite que se repita
            if (_transactions.Status)
            {
                MessageBox.Show(_transactions.Msg, "Agregar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show(_transactions.Msg, "Agregar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ActualizarUsuario()
        {
            _transactions = _usuarioService.Update(_usuario); //con esto se ahorra la validacion de Nombre usuario unico ya que la base no permite que se repita
            if (_transactions.Status)
            {
                MessageBox.Show(_transactions.Msg, "Modificar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show(_transactions.Msg, "Modificar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CargarDatos()
        {
            _usuario.NombreUsuario = txtNombreUsuario.Text;
            _usuario.Contraseña = txtContraseña.Text;
            _usuario.ApellidoNombre = txtApeyNom.Text.ToUpper();
            _usuario.Email = txtEmail.Text;
            if (cmbRol.Text != "")
            {
                _usuario.Rol = new Rol();
                _usuario.Rol.Codigo = cmbRol.SelectedValue.ToString();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            CargarDatos();
            MessageBoxResult opcion = MessageBox.Show("¿Desea Guardar?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                excute();
                DataContext = _usuario;
            }
            _ucGestionUsuario = UCGestionUsuario.GetInstance();
            _ucGestionUsuario.LoadUsuario();
        }

        private void excute()
        {
            if (!_update)
                AgregarUsuario(); // ya no hace falta las validaciones de arriba de usuario unico
            else
                ActualizarUsuario(); //gracias a los servicios se evita el validar que no sea repetido el usuario 
                //la base hace todo el trabajo ya que si no se modifica el nombre usuario no lo toma como repetido
        }

        public void SetUsuario(Usuario usuario, bool update)
        {
            _update = update;
            DataContext = usuario;
            _usuario.ID = usuario.ID;
            _rol = usuario.Rol.Codigo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargar_Roles();
            if (_update)
                cmbRol.SelectedValue = _rol;
            else
                cmbRol.SelectedIndex = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
