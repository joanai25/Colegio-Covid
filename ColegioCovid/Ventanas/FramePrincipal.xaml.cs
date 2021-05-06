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
    /// Lógica de interacción para FramePrincipal.xaml
    /// </summary>
    public partial class FramePrincipal : Page
    {
        public FramePrincipal()
        {
            InitializeComponent();
        }

        private void btnMant_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FrameElegir.xaml", UriKind.Relative));
        }

        private void btnUso_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FrameElegirUso.xaml", UriKind.Relative));
        }
    }
}
