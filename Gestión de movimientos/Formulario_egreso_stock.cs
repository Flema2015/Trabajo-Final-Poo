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
    public partial class Formulario_egreso_stock : Form
    {
        private Gestion_producto gestion_De_Productos = new Gestion_producto();
        private Gestion_movimientos gestion_De_Movimientos = new Gestion_movimientos();
        
        public Formulario_egreso_stock()
        {
            InitializeComponent();

            var productos = gestion_De_Productos.Obtener_productos();
            foreach (var p in productos)
                cmbProducto.Items.Add(p.Nombre);
        }

        private void btnRegistrar_egreso_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1 || txtMotivo.Text == "")
            {
                MessageBox.Show("Selecciona un producto y completa el motivo.");
                return;
            }
            string producto = cmbProducto.SelectedItem.ToString();
            DateTime fecha = dtpFecha.Value;
            int cantidad = (int)nudcantidad.Value;
            string motivo = txtMotivo.Text.Trim();

            gestion_De_Productos.actualizar_stock_baja(producto, cantidad);
            Movimiento mov = new Movimiento(0, fecha, producto, "" ,cantidad, motivo);
            gestion_De_Movimientos.Agregar_movimiento(mov);

            lstLista_egreso.Items.Add($"Producto: {producto}  | Fecha: {fecha.ToShortDateString()} |  Cantidad: {cantidad} | Motivo: {motivo}");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
