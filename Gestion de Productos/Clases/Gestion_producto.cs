using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trabajo_Final_Poo.Gestión_de_Rubros;

namespace Trabajo_Final_Poo
{
    public class Gestion_producto
    {
        public string ruta_archivo = "productos.txt";

        public List<Producto> cargar_productos()
        {
            var productos = new List<Producto>();

            if (!File.Exists(ruta_archivo))
                return productos;
            foreach (var linea in File.ReadAllLines(ruta_archivo))
            {
                var partes = linea.Split('|');

                if (partes.Length == 6)
                {
                    string nombre = partes[0].Trim();
                    string descripcion = partes[1].Trim();
                    decimal precio_compra = decimal.Parse(partes[2].Trim());
                    int stock = int.Parse(partes[3].Trim());
                    string rubro = partes[4].Trim();
                    DateTime vencimiento = DateTime.Parse(partes[5].Trim());

                    productos.Add(new Producto(nombre, descripcion, precio_compra, stock, rubro, vencimiento));
                }
            }

            return productos;
        }
        public void Alta_producto(Producto nuevo_producto, List<string> rubros_validos)
        {
            if (!rubros_validos.Contains(nuevo_producto.Rubro, StringComparer.OrdinalIgnoreCase))
                throw new InvalidOperationException("El rubro asignado al producto no existe.");

            var productos = cargar_productos();
            productos.Add(nuevo_producto);
            guardar_productos(productos);
        }
        //public void alta_producto(Producto nuevo_producto)
        //{

        //    var rubrosValidos = 

        //    if (!rubrosValidos.Contains(nuevo_producto.Rubro, StringComparer.OrdinalIgnoreCase))
        //        throw new InvalidOperationException("El rubro asignado al producto no existe.");

        //    var productos = cargar_productos();

        //    // Podés validar que no se repita el nombre si querés
        //    productos.Add(nuevo_producto);
        //    guardar_productos(productos);

        //}

        public List<Producto> Obtener_productos(List<string> rubros)
        {
            var productos = new List<Producto>();

            if (!File.Exists(ruta_archivo)) return productos;
            foreach (var linea in File.ReadAllLines(ruta_archivo))
            {
                if (!string.IsNullOrWhiteSpace(linea))
                {
                    productos.Add((linea, rubros));
                }
            }
            return productos;
        }
        public void Modificar_producto(string nombre_viejo, Producto producto_modificado)
        {
            var productos = cargar_productos();
            var index = productos.FindIndex(p => p.Nombre.Equals(nombre_viejo, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
                throw new InvalidOperationException("El producto no fue encontrado.");

            productos[index] = producto_modificado;
            guardar_productos(productos);
        }

        //public void Modificar_producto(List<string> rubros)
        //{
        //    var productos = Obtener_productos(rubros);
        //    Mostrar_productos(productos, rubros);

        //    Console.Write("Ingrese el nombre del producto a modificar: ");
        //    string nombre = Console.ReadLine();
        //    if (string.IsNullOrWhiteSpace(nombre))
        //    {
        //        Console.WriteLine("El nombre del producto no puede estar vacío.");
        //        return;
        //    }

        //    var producto = productos.FirstOrDefault(r => r.Obtener_nombre() == nombre);
        //    if (producto == null)
        //    {
        //        Console.WriteLine("producto no encontrado.");
        //        return;
        //    }

        //    Console.WriteLine("Ingrese el nuevo nombre del producto: ");
        //    string nombre_nuevo = Console.ReadLine().Trim();
        //    if (!string.IsNullOrEmpty(nombre_nuevo))
        //    {
        //        if (productos.Any(r => string.Equals(r.Obtener_nombre(), nombre_nuevo, StringComparison.OrdinalIgnoreCase)))
        //        {
        //            Console.WriteLine("ya existe el rubro con ese nombre.");
        //            return;
        //        }
        //        string nombre_viejo = producto.Obtener_nombre();
        //        nombre_viejo = nombre_nuevo;
        //    }

        //    guardar_productos(productos);

        //    Console.WriteLine("Rubro modificado.");
        //}

        public void Mostrar_productos(List<Producto> productos, List<string> rubros)
        {
            if (productos == null)
            {
                productos = Obtener_productos(rubros);
            }
            Console.WriteLine("Productos disponibles:");
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.Obtener_nombre()}");
            }
        }

        public void guardar_productos(List<Producto> productos)
        {
            var lineas = productos.Select(p =>
                $"{p.Nombre}|{p.Descripcion}|{p.PrecioCompra}|{p.Stock}|{p.Rubro}|{p.FechaVencimiento.ToShortDateString()}"
            );
            File.WriteAllLines(ruta_archivo, lineas);
        }

    }
}