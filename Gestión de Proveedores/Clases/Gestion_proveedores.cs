using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Final_Poo
{
    public class Gestion_proveedores
    {
        public string ruta_archivo = "Proveedores.txt";
        public List<Proveedor> Obtener_proveedores()
        {
            var proveedores = new List<Proveedor>();

            if (!File.Exists(ruta_archivo))
                return proveedores;
            foreach (var linea in File.ReadAllLines(ruta_archivo))
            {
                var partes = linea.Split('|');

                if (partes.Length == 4)
                {
                    string nombre = partes[0].Trim();
                    string contacto = partes[1].Trim();
                    int telefono = int.Parse(partes[2].Trim());
                    string direccion = partes[3].Trim();
                    

                    proveedores.Add(new Proveedor(nombre, contacto, telefono, direccion));
                }
            }

            return proveedores;
        }

        public void Alta_proveedor(Proveedor nuevo_proveedor)
        {
            var proveedores = Obtener_proveedores();
            proveedores.Add(nuevo_proveedor);
            Guardar_proveedores(proveedores);
        }

        public void Modificar_producto(string nombre_viejo, Proveedor proveedor_modificado)
        {
            var proveedores = Obtener_proveedores();
            var index = proveedores.FindIndex(p => p.nombre.Equals(nombre_viejo, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
                throw new InvalidOperationException("El Proveedor no fue encontrado.");

            proveedores[index] = proveedor_modificado;
            Guardar_proveedores(proveedores);
        }
        public void Eliminar_proveedores(string nombre_proveedores)
        {
            var proveedores = Obtener_proveedores();
            var index = proveedores.FindIndex(p => p.nombre.Equals(nombre_proveedores, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
                throw new InvalidOperationException("El Proveedor no fue encontrado.");

            proveedores.RemoveAt(index);
            Guardar_proveedores(proveedores);
        }
        public void Guardar_proveedores(List<Proveedor> proveedores)
        {
            var lineas = proveedores.Select(p =>
                $"{p.nombre}|{p.contacto}|{p.telefono}|{p.direccion}"
            );
            File.WriteAllLines(ruta_archivo, lineas);
        }
        
        public Proveedor Obtener_proveedor_por_nombre(string nombre) =>
            Obtener_proveedores()
            .FirstOrDefault(p =>
                p.nombre.Equals(nombre,
                StringComparison.OrdinalIgnoreCase));
    }
}
