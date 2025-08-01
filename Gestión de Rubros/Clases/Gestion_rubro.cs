using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Poo
{
    public class Gestion_rubro
    {
        public string ruta_archivo = "Rubros.txt";
        private readonly List<string> rubros_por_defecto = new List<string>()
        {
            "Electrónica",
            "Alimentos",
            "Indumentaria",
            
        };
        public List<string> cargar_rubros()
        {
            if (!File.Exists(ruta_archivo))
            {
                File.WriteAllLines(ruta_archivo, rubros_por_defecto);
                return new List<string>();
            }
            

            return File.ReadAllLines(ruta_archivo)
                       .Select(r => r.Trim())
                       .Where(r => !string.IsNullOrWhiteSpace(r))
                       .Distinct(StringComparer.OrdinalIgnoreCase)//elimina duplicados ignorando mayúsculas y minúsculas
                       .ToList();
        }

        public void agregar_rubro(string nuevo_rubro, string ruta_archivo, List<string> lista_rubros)
        {
            nuevo_rubro = nuevo_rubro.Trim();

            if (string.IsNullOrWhiteSpace(nuevo_rubro))
            {
                Console.WriteLine("No se puede agregar un rubro vacío.");
                return;
            }

            if (lista_rubros.Contains(nuevo_rubro, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ese rubro ya existe.");
                return;
            }

            File.AppendAllText(ruta_archivo, nuevo_rubro + Environment.NewLine);
            lista_rubros.Add(nuevo_rubro);

            Console.WriteLine($"Rubro '{nuevo_rubro}' agregado correctamente.");
        }
        public void eliminar_rubro(string nombre_rubro, string ruta_archivo, List<string> lista_rubros)
        {
            if (string.IsNullOrWhiteSpace(nombre_rubro))
            {
                Console.WriteLine("El nombre del rubro no puede estar vacío.");
                return;
            }

            if (!lista_rubros.Contains(nombre_rubro, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("El rubro no existe.");
                return;
            }

            lista_rubros.Remove(nombre_rubro);
            File.WriteAllLines(ruta_archivo, lista_rubros);

            Console.WriteLine($"Rubro '{nombre_rubro}' eliminado correctamente.");
        }
        public void mostrar_rubros(List<string> lista_rubros)
        {
            if (lista_rubros.Count == 0)
            {
                Console.WriteLine("No hay rubros disponibles.");
                return;
            }

            Console.WriteLine("Rubros disponibles:");
            foreach (var rubro in lista_rubros)
            {
                Console.WriteLine($"- {rubro}");
            }
        }

        public void modificar_rubro(string rubro_viejo, string rubro_nuevo)
        {
            var rubros = cargar_rubros();

            int index = rubros.FindIndex(r => r.Equals(rubro_viejo, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
                throw new InvalidOperationException("El rubro original no fue encontrado");
            rubros[index] = rubro_nuevo.Trim();
            File.WriteAllLines(ruta_archivo, rubros);
            Console.WriteLine($"Rubro '{rubro_viejo}' modificado correctamente a '{rubro_nuevo}'");
        }
    }
}
