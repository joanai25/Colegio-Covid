using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para ListadoAlumnos.xaml
    /// </summary>
    public partial class ListadoAlumnos : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        List<Alumno> alumnos = new List<Alumno>();
        List<Aula> aulas = new List<Aula>();
        string id = string.Empty;
        List<int> id_alumnos = new List<int>();
        string prue = string.Empty;
        int [] ids = new int[0];
        

        public ListadoAlumnos()
        {
            InitializeComponent();
            cargarComboBox(alumnos, aulas);

            for(int i = 9; i <= 21; i++)
            {
                
                cbHora.Items.Add(i + ":00");
            }
            
        }

        private async void cargarComboBox(List<Alumno> alu, List<Aula> aula)
        {
            try
            {
                alu = await GetAlumnos("http://localhost:3000/alumno");
            }
            catch
            {
                MessageBox.Show("No hay conexión");

            }

            string[] cursos = new string[alu.Count];
            int i = 0;
            foreach (Alumno miAlu in alu)
            {
                cursos[i] = miAlu.curso;
                i++;
            }

            foreach (string curso in cursos.Distinct())
            {
                ComboBoxItem item = new ComboBoxItem();

                item.Content = curso;

                cbCurso.Items.Add(item);

            }


             
            

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

        private void btnSelecc_Click(object sender, RoutedEventArgs e)
        {
            List<Alumno> alu = new List<Alumno>();
            var curso = ((ComboBoxItem)cbCurso.SelectedItem).Content.ToString();
            cargarGrid(curso, alu);
            

        }

        private async void cargarGrid(string curso, List<Alumno> alu)
        {
            

            try
            {
                alu = await GetAlumnos("http://localhost:3000/alumno?curso="+curso);
            }
            catch
            {
                MessageBox.Show("No hay conexión");

            }
            
            listAlumnos.ItemsSource = alu;

            /*
            foreach(Alumno alux in listAlumnos.Items)
            {

            }

            
            DateTime dt = (DateTime) fecha.SelectedDate;
            prueba.Content = dt.ToShortDateString();*/
            

        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListChanged(object sender, SelectionChangedEventArgs e)
        {
            

            ListView list = sender as ListView;
            List<Alumno> id_alus = new List<Alumno>();

            ids = new int[list.SelectedItems.Count];


            for (int i = 0; i <  list.SelectedItems.Count; i++)
            {
                id_alus.Add(list.SelectedItems[i] as Alumno);
               
            }
            prue = string.Empty;

            for(int i = 0; i < ids.Length; i++)
            {
                ids[i] = id_alus[i].id;

                
                //prue += ids[i]+",";
            }
            
            
            
        }

        private async void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            Listado lista = new Listado();

            for(int i = 0; i < ids.Length; i++)
            {
                lista.id_alu = ids[i];
                var aula = ((ComboBoxItem)cbAula.SelectedItem).Tag.ToString();
                lista.id_aula = Convert.ToInt32(aula);
                DateTime dt = (DateTime)fecha.SelectedDate;
                lista.fecha = dt.ToShortDateString();
                //var hora_desde = ((ComboBoxItem)cbDesde.SelectedItem).Content.ToString();
                
                //var hora_hasta = ((ComboBoxItem)cbHasta.SelectedItem).Content.ToString();
                string hora_hasta = cbHora.SelectedItem.ToString();
                string hora = string.Empty;
                hora =  hora_hasta;
                lista.hora = hora;
                PostCliente(lista, "http://localhost:3000/listado");
            }
            MessageBox.Show("Se ha pasado lista");
            

        }


        private async void PostCliente(Listado lista, string path)
        {
            var json = JsonSerializer.Serialize<Listado>(lista);
            var cabeceras = new StringContent(json, Encoding.UTF8, "application/json");



            HttpResponseMessage msg = await cliHttp.PostAsync(path, cabeceras);

            /*
            if (msg.IsSuccessStatusCode)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Se ha pasado lista", "Aviso", MessageBoxButton.OKCancel);
            }*/

            


        }
    }
}
