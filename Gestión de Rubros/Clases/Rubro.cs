using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Poo.Gestión_de_Rubros.Clases
{
    public class Rubro
    {
        public string Nombre { get; set; }

        public Rubro(string nombre)
        {
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }

        public static Rubro DesdeLinea(string linea)
        {
            return new Rubro(linea.Trim());
        }

    }
}
