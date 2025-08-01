using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Trabajo_Final_Poo
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta => PrecioCompra * 1.5m; // Lógica de negocio
        public int Stock { get; set; }
        public string Rubro { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Producto(string nombre, string descripcion, decimal precioCompra, int stock, string rubro, DateTime vencimiento)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PrecioCompra = precioCompra;
            Stock = stock;
            Rubro = rubro;
            FechaVencimiento = vencimiento;
        }

        public override string ToString()
        {
            return $"{Nombre} | {Rubro} | ${PrecioVenta}";
        }
    }

}
