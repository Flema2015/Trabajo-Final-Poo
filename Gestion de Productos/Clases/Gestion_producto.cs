using System;

namespace Trabajo_Final_Poo
{
    public class Gestion_producto
    {
        private static string Ruta_archivo = "productos.txt";

        public void Alta_producto()
        {
            Console.WriteLine("Nombre de producto:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Descripción del producto:");
            string descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock");
            int stock = int.Parse(Console.ReadLine());
        }
    }
}