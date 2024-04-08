using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1FinalProg2
{
    [Serializable]
    abstract internal class Persona
    {
        protected string nombre;
        protected long dni;
        public long Dni { get { return dni; } }

        public Persona(string nombre, long dni)
        {
            this.nombre = nombre;
            this.dni = dni;
        }
        abstract public string Descripcion();

    }
}
