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
using ClasesBases;
using ClasesBases.DataAccess.UnitOfWorkImpl;
using System.Data;
using System.Collections.ObjectModel;

namespace Vistas.CRUD.Users
{
    /// <summary>
    /// Interaction logic for ViewOrdenarUsuario.xaml
    /// </summary>
    public partial class ViewOrdenarUsuario : Window
    {
        public static ObservableCollection<Usuario> listaUsuarios;
        
        //vista del filtrado
        private CollectionViewSource _viewFiltradoUserName;
        private static ViewOrdenarUsuario _instancia;
        private PreviewPrint _print;

        public static ViewOrdenarUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new ViewOrdenarUsuario();
            return _instancia;
        }

        public ViewOrdenarUsuario()
        {
             InitializeComponent();
             _viewFiltradoUserName = Resources["VISTA_USER"] as CollectionViewSource;
            //_usuario = new Usuario();
        }

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        {


            Usuario usuario = e.Item as Usuario;
            //MessageBox.Show(usuario.toString());
            if (usuario.NombreUsuario.Contains(textBuscar.Text.ToString()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }


        }
    

        

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (_viewFiltradoUserName != null)
            {
                _viewFiltradoUserName.Filter += eventVistaUsuario_Filter;
            }  
        }

        private void btnPreView_Click(object sender, RoutedEventArgs e)
        {

            _print = PreviewPrint.GetInstancia();
           _print.printFilter(dgUsers.ItemsSource);
          
            _print.ShowDialog();
        }

       

    }
}
