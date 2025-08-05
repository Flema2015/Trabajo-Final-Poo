using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Poo.Gestión_de_movimientos
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public string Producto { get; set; }
        public string Proveedor { get; set; }
        public int Stock { get; set; }

        public string Motivo { get; set; } // Para egresos, si es necesario
        public Movimiento() { }

        public Movimiento(int id, DateTime fecha, string producto, string proveedor, int stock, string motivo)
        {
            Id = id;
            Fecha = fecha;
            Producto = producto;
            Proveedor = proveedor;
            Stock = stock;
            Motivo = motivo;
        }

        public override string ToString()
        {
            // Esto ayudará si luego usás un ListBox sin DisplayMember
            return $"{Fecha:dd/MM/yyyy} | {Producto} | {Proveedor} | {Stock} | {Motivo}";
        }

    }
}
