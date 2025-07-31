using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_Poo.Gestión_de_Rubros.Clases;

namespace Trabajo_Final_Poo
{
    internal class Producto
    {
        private string Nombre {  get; set; }
        private string Descripcion { get; set; }
        private decimal Precio { get; set; }
        private int Stock { get; set; }
        private Rubro Rubro { get; set; }

        public Producto(string nombre, string descripcion, decimal precio, int stock, Rubro rubro)
        { 
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Rubro = rubro; 
        }

        public override string ToString()
        {
            return $"{Nombre}|{Descripcion}|{Precio}|{Stock}|{Rubro.Nombre}";
        }
        public Rubro Obtener_rubro()
        {
            return Rubro;
        }
        public static Producto Desde_Linea(string linea, List<Rubro> rubros)
        {
            var partes = linea.Split('|');
            string rubro_nombre = partes[4].Trim();

            Rubro rubro = rubros.FirstOrDefault(r => r.Nombre.Equals(rubro_nombre, StringComparison.OrdinalIgnoreCase));
            if (rubro == null) rubro = new Rubro(rubro_nombre); // fallback si no se encuentra

            return new Producto(
                partes[0],
                partes[1],
                decimal.Parse(partes[2]),
                int.Parse(partes[3]),
                rubro
            );
        }

    }
}
