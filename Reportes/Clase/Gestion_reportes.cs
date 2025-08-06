using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public Gestion_reportes()
        {
            gestion_producto = new Gestion_producto();
            gestion_proveedores = new Gestion_proveedores();
            gestion_rubro = new Gestion_rubro();
            gestion_Movimientos = new Gestion_movimientos();
        }
        public class Stock_info_producto
        {
            public string Nombre_producto { get; set; }
            public int cantidad_stock { get; set; }

            public override string ToString()
            {
                return $"Producto: {Nombre_producto}, Stock: {cantidad_stock}";
            }
        }

        public class Stock_info_rubro
        {
            public string Nombre_rubro { get; set; }
            public int cantidad_stock { get; set; }

            public override string ToString()
            {
                return $"Rubro: {Nombre_rubro}, Stock: {cantidad_stock}";
            }
        }

        public class IngresoProductoDto
        {
            public string Producto { get; set; }
            public DateTime Fecha { get; set; }
            public int Cantidad { get; set; }
            public string Proveedor { get; set; }
        }

        public List<Stock_info_producto> Stock_actual_por_producto()
        {
            var productos = gestion_producto.Obtener_productos();
            var resultado = new List<Stock_info_producto>();

            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return resultado;  // Devuelve lista vacía
            }

            foreach (var producto in productos)
            {
                resultado.Add(new Stock_info_producto
                {
                    Nombre_producto = producto.Nombre,    // Asegurate de usar la propiedad correcta
                    cantidad_stock = producto.Stock // O como se llame tu propiedad
                });
            }

            return resultado;
        }

        public List<Stock_info_rubro> Stock_actual_por_rubro(string rubroBuscado)
        {
            // Obtengo toda la lista
            var productos = gestion_producto.Obtener_productos();

            // Filtro por rubro y proyecto al DTO
            var resultado = productos
                .Where(p => p.Rubro.Equals(rubroBuscado, StringComparison.OrdinalIgnoreCase))
                .Select(p => new Stock_info_rubro
                {
                    Nombre_rubro = p.Rubro,  
                    cantidad_stock = p.Stock 
                })              
                .ToList();

            return resultado;
        }

        public List<IngresoProductoDto> Listar_ingresos_por_proveedor(string nombre_proveedor)
        {
            // Validar que el proveedor exista
            var proveedor = gestion_proveedores.Obtener_proveedor_por_nombre(nombre_proveedor);
            if (proveedor == null)
                throw new ArgumentException($"No se encontró un proveedor con nombre '{nombre_proveedor}'", nameof(nombre_proveedor));

            // Obtener movimientos y filtrar por tipo "Ingreso" y proveedor
            var movimientos = gestion_Movimientos.Obtener_movimientos()
                .Where(m => m.Proveedor == nombre_proveedor && m.Stock > 0) // Filtrar ingresos
                .Select(m => new IngresoProductoDto
                {
                    Producto = m.Producto,
                    Fecha = m.Fecha,
                    Cantidad = m.Stock,
                    Proveedor = m.Proveedor
                })
                .ToList();

            return movimientos;
        }

        public List<Stock_info_producto> Producto_con_bajo_stock()
        {
            var productos = gestion_producto.Obtener_productos();
            var resultado = new List<Stock_info_producto>();

            if (productos == null || productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return resultado;  // Devuelve lista vacía
            }

            foreach (var producto in productos)
            {
                if (producto.Stock <= 10)
                {
                    resultado.Add(new Stock_info_producto
                    {
                        Nombre_producto = producto.Nombre,    // Asegurate de usar la propiedad correcta
                        cantidad_stock = producto.Stock // O como se llame tu propiedad
                    });
                }
            }

            return resultado;
        }
        public List<Movimiento> listar_movimientos_producto(string nombre_producto)
        {

            var movimiento = gestion_Movimientos.Obtener_movimientos();
           
            return movimiento
                .Where(m => m.Producto == nombre_producto)
                .OrderBy(m => m.Fecha).ToList();
        }
    }
}
