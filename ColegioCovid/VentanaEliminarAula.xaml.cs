using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    /// Lógica de interacción para VentanaEliminarAula.xaml
    /// </summary>
    public partial class VentanaEliminarAula : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        List<Aula> aulas = new List<Aula>();
        string id = string.Empty;
        public VentanaEliminarAula()
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

                cbAulas.Items.Add(item);
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




        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var selectedTag = ((ComboBoxItem)cbAulas.SelectedItem).Tag.ToString();
            id = selectedTag;
            DeleteAula("http://localhost:3000/aula/" + id);
            cbAulas.Items.Clear();
            CargarComboBox(aulas);

        }

        private async void DeleteAula(string path)
        {

            HttpResponseMessage msg = await cliHttp.DeleteAsync(path);




            if (msg.IsSuccessStatusCode)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Aula eliminada", "Aviso", MessageBoxButton.OKCancel);
            }
            else
            {
                MessageBox.Show("error");
            }




        }
    }
}
