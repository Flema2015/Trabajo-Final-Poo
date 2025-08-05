using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_Poo.Gestión_de_Rubros;
namespace Trabajo_Final_Poo.Gestión_de_movimientos
{
    public partial class Formulario_ingreso_stock : Form
    {
        private Gestion_producto gestion_De_Productos = new Gestion_producto();
        private Gestion_movimientos gestion_De_Movimientos = new Gestion_movimientos();
        private Gestion_proveedores gestion_Proveedores = new Gestion_proveedores();

        public Formulario_ingreso_stock()
        {
            InitializeComponent();

            var productos = gestion_De_Productos.Obtener_productos();
            foreach (var p in productos)
                cmbProducto.Items.Add(p.Nombre);

            var proveedores = gestion_Proveedores.Obtener_proveedores();
            foreach (var pr in proveedores)
                cmbProveedor.Items.Add(pr.nombre);
        }

        private void btnRegistrar_ingreso_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1 || cmbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un producto y un proveedor.");
                return;
            }

            string producto = cmbProducto.SelectedItem.ToString();
            string proveedor = cmbProveedor.SelectedItem.ToString();
            DateTime fecha = dtpFecha.Value;
            int cantidad = (int)nudcantidad.Value;

            gestion_De_Productos.actualizar_stock(producto, cantidad);
            Movimiento mov = new Movimiento(0,fecha, producto ,proveedor, cantidad, "");
            gestion_De_Movimientos.Agregar_movimiento(mov);

            lstLista_ingreso.Items.Add($"Producto: {producto} | Proveedor: {proveedor} | Cantidad: {cantidad} | Fecha: {fecha.ToShortDateString()}");
         
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
