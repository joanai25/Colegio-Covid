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
    /// Lógica de interacción para VentanaEliminar.xaml
    /// </summary>
    public partial class VentanaEliminar : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        List<Alumno> alumnos = new List<Alumno>();
        string id = string.Empty;
        public VentanaEliminar()
        {
            InitializeComponent();
            CargarComboBox(alumnos);
        }

        private async void CargarComboBox(List<Alumno> alu)
        {

            try
            {
                alu = await GetAlumnos("http://localhost:3000/alumno");
            }
            catch
            {
                MessageBox.Show("No hay conexión");

            }


            foreach (Alumno miAlu in alu)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = miAlu.nombre;
                item.Tag = miAlu.id;

                cbAlumnos.Items.Add(item);
            }

        }

        static async Task<List<Alumno>> GetAlumnos(string path)
        {
            HttpResponseMessage msg = await cliHttp.GetAsync(path);
            List<Alumno> alu = null;


            if (msg.IsSuccessStatusCode)
            {
                var salida = await msg.Content.ReadAsStringAsync();

                alu = JsonSerializer.Deserialize<List<Alumno>>(salida);

            }

            return alu;
        }




        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var selectedTag = ((ComboBoxItem)cbAlumnos.SelectedItem).Tag.ToString();
            id = selectedTag;
            DeleteAlu("http://localhost:3000/alumno/" + id);
            cbAlumnos.Items.Clear();
            CargarComboBox(alumnos);

        }

        private async void DeleteAlu(string path)
        {

            HttpResponseMessage msg = await cliHttp.DeleteAsync(path);
            
            


            if (msg.IsSuccessStatusCode)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Alumno eliminado", "Aviso", MessageBoxButton.OKCancel);
            }
            else
            {
                MessageBox.Show("error");
            }
            



        }
    }
}
