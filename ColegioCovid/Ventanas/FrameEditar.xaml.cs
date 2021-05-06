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
    /// Lógica de interacción para FrameEditar.xaml
    /// </summary>
    public partial class FrameEditar : Page
    {
        public FrameEditar()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FrameElegir.xaml", UriKind.Relative));
        }

        private void btnAlta_Click(object sender, RoutedEventArgs e)
        {
            VentanaAlta v = new VentanaAlta();
            v.Show();
            
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificar v = new VentanaModificar();
            v.Show();
        }

        private void btnBaja_Click(object sender, RoutedEventArgs e)
        {
            VentanaEliminar v = new VentanaEliminar();
            v.Show();
        }
    }
}
