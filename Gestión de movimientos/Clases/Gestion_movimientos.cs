using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final_Poo.Gestión_de_movimientos;

namespace Trabajo_Final_Poo.Gestión_de_Rubros
{
    public class Gestion_movimientos
    {
        private string rutaArchivo = "Movimientos.txt";

        public List<Movimiento> Obtener_movimientos()
        {
            var lista = new List<Movimiento>();
            if (!File.Exists(rutaArchivo))
                return lista;

            int idCounter = 1;
            foreach (var linea in File.ReadAllLines(rutaArchivo))
            {
                var p = linea.Split('|');
                if (p.Length == 7)
                {
                    var mov = new Movimiento(
                        idCounter++,
                        DateTime.Parse(p[0].Trim()),
                        p[1].Trim(),
                        p[2].Trim(),
                        int.Parse(p[3].Trim()),
                        p[4].Trim()
                    );
                    lista.Add(mov);
                }
            }
            return lista;
        }

        public void Guardar_todos(List<Movimiento> lista)
        {
            var lineas = lista.Select(m =>
                $"{m.Fecha:yyyy-MM-dd} |  {m.Producto}  | {m.Proveedor} | {m.Stock} | {m.Motivo}"
            );
            File.WriteAllLines(rutaArchivo, lineas);
        }

        public void Agregar_movimiento(Movimiento mov)
        {
            var lista = Obtener_movimientos();
            lista.Add(mov);
            Guardar_todos(lista);
        }


        

    }
}
