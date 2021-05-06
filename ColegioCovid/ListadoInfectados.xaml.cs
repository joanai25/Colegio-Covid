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
    /// Lógica de interacción para ListadoInfectados.xaml
    /// </summary>
    public partial class ListadoInfectados : Window
    {
        public static HttpClient cliHttp = new HttpClient();
        List<Alumno> alumnos = new List<Alumno>();
        public int idAlu = 0;
        List<Infectado> infectados = new List<Infectado>();
        public ListadoInfectados()
        {
            InitializeComponent();
            cargarComboBox(alumnos);

        }

        private async void cargarComboBox(List<Alumno> alu)
        {
            try
            {
                alu = await GetAlumnos("http://localhost:3000/alumno");
            }
            catch
            {
                MessageBox.Show("No hay conexión");

            }
            /*
            for (int i = 0; i < alu.Count; i++)
            {
                if (alu[i].curso.Equals(alu[i + 1].curso))
                {
                    alu.RemoveAt(i);
                    
                }
            }*/
            string[] cursos = new string[alu.Count];
            int i = 0;
            foreach(Alumno miAlu in alu)
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

        

        private async void cargarLista(string curso, List<Alumno> alu)
        {


            try
            {
                alu = await GetAlumnos("http://localhost:3000/alumno?curso=" + curso);
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

        private void curso_changed(object sender, SelectionChangedEventArgs e)
        {
            List<Alumno> alu = new List<Alumno>();
            var curso = ((ComboBoxItem)cbCurso.SelectedItem).Content.ToString();
            cargarLista(curso, alu);
        }

        private async void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            btnSeleccionar.Content = "Cargando...";
            gridContactos.ItemsSource = null;
            List<Listado> aula = new List<Listado>();
            
            //int id = idAlu;
            string fecha = calendario.SelectedDate.Value.Date.ToShortDateString();
            
            string[] fechas = new string[5];
            fechas[0] = fecha;
            for(int i = 0; i < 4; i++)
            {
                DateTime diaAnterior = calendario.SelectedDate.Value.Date.AddDays(-(i+1));
                fechas[i + 1] = diaAnterior.Date.ToShortDateString();
                
                
            }

            //MessageBox.Show(fechas[0]);
            for(int i = 0; i < fechas.Length; i++)
            {
                try
                {

                    aula = await GetListados("http://localhost:3000/listado?id_alu=" + idAlu + "&fecha=" + fechas[i]);//devuelve un listado
                }
                catch
                {
                    MessageBox.Show("error");

                }
                //MessageBox.Show("Tamaño" + aula.Count);
                if(aula.Count > 0)
                {
                    int idAula = aula[0].id_aula;
                    List<Listado> list = new List<Listado>();
                    list = await GetListados("http://localhost:3000/listado?id_aula=" + idAula + "&fecha=" + fechas[i]);//devuleve varios listados
                    int[] idAlus = new int[list.Count];
                    string[] horas = new string[list.Count];


                    for (int j = 0; j < list.Count; j++)
                    {
                        idAlus[j] = list[j].id_alu;
                        horas[j] = list[j].hora;
                    }

                    cargarGrid(fechas[i], idAlus, horas);
                }
               
            }
            //MessageBox.Show("id:" +idAlu+ "fecha"+ fecha);
            btnSeleccionar.Content = "Seleccionar";


        }

        private async void cargarGrid(string fecha, int [] idAlus, string [] horas)
        {
            
            
            
            
            for(int i = 0; i < idAlus.Length; i++)
            {
                Alumno alu = new Alumno();
                Infectado inf = new Infectado();
                try
                {
                    string ruta = "http://localhost:3000/alumno/" + idAlus[i];
                    alu = await GetAlumno(ruta);
                }
                catch
                {
                    MessageBox.Show("No hay conexión");
                    

                }




                inf.nombre = alu.nombre;
                inf.apellidos = alu.apellidos;
                inf.fecha = fecha;
                inf.hora = horas[i];

                infectados.Add(inf);
                if(idAlu == alu.id)
                {
                    infectados.Remove(inf);
                }
                
            }
            if(gridContactos.ItemsSource != null)
            {
                gridContactos.Items.Refresh();
            }
            else
            {
                
                gridContactos.ItemsSource = infectados;
            }


        }

        private void listaAlumnos_Changed(object sender, SelectionChangedEventArgs e)
        {
            ListView list = sender as ListView;
            Alumno alu = new Alumno();

            alu = listAlumnos.SelectedItem as Alumno;
            idAlu = alu.id;
            infectados = new List<Infectado>();
           
            
            //MessageBox.Show("el id es  "+idAlu);
        }

        static async Task<Listado> GetAula(string path)
        {
            HttpResponseMessage msg = await cliHttp.GetAsync(path);
            Listado list = null;


            if (msg.IsSuccessStatusCode)
            {
                var salida = await msg.Content.ReadAsStringAsync();

                list = JsonSerializer.Deserialize<Listado>(salida);


            }
            else
            {
                MessageBox.Show("error");
            }

            return list;
        }

        static async Task<List<Listado>> GetListados(string path)
        {
            HttpResponseMessage msg = await cliHttp.GetAsync(path);
            List<Listado> list = null;


            if (msg.IsSuccessStatusCode)
            {
                var salida = await msg.Content.ReadAsStringAsync();

                list = JsonSerializer.Deserialize<List<Listado>>(salida);

            }

            return list;
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
    }
}
