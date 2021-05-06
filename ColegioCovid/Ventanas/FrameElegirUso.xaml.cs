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
    /// Lógica de interacción para FrameElegirUso.xaml
    /// </summary>
    public partial class FrameElegirUso : Page
    {
        public FrameElegirUso()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListadoAlumnos list = new ListadoAlumnos();
            list.Show();
        }

        private void btnInfectados_Click(object sender, RoutedEventArgs e)
        {
            ListadoInfectados list = new ListadoInfectados();
            list.Show();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ventanas/FramePrincipal.xaml", UriKind.Relative));
        }
    }
}
