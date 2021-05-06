using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
    /// Lógica de interacción para VentanaAlta.xaml
    /// </summary>
    public partial class VentanaAlta : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        public VentanaAlta()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtFecha.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            rdbtHombre.IsChecked = false;
            rdbtMujer.IsChecked = false;
            rdbtOtros.IsChecked = false;
            txtCurso.Text = String.Empty;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  void btnAlta_Click(object sender, RoutedEventArgs e)
        {
            Alumno alu = new Alumno();
            

            alu.nombre = txtNombre.Text;
            alu.apellidos = txtApellidos.Text;
            alu.telefono = Int32.Parse(txtTelefono.Text);
            alu.fecha_nac = txtFecha.Text;
            
            if(rdbtHombre.IsChecked == true)
            {
                alu.sexo = "Hombre";
            }

            if (rdbtMujer.IsChecked == true)
            {
                alu.sexo = "Mujer";
            }

            if (rdbtOtros.IsChecked == true)
            {
                alu.sexo = "Otros";
            }

            alu.curso = txtCurso.Text;

            PostCliente(alu, "http://localhost:3000/alumno");


            txtNombre.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtFecha.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            rdbtHombre.IsChecked = false;
            rdbtMujer.IsChecked = false;
            rdbtOtros.IsChecked = false;
            txtCurso.Text = String.Empty;


        }

        private async void PostCliente(Alumno alu, string path)
        {
            var json = JsonSerializer.Serialize<Alumno>(alu);
            var cabeceras = new StringContent(json, Encoding.UTF8, "application/json");

           

            HttpResponseMessage msg = await cliHttp.PostAsync(path, cabeceras);


            if (msg.IsSuccessStatusCode)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Alumno dado de alta", "Aviso", MessageBoxButton.OKCancel);
            }


            
        }

        private void validarNumero(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
