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
using System.Collections.ObjectModel;
using ClasesBases;
using ClasesBases.Domain.UnitOfWork;
using System.Data;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Services.Implementation;
using ClasesBases.Commons;


namespace Vistas.CRUD.Users
{
    /// <summary>
    /// Lógica de interacción para ViewUsuarios.xaml
    /// </summary>
    public partial class ViewUsuarios : Window
    {
        private IUnitOfWork _unitOfWork;
        private UsuarioService _usuarioService;
        private Response _transactions;
        CollectionView vista;
        private UCGestionUsuario _ucGestionUsuario;
        ObservableCollection<Usuario> usuarios;
        Usuario _usuario;
        private static ViewUsuarios _instancia;

        public static ViewUsuarios GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ViewUsuarios();
            return _instancia;
        }

        public ViewUsuarios()
        {
            InitializeComponent();
            usuarios = new ObservableCollection<Usuario>();
            _unitOfWork = new UnitOfWork();
            _usuarioService = new UsuarioService();
            _usuario = new Usuario();
        }

        private void Canceled()
        {
            if (btnAddabm.Visibility != Visibility.Hidden)
            {
                MessageBoxResult opcion = MessageBox.Show("¿Cancelar Alta de usuario?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                {
                    int aux = vista.CurrentPosition;
                    loadUsers();
                    btnAddabm.Visibility = Visibility.Hidden;
                    vista.MoveCurrentToPosition(aux);
                    btnELiminarABM.IsEnabled = true;// al cancelar la alta de usuario se vuelve a la normalidad el boton eliminar
                }
                else
                    vista.MoveCurrentToLast();
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToFirst();
            Canceled();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToLast();
            Canceled();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToPrevious();
            if (vista.IsCurrentBeforeFirst)
                vista.MoveCurrentToLast();
            Canceled();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToNext();
            if (vista.IsCurrentAfterLast)
                vista.MoveCurrentToFirst();
            Canceled();
        }

        //trae los usuarios de la base de datos y los inserta en la coleccion
        private void loadUsers()
        {
            usuarios.Clear();
            DataTable usuariosBase = new DataTable();
            usuariosBase = _unitOfWork.Usuarios.GetAll();
            foreach (DataRow row in usuariosBase.Rows)
            {
                Usuario usuario = new Usuario();
                Rol rol = new Rol(row["ROL_Codigo"].ToString(), row["ROL_Descripcion"].ToString());
                usuario.ID = Convert.ToInt32(row[0]);
                usuario.NombreUsuario = row[1].ToString();
                usuario.Contraseña = row[2].ToString();
                usuario.ApellidoNombre = row[3].ToString();
                usuario.Rol = rol;
                usuario.Email = row["USU_Email"].ToString();
                usuarios.Add(usuario);
            }

        }

        private void cargar_Roles()
        {
            cmbRol.ItemsSource = _unitOfWork.Usuarios.GetRoles().Tables["Rol"].DefaultView;
            cmbRol.DisplayMemberPath = "ROL_Descripcion";
            cmbRol.SelectedValuePath = "ROL_Codigo";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadUsers();
            DataContext = usuarios;
            vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_data.DataContext);
            cargar_Roles();
        }

