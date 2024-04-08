using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1FinalProg2
{
    [Serializable]
    internal class Alumno:Persona
    {

        int legajo;
         List<Curso> listaCursos = new List<Curso>();

        //ArrayList listaCursos = new ArrayList();

        public Alumno(string nombre, long dni, int legajo) : base(nombre,dni)
        {
            this.legajo = legajo;
        }
        public void AgregarCurso(Curso unCurso) 
        {
            listaCursos.Add(unCurso);
        }
        public void EliminarCurso(Curso unCurso)
        {
            listaCursos.Remove(unCurso);
        }
        public List<Curso> ListaCursos()
        {
            return listaCursos;
        }
        public override string Descripcion() 
        {
            return "Nombre:" + " " +  nombre + " | " + " DNI: " + dni + " | " +  "Legajo: " + legajo;
        }
        public string DescripcionProp => Descripcion();
    }
}
