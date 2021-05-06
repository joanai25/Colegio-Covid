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
    /// Lógica de interacción para VentanaModificar.xaml
    /// </summary>
    public partial class VentanaModificar : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        List<Alumno> alumnos = new List<Alumno>();
        string id = string.Empty;
        public  VentanaModificar()
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
                item.Content = miAlu.nombre+"  "+miAlu.apellidos;
                item.Tag = miAlu.id;
                
                cbAlumno.Items.Add(item);
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

        static async Task<Alumno> GetAlumno(string path)
        {
            HttpResponseMessage msg = await cliHttp.GetAsync(path);
            Alumno alu = null;


            if (msg.IsSuccessStatusCode)
            {
                var salida = await msg.Content.ReadAsStringAsync();

                alu = JsonSerializer.Deserialize<Alumno>(salida);

            }

            return alu;
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
            Alumno alu = new Alumno();
            var selectedTag = ((ComboBoxItem)cbAlumno.SelectedItem).Tag.ToString();
            id = selectedTag;

            try
            {
                alu = await GetAlumno("http://localhost:3000/alumno/"+id);
            }
            catch
            {
                MessageBox.Show("No hay conexión");

            }

            txtNombre.Text = alu.nombre;
            txtApellidos.Text = alu.apellidos;
            txtTelefono.Text = Convert.ToString(alu.telefono);
            txtFecha.Text = alu.fecha_nac;
            
            switch(alu.sexo)
            {
                case "Hombre":
                    rdbtHombre.IsChecked = true;
                    break;
                case "Mujer":
                    rdbtMujer.IsChecked = true;
                    break;
                case "Otros":
                    rdbtOtros.IsChecked = true;
                    break;
            }
            txtCurso.Text = alu.curso;



        }

        private async void btnMod_Click(object sender, RoutedEventArgs e)
        {
            Alumno alu = new Alumno();


            alu.nombre = txtNombre.Text;
            alu.apellidos = txtApellidos.Text;
            alu.telefono = Int32.Parse(txtTelefono.Text);
            alu.fecha_nac = txtFecha.Text;

            if (rdbtHombre.IsChecked == true)
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

            PatchAlu(alu, "http://localhost:3000/alumno/" + id);
            cbAlumno.Items.Refresh();

            txtNombre.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtFecha.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            rdbtHombre.IsChecked = false;
            rdbtMujer.IsChecked = false;
            rdbtOtros.IsChecked = false;
            txtCurso.Text = String.Empty;
        }

        private async void PatchAlu(Alumno alu, string path)
        {
            var json = JsonSerializer.Serialize<Alumno>(alu);
            var cabeceras = new StringContent(json, Encoding.UTF8, "application/json");



            HttpResponseMessage msg = await cliHttp.PatchAsync(path, cabeceras);


            if (msg.IsSuccessStatusCode)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Alumno Modificado", "Aviso", MessageBoxButton.OKCancel);
            }
            



        }
    }
}
