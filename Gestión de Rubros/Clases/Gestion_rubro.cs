using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Poo.Gestión_de_Rubros.Clases
{
    public class Gestion_rubro
    {
        private static string archivo = "rubros.txt";

        public static List<Rubro> Obtener_rubros()
        {
            List<Rubro> rubros = new List<Rubro>();

            if (!File.Exists(archivo)) return rubros;

            using (StreamReader sr = new StreamReader(archivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        rubros.Add(new Rubro(linea.Trim()));
                    }
                }
            }

            return rubros;
        }


        public static void Guardar_rubro(Rubro rubro)
        {
            using (StreamWriter sw = new StreamWriter(archivo, append: true))
            {
                sw.WriteLine(rubro.ToString());
            }
        }

        public static void Alta_rubro()
        {
            Console.Write("Ingrese nombre del nuevo rubro: ");
            string nombre = Console.ReadLine();

            Rubro rubro = new Rubro(nombre);
            Guardar_rubro(rubro);

            Console.WriteLine("Rubro agregado.");
        }

        public static void Modificar_rubro()
        {
            var rubros = Obtener_rubros();
            Mostrar_rubros(rubros);

            Console.Write("Ingrese el nombre del rubro a modificar: ");
            string nombre = Console.ReadLine();

            var rubro = rubros.FirstOrDefault(r => r.Nombre == nombre);
            if (rubro == null)
            {
                Console.WriteLine("Rubro no encontrado.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            rubro.Nombre = Console.ReadLine();
            Guardar_rubro(rubro);

            Console.WriteLine("Rubro modificado.");
        }

        public static void Baja_rubro(List<Producto> productos)
        {
            var rubros = Obtener_rubros();
            Mostrar_rubros(rubros);

            Console.WriteLine("Ingrese Nombre del rubro a eliminar: ");
            string nombre = Console.ReadLine();

            if (productos.Any(p => p == nombre))
            {
                Console.WriteLine("No se puede eliminar un rubro con productos asociados.");
                return;
            }

            rubros = rubros.Where(r => r.Nombre != nombre).ToList();
            Guardar_rubro(rubros);
            Console.WriteLine("✅ Rubro eliminado.");
        }

        public static void Mostrar_rubros(List<Rubro> rubros = null)
        {
            rubros ??= Obtener_rubros();
            Console.WriteLine("Rubros disponibles:");
            foreach (var r in rubros)
            {
                Console.WriteLine($"{r.Id}. {r.Nombre}");
            }
        }
    }
}
