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
using ClasesBases;
using ClasesBases.Domain.UnitOfWork;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using ClasesBases.Commons;

namespace Vistas.CRUD.Users
{
    /// <summary>
    /// Interaction logic for UCGestionUsuario.xaml
    /// </summary>
    public partial class UCGestionUsuario : UserControl
    {
        public static UCGestionUsuario _instance;
        private Usuario _usuarioUpdate;
        private ViewAltaUsuario _viewAltaUsuario;
        private IUnitOfWork _unitOfWork;
        private UsuarioService _usuarioService;
        private Response _responce;
        private ViewOrdenarUsuario _viewOrdenarUsuario;

        public UCGestionUsuario() {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _usuarioService = new UsuarioService();
        }

        public static UCGestionUsuario GetInstance()
        {
            if (_instance == null)
                _instance = new UCGestionUsuario();
            return _instance;
        }

        private void ucGestionUsuarios_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsuario();
        }

        public void LoadUsuario()
        {
            dgUsers.ItemsSource = _unitOfWork.Usuarios.GetAll().DefaultView;
            dgUsers.UpdateLayout();
        }

        private void SelectedUsuario()
        {
            _usuarioUpdate = new Usuario();
            DataRowView rowSelected = (DataRowView)dgUsers.SelectedItem;
            Rol rol = new Rol(rowSelected["ROL_Codigo"].ToString(), rowSelected["ROL_Descripcion"].ToString());//agregado
            _usuarioUpdate.ID = Convert.ToInt32(rowSelected["USU_Id"]);
            _usuarioUpdate.NombreUsuario = rowSelected["USU_NombreUsuario"].ToString();
            _usuarioUpdate.Contraseña = rowSelected["USU_Contraseña"].ToString();
            _usuarioUpdate.ApellidoNombre = rowSelected["USU_ApellidoNombre"].ToString();
            _usuarioUpdate.Rol = rol; //modificado
            _usuarioUpdate.Email = rowSelected["USU_Email"].ToString();
        }

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            _viewAltaUsuario = new ViewAltaUsuario();
            _viewAltaUsuario.ShowDialog();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            _viewAltaUsuario = new ViewAltaUsuario();
            if (dgUsers.SelectedItem != null)
            {
                SelectedUsuario();
                _viewAltaUsuario.SetUsuario(_usuarioUpdate, true);
                _viewAltaUsuario.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione un Usuario.", "Editar Usuario", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void btnELiminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                SelectedUsuario();
                MessageBoxResult opcion = MessageBox.Show("Desea Eliminar al Usuario con Id: " + _usuarioUpdate.ID, "Eliminar Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (opcion == MessageBoxResult.Yes)
                    deleteUser();
            }
            else
                MessageBox.Show("Seleccione un Usuario.", "Eliminar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void deleteUser()
        {
           _responce= _usuarioService.Delete(_usuarioUpdate);
           if (_responce.Status)
           {
               MessageBox.Show(_responce.Msg, "Eliminar Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
               LoadUsuario();
           }
           else
               MessageBox.Show(_responce.Msg, "Eliminar Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnAbm_Click(object sender, RoutedEventArgs e)
        {
            ViewUsuarios.GetInstancia().ShowDialog();
        }

        private void btnOrdenar_Click(object sender, RoutedEventArgs e)
        {
            _viewOrdenarUsuario = new ViewOrdenarUsuario();
            _viewOrdenarUsuario.ShowDialog();
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUsuario.Text.Length == 0)
                LoadUsuario();
            else
            {
                DataTable results;
                results = _unitOfWork.Usuarios.BuscarNombreUsuario(txtUsuario.Text);
                if (results.Rows.Count > 0)
                    dgUsers.ItemsSource = results.DefaultView;
            }
        }
    }
}
