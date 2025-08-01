﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trabajo_Final_Poo.Gestión_de_Rubros;

namespace Trabajo_Final_Poo
{
    public class Gestion_producto
    {
        public string ruta_archivo = "productos.txt";

        public List<Producto> Obtener_productos()
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

            var productos = Obtener_productos();
            productos.Add(nuevo_producto);
            Guardar_productos(productos);
        }

        public void Modificar_producto(string nombre_viejo, Producto producto_modificado)
        {
            var productos = Obtener_productos();
            var index = productos.FindIndex(p => p.Nombre.Equals(nombre_viejo, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
                throw new InvalidOperationException("El producto no fue encontrado.");

            productos[index] = producto_modificado;
            Guardar_productos(productos);
        }
        public void Eliminar_producto(string nombre_producto)
        {
            var productos = Obtener_productos();
            var index = productos.FindIndex(p => p.Nombre.Equals(nombre_producto, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
                throw new InvalidOperationException("El producto no fue encontrado.");

            productos.RemoveAt(index);
            Guardar_productos(productos);
        }
        public void Guardar_productos(List<Producto> productos)
        {
            var lineas = productos.Select(p =>
                $"{p.Nombre}|{p.Descripcion}|{p.PrecioCompra}|{p.Stock}|{p.Rubro}|{p.FechaVencimiento.ToShortDateString()}"
            );
            File.WriteAllLines(ruta_archivo, lineas);
        }
        //public void mostrar_productos(List<Producto> productos)
        //{
        //    if (productos.Count == 0)
        //    {
        //        Console.WriteLine("No hay productos disponibles.");
        //        return;
        //    }

        //    Console.WriteLine("Productos disponibles:");
        //    foreach (var producto in productos)
        //    {
        //        Console.WriteLine($"- {producto.Nombre} | {producto.Descripcion} | Precio: {producto.PrecioCompra:C} | Stock: {producto.Stock} | Rubro: {producto.Rubro} | Vencimiento: {producto.FechaVencimiento.ToShortDateString()}");
        //    }
        //}
    }
}