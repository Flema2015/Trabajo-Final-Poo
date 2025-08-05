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
        public string Proveedor { get; set; }
        public int Stock { get; set; }

        public Movimiento() { }

        public Movimiento(int id, DateTime fecha, string proveedor, int stock)
        {
            Id = id;
            Fecha = fecha;
            Proveedor = proveedor;
            Stock = stock;
        }

        public override string ToString()
        {
            // Esto ayudará si luego usás un ListBox sin DisplayMember
            return $"{Fecha:dd/MM/yyyy} | {Proveedor} | {Stock}";
        }

    }
}
