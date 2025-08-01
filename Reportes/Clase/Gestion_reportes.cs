using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final_Poo.Gestión_de_movimientos;
using Trabajo_Final_Poo.Gestión_de_Rubros;

namespace Trabajo_Final_Poo
{
    public class Gestion_reportes
    {
        private readonly Gestion_producto gestion_producto;
        private readonly Gestion_proveedores gestion_proveedores;
        private readonly Gestion_rubro gestion_rubro;
        private readonly Gestion_movimientos gestion_Movimientos;

        public class Stock_info
        {
            public string Nombre_producto { get; set; }
            public int cantidad_stock { get; set; }
        }

        public class IngresoProductoDto
        {
            public string Producto { get; set; }
            public DateTime Fecha { get; set; }
            public int Cantidad { get; set; }
            public string Proveedor { get; set; }
        }

        public List<Stock_info> Stock_actual_por_producto()
        {
            var productos = gestion_producto.Obtener_productos();
            var resultado = new List<Stock_info>();

            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return resultado;  // Devuelve lista vacía
            }

            foreach (var producto in productos)
            {
                resultado.Add(new Stock_info
                {
                    Nombre_producto = producto.Nombre,    // Asegurate de usar la propiedad correcta
                    cantidad_stock = producto.Stock // O como se llame tu propiedad
                });
            }

            return resultado;
        }

        public List<Stock_info> Stock_actual_por_rubro(string rubroBuscado)
        {
            // Obtengo toda la lista
            var productos = gestion_producto.Obtener_productos()
                            ?? new List<Producto>();

            // Filtro por rubro y proyecto al DTO
            var resultado = productos
                .Where(p => p.Rubro.Equals(rubroBuscado, StringComparison.OrdinalIgnoreCase))
                .Select(p => new Stock_info
                {
                    Nombre_producto = p.Nombre,
                    cantidad_stock = p.Stock
                })
                .ToList();

            return resultado;
        }

        public List<string> Listar_envios_por_proveedor(string nombre_proveedor)
        {
            // 1. Validar que exista el proveedor (opcional)
            // Requiere un método en gestion_proveedores que busque por nombre.
            var proveedor = gestion_proveedores
                .Obtener_proveedor_por_nombre(nombre_proveedor);
            if (proveedor == null)
                throw new ArgumentException(
                    $"No se encontró un proveedor con nombre '{nombre_proveedor}'",
                    nameof(nombre_proveedor));

            // 2. Filtrar movimientos de tipo Ingreso para ese proveedor
            var movimientos = gestion_Movimientos.filtrar_por_proveedor(nombre_proveedor);
                

            // 3. Devolver una lista con el nombre del producto por cada envío
            return movimientos
                .Select(m => m.nombre_producto)
                .ToList();
        }


    }
}