        private void btnEditarABM_Click(object sender, RoutedEventArgs e)
        {
            cargarUsuario();
            int position = vista.CurrentPosition;//obtiene la posicion en la que se esta editando

            MessageBoxResult opcion = MessageBox.Show("¿Desea Guardar Cambios?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
                updateUser();
            loadUsers();
            vista.MoveCurrentToPosition(position);
        }

        private void updateUser()
        {
            _transactions = _usuarioService.Update(_usuario); //con esto se ahorra la validacion de Nombre usuario unico ya que la base no permite que se repita
            if (_transactions.Status)
            {
                MessageBox.Show(_transactions.Msg, "Modificar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                _ucGestionUsuario = UCGestionUsuario.GetInstance();
                _ucGestionUsuario.LoadUsuario();
            }
            else
                MessageBox.Show(_transactions.Msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void cargarUsuario()
        {
            _usuario = (Usuario)vista.CurrentItem;
            _usuario.NombreUsuario = txtNombreUsuario.Text;
            _usuario.ApellidoNombre = txtApeyNom.Text.ToUpper();
            _usuario.Contraseña = txtContraseña.Text;
            // Rol rol = new Rol(cmbRol.SelectedValue.ToString(), "");
            _usuario.Rol.Codigo = cmbRol.SelectedValue.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }

        private void AddUsuario()
        {
            _transactions = _usuarioService.Add(_usuario);
            if (_transactions.Status)
            {
                MessageBox.Show(_transactions.Msg, "Agregar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                _ucGestionUsuario = UCGestionUsuario.GetInstance();
                _ucGestionUsuario.LoadUsuario();
                loadUsers();
                btnAddabm.Visibility = Visibility.Hidden;
            }
            else
                MessageBox.Show(_transactions.Msg, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAddABM_Click(object sender, RoutedEventArgs e)
        {
            if (btnAddabm.Visibility != Visibility.Visible)
            {
                Usuario user = new Usuario();
                Rol rol = new Rol();
                user.Rol = rol;
                usuarios.Add(user);
                vista.MoveCurrentToLast();
                cmbRol.SelectedIndex = 0;
                btnAddabm.Visibility = Visibility.Visible;
                btnELiminarABM.IsEnabled = false;
                btnEditarABM.IsEnabled = false;
            }
            else
                MessageBox.Show("Precione añadir para terminar la Alta de usuario", "Agregar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAddabm_Click_1(object sender, RoutedEventArgs e)
        {
            int position = vista.CurrentPosition;//obtiene la posicion en la que se esta agregando
            cargarUsuario();
            MessageBoxResult opcion = MessageBox.Show("¿Desea Guardar Cambios?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                AddUsuario();
                vista.MoveCurrentToPosition(position);
            }
        }

        private void btnELiminarABM_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcion = MessageBox.Show("¿Desea Eliminar este usuario?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (opcion == MessageBoxResult.Yes)
            {
                cargarUsuario();//carga la entidad para enviarla al metodo eliminar
                DeleteUsuario();
                loadUsers();
                vista.MoveCurrentToFirst();
            }
            else
                this.Close();
        }

        private void DeleteUsuario()
        {
            _transactions = _usuarioService.Delete(_usuario);
            if (_transactions.Status)
            {
                MessageBox.Show(_transactions.Msg, "Eliminar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                _ucGestionUsuario = UCGestionUsuario.GetInstance();
                _ucGestionUsuario.LoadUsuario();
            }
            else
                MessageBox.Show(_transactions.Msg, "Eliminar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
           /* _unitOfWork.Usuarios.Delete(_usuario);
            MessageBox.Show("Usuario se Elimino con exito", "Eliminar Usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            _ucGestionUsuario = UCGestionUsuario.GetInstance();
            _ucGestionUsuario.LoadUsuario();*/
        }

        private void Changed(object sender, RoutedEventArgs e)
        {
            if (!btnAddabm.IsVisible)
            {
                if (!btnEditarABM.IsEnabled)
                    MessageBox.Show("Edicion activada precione editar para guardar los cambios", "Editar", MessageBoxButton.OK, MessageBoxImage.Information);
                btnEditarABM.IsEnabled = true;
            }
        }

        private void Lost(object sender, RoutedEventArgs e)
        {
            btnEditarABM.IsEnabled = false;
        }

        private bool ValidarCamposVacios()
        {
            return _usuario["ApellidoNombre"] == null && _usuario["Contraseña"] == null && _usuario["NombreUsuario"] == null && _usuario["Rol_Codigo"] == null;
        }

        private void btnAddabm_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (btnAddabm.IsVisible)
                groupBox1.Header = "Nuevo Usuario";
            else
                groupBox1.Header = "Precione algun campo para activar el modo edicion";
        }
    }
}
