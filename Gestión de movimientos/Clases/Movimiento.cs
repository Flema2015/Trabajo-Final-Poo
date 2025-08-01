using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Poo.Gestión_de_movimientos
{
    public enum TipoMovimiento
    {
        Ingreso,
        Egreso
    }

    public enum MotivoEgreso
    {
        Venta,
        Merma,
        Transferencia,
        Otro
    }

    public class Movimiento
    {
        public int Id { get; set; } // clave única

        public string nombre_producto { get; set; } // opcional, para mostrar sin join
        public TipoMovimiento Tipo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        // Datos específicos
        public string Proveedor { get; set; } // se usa solo en ingresos
        public MotivoEgreso? Motivo_egreso { get; set; } // se usa solo en egresos


        // Validación simple al crear
        public void Validar()
        {
            if (Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            if (Tipo == TipoMovimiento.Ingreso && string.IsNullOrWhiteSpace(Proveedor))
                throw new ArgumentException("El ingreso debe tener proveedor.");
            if (Tipo == TipoMovimiento.Egreso && Motivo_egreso == null)
                throw new ArgumentException("El egreso debe tener un motivo.");
        }
    }
}
