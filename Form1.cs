using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej1FinalProg2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Sistema sistema = new Sistema();
        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            string nombre = Path.Combine(path, "datos.dat");
            FileStream fs = null;
           
            try
            {
                if (File.Exists(nombre))
                {
                    fs = new FileStream(nombre, FileMode.Open, FileAccess.Read);
                    if (fs.Length > 0)
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        sistema = (Sistema)bf.Deserialize(fs);
                        listBox1.Items.Add("Lista de cursos");
                        listBox1.Items.Clear();
                        ActualizarListBox();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                if (fs != null )
                {
                    fs.Close();

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Application.StartupPath;
            string nombre = Path.Combine(path, "datos.dat");
            FileStream fs = null;

            try
            {
                fs = new FileStream(nombre, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, sistema);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vCrearCurso crear = new vCrearCurso();
            
            foreach (Docente docentes in sistema.DocentesDisponibles())
            {
                crear.comboBox1.Items.Add(docentes);
               
            }
            crear.comboBox1.DisplayMember = "DescripcionProp";
           
            try
            {
                if (crear.ShowDialog() == DialogResult.OK)
                {
                    
                    if (crear.comboBox1.SelectedIndex != -1) 
                    {
                        string n = crear.textBox1.Text;
                        Docente docenteSeleccionado = (Docente)crear.comboBox1.SelectedItem;
                        if (sistema.CrearCurso(n))
                        {
                            sistema.AsignarDocente(docenteSeleccionado);
                        }
                        else MessageBox.Show("Ya existe un curso con ese nombre");
                       
                    }
 
                    ActualizarListBox();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vCrearPersona persona = new vCrearPersona();
            try
            {
                if (persona.ShowDialog() == DialogResult.OK)
                {
                    Persona unaPersona = null;
                    string nombre = persona.textBox1.Text;
                    long dni = Convert.ToInt64(persona.textBox2.Text);
                    if (persona.radioButton1.Checked)
                    {
                        int legajo = Convert.ToInt32(persona.textBox3.Text);
                        unaPersona = new Alumno(nombre, dni, legajo);
                    }
                    if (persona.radioButton2.Checked)
                    {
                        string especialidad = persona.textBox3.Text;
                        unaPersona = new Docente(nombre, dni, especialidad);
                    }
                    sistema.AgregarPersona(unaPersona);
                    listBox1.Items.Clear();
                    ActualizarListBox();


                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vAlumnoCurso vAlumnoCurso = new vAlumnoCurso();
            foreach(Persona al in sistema.verPersonas())
            {
                if(al is Alumno)
                {
                    vAlumnoCurso.comboBox1.Items.Add(al);
                }
                
            }
            vAlumnoCurso.comboBox1.DisplayMember = "DescripcionProp";
            foreach (Curso curso in sistema.verCursos())
            {
                vAlumnoCurso.comboBox2.Items.Add(curso);
            }
            vAlumnoCurso.comboBox2.DisplayMember = "DescripcionProp";

            try
            {
                Alumno alumno = null;
                Curso curso = null;
                if (vAlumnoCurso.ShowDialog() == DialogResult.OK)
                {
                    if (vAlumnoCurso.comboBox1.SelectedIndex != -1)
                    {
                        alumno = (Alumno)vAlumnoCurso.comboBox1.SelectedItem;
                    }
                    if (vAlumnoCurso.comboBox2.SelectedIndex != -1)
                    {
                        curso = (Curso)vAlumnoCurso.comboBox2.SelectedItem;
                    }
                    alumno.AgregarCurso(curso);
                    sistema.AsignarAlumno(alumno, curso);
                    listBox1.Items.Clear();
                    ActualizarListBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ActualizarListBox() 
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Lista de cursos");
            foreach (Curso c in sistema.verCursos())
            {
                listBox1.Items.Add(c);
            }
            listBox1.DisplayMember = "DescripcionProp";
            listBox1.Items.Add("---------------------------");
            listBox1.Items.Add("Lista de personas");
            foreach (Persona per in sistema.verPersonas())
            {
                listBox1.Items.Add(per);
            }
            listBox1.DisplayMember = "DescripcionProp";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Curso c in sistema.verCursos())
            {
                listBox1.Items.Add("---------------");
                listBox1.Items.Add(c);
                listBox1.DisplayMember = "DescripcionProp";
                foreach (Alumno a in c.listaAlumnos())
                {
                    listBox1.Items.Add(a);
                                                    
                }
                listBox1.DisplayMember = "DescripcionProp";

            }
           
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActualizarListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Persona p = listBox1.SelectedItem as Persona;
                MessageBox.Show(p.Descripcion(), " La persona a eliminar es : " );
                if (p != null) sistema.EliminarPersona(p);
                ActualizarListBox();
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                Curso curso = listBox1.SelectedItem as Curso;
                MessageBox.Show(curso.Descripcion(), "El curso a eliminar es : ");
                if (curso != null) sistema.EliminarCurso(curso);
                ActualizarListBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



           
        }
    }
}
