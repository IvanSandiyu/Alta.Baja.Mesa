using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1FinalProg2
{
    [Serializable]
    internal class Curso
    {
        string nombre;
        public string Nombre { get { return nombre; } }
        public Docente Docente { get; private set; }
        List<Alumno> alumnos = new List<Alumno>();
        //public List<Alumno> listaAlumnos { get; }
        
        public Curso(string nombre) 
        {
            this.nombre = nombre;
        }
        public void AsignarProfesor(Docente unDocente) 
        {
            if (unDocente != null)
            {
                Docente = unDocente;
                Docente.Asignado = true;
            }
           
        }
      
        public void AgregarAlumno(Alumno unA) 
        {
            if (Docente != null) 
            {
                alumnos.Add(unA);
            }
            
        }
        public void EliminarAlumnoCurso(Alumno unaPersona)
        {
            
            alumnos.Remove(unaPersona);

        }
        public List<Alumno> listaAlumnos()
        {
            return alumnos.ToList<Alumno>();
        }
        public string Descripcion()
        {
            return " Curso: " + nombre + " | "  + Docente.Descripcion();
        }
        public string DescripcionProp => Descripcion();
    }
}
