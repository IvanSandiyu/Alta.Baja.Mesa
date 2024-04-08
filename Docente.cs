using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1FinalProg2
{
    [Serializable]
    internal class Docente:Persona
    {
        string especialidad;
        public bool Asignado { get; set; }

        public Docente(string nombre, long dni, string especialidad) :base(nombre,dni)
        {
            this.especialidad = especialidad;
            Asignado = false;

        }
        public override string Descripcion()
        {
            return "Nombre: " + nombre  + " | " + "DNI: " + dni + " | " + "Especialidad: " + especialidad;
        }
        public string DescripcionProp => Descripcion();

    }
}
