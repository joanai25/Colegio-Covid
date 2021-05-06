using System;
using System.Collections.Generic;
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

namespace ColegioCovid.Ventanas
{
    /// <summary>
    /// Lógica de interacción para FrameElegir.xaml
    /// </summary>
    public partial class FrameElegir : Page
    {
        public FrameElegir()
        {
            InitializeComponent();
        }

        private void btnAlu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FrameEditar.xaml", UriKind.Relative));
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FramePrincipal.xaml", UriKind.Relative));
        }

        private void btnAula_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FrameEditarAula.xaml", UriKind.Relative));
        }
    }
}
