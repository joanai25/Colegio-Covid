using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ColegioCovid
{
    /// <summary>
    /// Lógica de interacción para VentanaAltaAula.xaml
    /// </summary>
    /// 

    

    public partial class VentanaAltaAula : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        public VentanaAltaAula()
        {
            InitializeComponent();
        }

        private async void PostCliente(Aula aula, string path)
        {
            var json = JsonSerializer.Serialize<Aula>(aula);
            var cabeceras = new StringContent(json, Encoding.UTF8, "application/json");



            HttpResponseMessage msg = await cliHttp.PostAsync(path, cabeceras);


            if (msg.IsSuccessStatusCode)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Aula dada de alta", "Aviso", MessageBoxButton.OKCancel);
            }



        }

        private void validarNumero(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = String.Empty;
            txtPlanta.Text = String.Empty;
            txtCapacidad.Text = String.Empty;
            
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAlta_Click(object sender, RoutedEventArgs e)
        {
            Aula aula = new Aula();


            aula.nombre = txtNombre.Text;
            aula.planta = Convert.ToInt32(txtPlanta.Text);
            aula.capacidad = Convert.ToInt32(txtCapacidad.Text);



            

            PostCliente(aula, "http://localhost:3000/aula");


            txtNombre.Text = String.Empty;
            txtPlanta.Text = String.Empty;
            txtCapacidad.Text = String.Empty;
        }
    }
}
