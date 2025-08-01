using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Poo
{
    public class Proveedor
    {
        public string nombre { get; set; }

        public string contacto { get; set; }

        public int telefono { get; set; }

        public string direccion { get; set; }
        public Proveedor(string nombre, string contacto, int telefono, string direccion)
        {
            this.nombre = nombre;
            this.contacto = contacto;
            this.telefono = telefono;
            this.direccion = direccion;
        }
        public override string ToString()
        {
            return $"{nombre} | {contacto} | {telefono} | {direccion}";
        }
    }
}
