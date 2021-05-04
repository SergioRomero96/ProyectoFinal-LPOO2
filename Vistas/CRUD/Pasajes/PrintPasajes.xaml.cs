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

namespace Vistas.CRUD.Pasajes
{
    /// <summary>
    /// Lógica de interacción para PrintPasajes.xaml
    /// </summary>
    public partial class PrintPasajes : Window
    {
        private static PrintPasajes _instancia;
        private static IEnumerable _data;

        public PrintPasajes()
        {
            InitializeComponent();
        }

        public static PrintPasajes GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PrintPasajes();
            return _instancia;
        }

        public void printFilter(IEnumerable dg)
        {
            _data = dg;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
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
            dgPasajes.ItemsSource = _data;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }
    }
}
