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
    /// Lógica de interacción para FrameEditarAula.xaml
    /// </summary>
    public partial class FrameEditarAula : Page
    {
        public FrameEditarAula()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FrameElegir.xaml", UriKind.Relative));
        }

        private void btnAlta_Click(object sender, RoutedEventArgs e)
        {
            VentanaAltaAula v = new VentanaAltaAula();
            v.Show();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificarAula v = new VentanaModificarAula();
            v.Show();
        }

        private void btnBaja_Click(object sender, RoutedEventArgs e)
        {
            VentanaEliminarAula v = new VentanaEliminarAula();
            v.Show();
        }
    }
}
