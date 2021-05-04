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
using System.Collections;
using System.Collections.ObjectModel;
using ClasesBases;

namespace Vistas.CRUD.Users
{
    /// <summary>
    /// Lógica de interacción para PreviewPrint.xaml
    /// </summary>
    public partial class PreviewPrint : Window
    {
        private static PreviewPrint _instancia;
        private static IEnumerable _data;
        public static PreviewPrint GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PreviewPrint();
            return _instancia;

           
        }
        public void printFilter(IEnumerable dg){
            _data = dg;
        }

        public PreviewPrint()
        {
            InitializeComponent();
           
          
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }



        private void btnPrint_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if (pdlg.ShowDialog() == true)
            {
                pdlg.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
                this.Close();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = _data;
        }

       
    }
}
