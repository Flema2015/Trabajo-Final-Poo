using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final_Poo.Gestión_de_movimientos;

namespace Trabajo_Final_Poo.Gestión_de_Rubros
{
    public class Gestion_movimientos
    {
        private readonly List<Movimiento> movimientos = new List<Movimiento>();
        private int next_id = 1;

        public void Agregar_movimiento(Movimiento m)
        {
            m.Validar();
            m.Id = next_id++;
            movimientos.Add(m);
        }

        public IEnumerable<Movimiento> Listar_todos() => movimientos;

        public IEnumerable<Movimiento> Filtrar_por_producto(string producto_nombre) =>
            movimientos.Where(m => m.nombre_producto == producto_nombre);

        public IEnumerable<Movimiento> Filtrar_por_tipo(TipoMovimiento tipo) =>
            movimientos.Where(m => m.Tipo == tipo);

        public IEnumerable<Movimiento> Filtrar_por_rango_de_fechas(DateTime desde, DateTime hasta) =>
            movimientos.Where(m => m.Fecha >= desde && m.Fecha <= hasta);

        public IEnumerable<Movimiento> filtrar_por_proveedor(string nombre_proveedor) =>
            movimientos.Where(m => m.Proveedor == nombre_proveedor);
        

        // Combinados
        public IEnumerable<Movimiento> Buscar(
            string producto_nombre = null,
            TipoMovimiento? tipo = null,
            DateTime? desde = null,
            DateTime? hasta = null)
        {
            var query = movimientos.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(producto_nombre))
                query = query.Where(m =>
                    !string.IsNullOrEmpty(m.nombre_producto) &&
                    m.nombre_producto.Contains(producto_nombre)); 
            if (tipo.HasValue)
                query = query.Where(m => m.Tipo == tipo.Value);
            if (desde.HasValue)
                query = query.Where(m => m.Fecha >= desde.Value);
            if (hasta.HasValue)
                query = query.Where(m => m.Fecha <= hasta.Value);
            return query;
        }
    }
}
