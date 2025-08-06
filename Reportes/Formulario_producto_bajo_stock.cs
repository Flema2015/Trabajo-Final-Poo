using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_Poo.Reportes
{
    public partial class Formulario_producto_bajo_stock : Form
    {
        Gestion_producto gestion_Producto = new Gestion_producto();
        Gestion_reportes gestion_reportes = new Gestion_reportes();
        public Formulario_producto_bajo_stock()
        {
            InitializeComponent();
            cmbProducto.DataSource = gestion_Producto.Obtener_productos();
            cmbProducto.DisplayMember = "Nombre";

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un Producto.");
                return;
            }
            var productoSeleccionado = cmbProducto.SelectedItem.ToString();
            try
            {
                var producto_bajo_stock = gestion_reportes.Producto_con_bajo_stock();
                lstlista_stock_bajo.Items.Clear();
                foreach (var producto in producto_bajo_stock)
                {
                    lstlista_stock_bajo.Items.Add($"Producto: {producto.Nombre_producto}, Stock: {producto.cantidad_stock} " +
                        $"| El producto Está por debajo del umbral minimo de stock");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
