using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Trabajo_Final_Poo.Gestión_de_Rubros;
using Trabajo_Final_Poo.Gestion_de_Productos;
namespace Trabajo_Final_Poo
{
    public partial class Formulario_alta_producto : Form
    {

        string ruta_archivo_producto = Path.Combine(Application.StartupPath, "productos.txt");
        string ruta_archivo_rubros = Path.Combine(Application.StartupPath, "rubros.txt");
        Gestion_rubro gestion_rubro = new Gestion_rubro();

        public Formulario_alta_producto()
        {
            InitializeComponent();
            List<String> cargar_rubros = gestion_rubro.CargarRubros();
            cmbRubro.DataSource = cargar_rubros;
        }        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var producto = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtdescripcion.Text.Trim(),
                PrecioCompra = decimal.TryParse(txtPrecio.Text.Trim(), out var precioCompra) ? precioCompra : 0,
                Stock = int.TryParse(txtStock.Text.Trim(), out var stock) ? stock : 0,
                Rubro = cmbRubro.SelectedItem?.ToString() ?? "",
                FechaVencimiento = dtpVencimiento.Value
            };

            var gestor = new Gestion_producto();
            gestor.Agregar_producto(producto);
            MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtdescripcion.Text = "";
            txtStock.Text = "";
            cmbRubro.SelectedIndex = -1;
            dtpVencimiento.Value = DateTime.Now;
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
