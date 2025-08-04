using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Poo
{
    public interface IRubroManager
    {
        List<string> CargarRubros();                // Crea archivo si no existe y devuelve rubros únicos
        List<string> ObtenerRubros(bool sinDuplicados = true);
        List<string> ObtenerRubrosOrdenados();      // Devuelve lista ordenada
        void AgregarRubro(string nuevoRubro);
        void EliminarRubro(string rubro);
        void ModificarRubro(string rubroViejo, string rubroNuevo);
    }

    public class Gestion_rubro : IRubroManager
    {
        private readonly string rutaArchivo = "Rubros.txt";
        private readonly List<string> rubrosPorDefecto = new List<string>
        {
            "Electrónica",
            "Alimentos",
            "Indumentaria"
        };

        // Carga inicial: crea archivo si no existe y devuelve lista sin duplicados
        public List<string> CargarRubros()
        {
            if (!File.Exists(rutaArchivo))
                File.WriteAllLines(rutaArchivo, rubrosPorDefecto);

            return LeerRubros(eliminarDuplicados: true);
        }

        // Lectura genérica, opcionalmente elimina duplicados
        public List<string> ObtenerRubros(bool sinDuplicados = true)
        {
            if (!File.Exists(rutaArchivo))
                return new List<string>();

            return LeerRubros(eliminarDuplicados: sinDuplicados);
        }

        // Versión ordenada alfabéticamente
        public List<string> ObtenerRubrosOrdenados()
        {
            return CargarRubros()
                   .OrderBy(r => r, StringComparer.OrdinalIgnoreCase)
                   .ToList();
        }

        public void AgregarRubro(string nuevoRubro)
        {
            var lista = CargarRubros();
            nuevoRubro = nuevoRubro.Trim();

            if (string.IsNullOrWhiteSpace(nuevoRubro))
                throw new ArgumentException("El rubro no puede estar vacío.");

            if (lista.Contains(nuevoRubro, StringComparer.OrdinalIgnoreCase))
                throw new InvalidOperationException("Ese rubro ya existe.");

            File.AppendAllText(rutaArchivo, nuevoRubro + Environment.NewLine);
        }

        public void EliminarRubro(string rubro)
        {
            var lista = CargarRubros();
            if (!lista.RemoveAll(r => r.Equals(rubro, StringComparison.OrdinalIgnoreCase)).Equals(1))
                throw new InvalidOperationException("El rubro no existe.");

            File.WriteAllLines(rutaArchivo, lista);
        }

        public void ModificarRubro(string rubroViejo, string rubroNuevo)
        {
            var lista = CargarRubros();
            int idx = lista.FindIndex(r => r.Equals(rubroViejo, StringComparison.OrdinalIgnoreCase));

            if (idx < 0)
                throw new InvalidOperationException("El rubro original no fue encontrado.");

            rubroNuevo = rubroNuevo.Trim();
            if (string.IsNullOrWhiteSpace(rubroNuevo))
                throw new ArgumentException("El nuevo rubro no puede estar vacío.");

            if (lista.Contains(rubroNuevo, StringComparer.OrdinalIgnoreCase))
                throw new InvalidOperationException("El rubro nuevo ya existe.");

            lista[idx] = rubroNuevo;
            File.WriteAllLines(rutaArchivo, lista);
        }

        // Método privado que centraliza la lectura
        private List<string> LeerRubros(bool eliminarDuplicados)
        {
            var lineas = File.ReadAllLines(rutaArchivo)
                             .Select(l => l.Trim())
                             .Where(l => !string.IsNullOrEmpty(l));

            if (eliminarDuplicados)
                lineas = lineas.Distinct(StringComparer.OrdinalIgnoreCase);

            return lineas.ToList();
        }
    }

    //public class Gestion_rubro
    //{
    //    public string ruta_archivo = "Rubros.txt";
    //    private readonly List<string> rubros_por_defecto = new List<string>()
    //    {
    //        "Electrónica",
    //        "Alimentos",
    //        "Indumentaria",

    //    };
    //    public List<string> cargar_rubros()
    //    {
    //        if (!File.Exists(ruta_archivo))
    //        {
    //            File.WriteAllLines(ruta_archivo, rubros_por_defecto);
    //            return new List<string>();
    //        }


    //        return File.ReadAllLines(ruta_archivo)
    //                   .Select(r => r.Trim())
    //                   .Where(r => !string.IsNullOrWhiteSpace(r))
    //                   .Distinct(StringComparer.OrdinalIgnoreCase)//elimina duplicados ignorando mayúsculas y minúsculas
    //                   .ToList();
    //    }

    //    public void agregar_rubro(string nuevo_rubro, string ruta_archivo, List<string> lista_rubros)
    //    {
    //        nuevo_rubro = nuevo_rubro.Trim();

    //        if (string.IsNullOrWhiteSpace(nuevo_rubro))
    //        {
    //            Console.WriteLine("No se puede agregar un rubro vacío.");
    //            return;
    //        }

    //        if (lista_rubros.Contains(nuevo_rubro, StringComparer.OrdinalIgnoreCase))
    //        {
    //            Console.WriteLine("Ese rubro ya existe.");
    //            return;
    //        }

    //        File.AppendAllText(ruta_archivo, nuevo_rubro + Environment.NewLine);
    //        lista_rubros.Add(nuevo_rubro);

    //        Console.WriteLine($"Rubro '{nuevo_rubro}' agregado correctamente.");
    //    }
    //    public void eliminar_rubro(string nombre_rubro, string ruta_archivo, List<string> lista_rubros)
    //    {
    //        if (string.IsNullOrWhiteSpace(nombre_rubro))
    //        {
    //            Console.WriteLine("El nombre del rubro no puede estar vacío.");
    //            return;
    //        }

    //        if (!lista_rubros.Contains(nombre_rubro, StringComparer.OrdinalIgnoreCase))
    //        {
    //            Console.WriteLine("El rubro no existe.");
    //            return;
    //        }

    //        lista_rubros.Remove(nombre_rubro);
    //        File.WriteAllLines(ruta_archivo, lista_rubros);

    //        Console.WriteLine($"Rubro '{nombre_rubro}' eliminado correctamente.");
    //    }

    //    public List<string> Obtener_rubros_desde_archivo(string ruta_archivo)
    //    {
    //        if (!File.Exists(ruta_archivo))
    //            return new List<string>(); // O podrías+ lanzar una excepción

    //        var rubros = File.ReadAllLines(ruta_archivo)
    //                         .Where(linea => !string.IsNullOrWhiteSpace(linea))
    //                         .Select(linea => linea.Trim())
    //                         .ToList();

    //        return rubros;
    //    }

    //    public void modificar_rubro(string rubro_viejo, string rubro_nuevo)
    //    {
    //        var rubros = cargar_rubros();

    //        int index = rubros.FindIndex(r => r.Equals(rubro_viejo, StringComparison.OrdinalIgnoreCase));
    //        if (index == -1)
    //            throw new InvalidOperationException("El rubro original no fue encontrado");
    //        rubros[index] = rubro_nuevo.Trim();
    //        File.WriteAllLines(ruta_archivo, rubros);
    //        Console.WriteLine($"Rubro '{rubro_viejo}' modificado correctamente a '{rubro_nuevo}'");
    //    }
    //}
}
