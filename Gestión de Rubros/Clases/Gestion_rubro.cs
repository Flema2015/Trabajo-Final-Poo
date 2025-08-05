using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_Poo
{

    public class Gestion_rubro 
    {
        private readonly string ruta_archivo;
        
        private readonly List<string> rubrosPorDefecto = new List<string>
        {
            "Electrónica",
            "Alimentos",
            "Indumentaria"
        };
        
        public Gestion_rubro(string nombre_archivo = "rubros.txt")
        {
            ruta_archivo = Path.Combine(Application.StartupPath, nombre_archivo);
        }

        public List<string> ObtenerRubros()
        {
            if (!File.Exists(ruta_archivo))
            {
                File.WriteAllLines(ruta_archivo, rubrosPorDefecto, Encoding.UTF8);
                return new List<string>(rubrosPorDefecto);
            }
            
            return File
                .ReadAllLines(ruta_archivo, Encoding.UTF8)               
                .Select(r => r.Trim())
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .Distinct()
                .ToList();
        }

        public void Guardar_rubros(List<string> rubros)
        {
            File.WriteAllLines(ruta_archivo, rubros, Encoding.UTF8);
        }

        public void Agregar_rubro(string nuevoRubro)
        {
            var rubros = ObtenerRubros();
            if (!rubros.Contains(nuevoRubro, StringComparer.OrdinalIgnoreCase))
            {
                rubros.Add(nuevoRubro);
                Guardar_rubros(rubros);
            }
            else
            {
                MessageBox.Show("El rubro ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Eliminar_rubro(string rubro_a_eliminar)
        {
            var productos = new Gestion_producto().Obtener_productos();

            bool existe_asociado = productos
                .Any(p => p.Rubro.Equals(rubro_a_eliminar, StringComparison.OrdinalIgnoreCase));

            if (existe_asociado)
            {
                MessageBox.Show("No se puede eliminar el rubro porque hay productos asociados a él.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rubros = ObtenerRubros();

            if(!rubros.RemoveAll(r =>
                r.Equals(rubro_a_eliminar, StringComparison.OrdinalIgnoreCase)).Equals(0))
            {
                Guardar_rubros(rubros);
            }
            else
            {
                throw new InvalidOperationException("No se pudo eliminar el rubro. Verifique que exista.");
            }
        }
    }
}
