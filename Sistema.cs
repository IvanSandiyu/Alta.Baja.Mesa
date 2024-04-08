using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1FinalProg2
{
    [Serializable]
    internal class Sistema
    {
        List<Persona> listaPersonas = new List<Persona>();
        List<Curso> listaCursos = new List<Curso>();
        Curso c;

        public void AgregarPersona(Persona unaPersona) 
        {
            listaPersonas.Add(unaPersona);
        }
        public bool CrearCurso(string nombre) 
        {
           
            int i = 0;
            bool condicion = true;
            Curso unCurso = new Curso(nombre);
            while (i < listaCursos.Count)
            {
                if (((Curso)listaCursos[i]).Nombre == nombre)
                {
                    condicion = false;
                    i = listaCursos.Count;
                }
                else i++;
            }
            listaCursos.Add(unCurso);
            c = unCurso;
            return condicion;

        }
        public void AsignarDocente(Docente unDocente) 
        {
            c.AsignarProfesor(unDocente);
  
        }
        public ArrayList DocentesDisponibles() 
        {
            ArrayList vD = new ArrayList() ;
            for (int i = 0; i < listaPersonas.Count; i++)
            {
                if (listaPersonas[i] is Docente) 
                {
                    if (((Docente)listaPersonas[i]).Asignado == false) 
                    {
                        vD.Add((Docente)listaPersonas[i]);
                    }
                }
            }
            return vD;
        }
       
        public void EliminarPersona(Persona unaPersona)
        {
            if (unaPersona is Docente docente)
            {
                Curso cursoAsignado = listaCursos.FirstOrDefault(curso => curso.Docente == docente);
                if (cursoAsignado != null)
                {
                    cursoAsignado.AsignarProfesor(null); 
                    listaCursos.Remove(cursoAsignado); 
                }
            }
            if(unaPersona is Alumno al)
            {
                c.EliminarAlumnoCurso(al);
                al.EliminarCurso(c);

            }
            listaPersonas.Remove(unaPersona);


        }
        //public Curso BuscarCurso(string nombre)
        //{
        //    Curso c= null;
        //    foreach (Curso curso in listaCursos)
        //    {
        //        if (curso.Nombre == nombre)
        //        {
        //            c = curso;
        //        }
        //    }
        //    return c;
        //}
        public void EliminarCurso(Curso c)
        {
            Docente docente = c.Docente;
            docente.Asignado = false;
            listaCursos.Remove(c);
            
           
        }
        public void AsignarAlumno(Alumno alumno,Curso unCurso)  
        {
            unCurso.AgregarAlumno(alumno);
        }
        public List<Persona> verPersonas() 
        {
            return listaPersonas;
        }
        public List<Curso> verCursos() 
        {
            return listaCursos;
        }
        //public Persona BuscarPersona(long dni)
        //{
        //    Persona per = null;
        //    foreach(Persona p in listaPersonas)
        //    {
        //        if(p.Dni == dni)
        //        {
        //            per = p;
        //        }
        //    }
        //    return per;
        //}
        
    }
}
