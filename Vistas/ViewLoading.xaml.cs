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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ViewLoading.xaml
    /// </summary>
    public partial class ViewLoading : Window
    {
        private static ViewLoading _instance;

        public ViewLoading()
        {
            InitializeComponent();
        }

        public static ViewLoading GetInstance()
        {
            if (_instance == null)
                _instance = new ViewLoading();
            return _instance;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instance = null;
        }
    }
}
