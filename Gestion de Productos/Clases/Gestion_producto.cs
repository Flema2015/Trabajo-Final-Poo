using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Trabajo_Final_Poo.Gestión_de_Rubros;

namespace Trabajo_Final_Poo
{
    public class Gestion_producto
    {
        private readonly string ruta_archivo;
        private const string formato_fecha = "dd/MM/yyyy";

        public Gestion_producto(string nombre_archivo = "productos.txt")
        {
            ruta_archivo = Path.Combine(Application.StartupPath, nombre_archivo);
        }

        public void Agregar_producto(Producto producto)
        {
            string[] campos = new[]
            {
                producto.Nombre,
                producto.Descripcion,
                producto.PrecioCompra.ToString("F2"),
                producto.PrecioVenta.ToString("F2"),
                producto.Stock.ToString(),
                producto.Rubro,
                producto.FechaVencimiento.ToString(formato_fecha)
            };

            string linea = string.Join("|", campos);

            File.AppendAllText(ruta_archivo, linea + Environment.NewLine, Encoding.UTF8);
        }

        public List<Producto> Obtener_productos()
        { 
            var lista = new List<Producto>();

            if (!File.Exists(ruta_archivo))
                return lista;
            
            var lineas = File.ReadAllLines(ruta_archivo, Encoding.UTF8);

            foreach (var linea in lineas)
            {
                var partes = linea.Split('|');
                if (partes.Length < 7) 
                    continue;
                
                string nombre = partes[0].Trim();
                string descripcion = partes[1].Trim();
                if (!decimal.TryParse(partes[2].Trim(), out decimal precioCompra))
                    continue;
                if (!decimal.TryParse(partes[3].Trim(), out decimal precioVenta))
                    continue;
                if (!int.TryParse(partes[4].Trim(), out int stock))
                    continue;
                string rubro = partes[5].Trim();
                if (!DateTime.TryParseExact(partes[6].Trim(), formato_fecha, null, System.Globalization.DateTimeStyles.None, out DateTime fechaVencimiento))
                    continue;
                
                var producto = new Producto(nombre, descripcion, precioCompra, stock, rubro, fechaVencimiento);
                
                lista.Add(producto);
            }

            return lista;
        }

        public void Modificar_producto(Producto producto_modificado)
        {
            var productos = Obtener_productos();
            
            int index = productos.FindIndex(p => p.Nombre == producto_modificado.Nombre);
            
            if (index < 0)
                return;
           
            productos[index] = producto_modificado;

            var lineas = productos.Select(p =>
            {
                string[] campos = new[]
                {
                    p.Nombre,
                    p.Descripcion,
                    p.PrecioCompra.ToString("F2"),
                    p.PrecioVenta.ToString("F2"),
                    p.Stock.ToString(),
                    p.Rubro,
                    p.FechaVencimiento.ToString(formato_fecha)
                };
                return string.Join("|", campos);
            }).ToArray();

            File.WriteAllLines(ruta_archivo, lineas, Encoding.UTF8);

        }

        public void Eliminar_producto(string nombre_producto)
        {
            var productos = Obtener_productos();

            int index = productos.FindIndex(p => 
            p.Nombre.Equals(nombre_producto, StringComparison.OrdinalIgnoreCase));

            if (index < 0)
                return;

            productos.RemoveAt(index);

            var lineas = productos.Select(p =>
            {
                string[] campos = new[]
                {
                    p.Nombre,
                    p.Descripcion,
                    p.PrecioCompra.ToString("F2"),
                    p.PrecioVenta.ToString("F2"),
                    p.Stock.ToString(),
                    p.Rubro,
                    p.FechaVencimiento.ToString(formato_fecha)
                };
                return string.Join("|", campos);
            }).ToArray();

            File.WriteAllLines(ruta_archivo, lineas, Encoding.UTF8 );
        }

    }
}