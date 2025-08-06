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
    public partial class Formulario_historial_movimientos_producto : Form
    {
        Gestion_producto gestion_producto = new Gestion_producto();
        Gestion_reportes gestion_Reportes = new Gestion_reportes();
        public Formulario_historial_movimientos_producto()
        {
            InitializeComponent();
            cmbProducto.DataSource = gestion_producto.Obtener_productos();
            cmbProducto.DisplayMember = "Nombre";

        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un Producto.");
                return;
            }

            var productoSeleccionado = ((Producto)cmbProducto.SelectedItem).Nombre;
            
            try
            {
                var historialMovimientos = gestion_Reportes.listar_movimientos_producto(productoSeleccionado);
                lstlista_stock_bajo.Items.Clear(); // Limpiar la lista antes de agregar nuevos elementos
                foreach (var mov in historialMovimientos)
                {
                    lstlista_stock_bajo.Items.Add($"Producto: {mov.Producto} | Fecha: {mov.Fecha}  |  {mov.Stock} ");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
