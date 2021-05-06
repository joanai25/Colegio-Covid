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
    /// Lógica de interacción para VentanaModificarAula.xaml
    /// </summary>
    public partial class VentanaModificarAula : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        List<Aula> aulas = new List<Aula>();
        string id = string.Empty;
        public VentanaModificarAula()
        {
            InitializeComponent();

            CargarComboBox(aulas);
        }

        private async void CargarComboBox(List<Aula> aula)
        {

            try
            {
                aula = await GetAulas("http://localhost:3000/aula");
            }
            catch
            {
                MessageBox.Show("No hay conexión");

            }


            foreach (Aula miAula in aula)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = miAula.nombre;
                item.Tag = miAula.id;

                cbAula.Items.Add(item);
            }

        }

        static async Task<List<Aula>> GetAulas(string path)
        {
            HttpResponseMessage msg = await cliHttp.GetAsync(path);
            List<Aula> aula = null;


            if (msg.IsSuccessStatusCode)
            {
                var salida = await msg.Content.ReadAsStringAsync();

                aula = JsonSerializer.Deserialize<List<Aula>>(salida);

            }

            return aula;
        }

        static async Task<Aula> GetAula(string path)
        {
            HttpResponseMessage msg = await cliHttp.GetAsync(path);
            Aula aula = null;


            if (msg.IsSuccessStatusCode)
            {
                var salida = await msg.Content.ReadAsStringAsync();

                aula = JsonSerializer.Deserialize<Aula>(salida);

            }

            return aula;
        }

        private void validarNumero(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            Aula aula = new Aula();
            var selectedTag = ((ComboBoxItem)cbAula.SelectedItem).Tag.ToString();
            id = selectedTag;

            try
            {
                aula = await GetAula("http://localhost:3000/aula/" + id);
            }
            catch
            {
                MessageBox.Show("No hay conexión");

            }

            

            txtNombre.Text = aula.nombre;
            txtPlanta.Text = Convert.ToString(aula.planta);
            txtCapacidad.Text = Convert.ToString(aula.capacidad);

            



        }

        private async void btnMod_Click(object sender, RoutedEventArgs e)
        {
            Aula aula = new Aula();


           

            aula.nombre = txtNombre.Text;
            aula.planta = Convert.ToInt32(txtPlanta.Text);
            aula.capacidad = Convert.ToInt32(txtCapacidad.Text);

          

            PatchAula(aula, "http://localhost:3000/aula/" + id);
            cbAula.Items.Refresh();

            txtNombre.Text = String.Empty;
            txtPlanta.Text = String.Empty;
            txtCapacidad.Text = String.Empty;
        }

        private async void PatchAula(Aula aula, string path)
        {
            var json = JsonSerializer.Serialize<Aula>(aula);
            var cabeceras = new StringContent(json, Encoding.UTF8, "application/json");



            HttpResponseMessage msg = await cliHttp.PatchAsync(path, cabeceras);


            if (msg.IsSuccessStatusCode)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Aula Modificada", "Aviso", MessageBoxButton.OKCancel);
            }




        }
    }
}
