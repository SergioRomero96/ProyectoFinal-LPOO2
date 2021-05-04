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
    /// Lógica de interacción para ViewThemeSwitcher.xaml
    /// </summary>
    public partial class ViewThemeSwitcher : Window
    {
        public ViewThemeSwitcher()
        {
            InitializeComponent();
            cmbTemas.SelectedIndex = 0;
        }

        private void cmbTemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbTemas.Text.Equals("Nova-Light"))
                imgTema.Source = new BitmapImage(new Uri(@"\resources\imgDark.png", UriKind.Relative));
            else
                imgTema.Source = new BitmapImage(new Uri(@"\resources\imgLight.png", UriKind.Relative));
        }

        private void btnAplicar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTemas.Text.Equals("Nova-Light"))
            {
                ResourceDictionary theme = new ResourceDictionary();
                theme.Source = new Uri("/Templates/Template.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(theme);
            }
            else
            {
                ResourceDictionary theme = new ResourceDictionary();
                theme.Source = new Uri("/Templates/TemplateDark.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(theme);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
