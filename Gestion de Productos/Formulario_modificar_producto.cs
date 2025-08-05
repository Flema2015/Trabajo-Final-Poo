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
using Trabajo_Final_Poo.Gestion_de_Productos;
using Trabajo_Final_Poo.Gestión_de_Rubros;
namespace Trabajo_Final_Poo.Gestion_de_Productos
{
    public partial class Formulario_modificar_producto : Form
    {

        Gestion_rubro gestion_rubro = new Gestion_rubro();
        Gestion_producto gestion_producto = new Gestion_producto();
        public Formulario_modificar_producto()
        {
            InitializeComponent();
            lstProductos.SelectedIndexChanged += lstProductos_SelectedIndexChanged;
            cmbRubro.DataSource = gestion_rubro.ObtenerRubros();
        }

        private void btnBuscar_producto_Click(object sender, EventArgs e)
        {
            var productos = gestion_producto.Obtener_productos();
            
            lstProductos.DataSource = null;
            lstProductos.DisplayMember = "InfoCompleta";
            lstProductos.DataSource = productos;
        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lstProductos.SelectedItem is Producto producto_seleccionado)
            {
                txtNombre.Text = producto_seleccionado.Nombre;
                txtdescripcion.Text = producto_seleccionado.Descripcion;
                txtPrecio.Text = producto_seleccionado.PrecioCompra.ToString("N2");
                txtStock.Text = producto_seleccionado.Stock.ToString();
                cmbRubro.SelectedItem = producto_seleccionado.Rubro;
                dtpVencimiento.Value = producto_seleccionado.FechaVencimiento;
            }

        }

        private void Recargar_lista()
        {
            var lista = gestion_producto.Obtener_productos();

            lstProductos.DataSource = null;
            lstProductos.DisplayMember = "InfoCompleta";
            lstProductos.DataSource = lista;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var modificado = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtdescripcion.Text.Trim(),
                PrecioCompra = decimal.TryParse(txtPrecio.Text, out decimal precioCompra) ? precioCompra : 0,
                Stock = int.TryParse(txtStock.Text, out int stock) ? stock : 0,
                Rubro = cmbRubro.SelectedItem?.ToString() ?? string.Empty,
                FechaVencimiento = dtpVencimiento.Value
            };

            gestion_producto.Modificar_producto(modificado);

            Recargar_lista();
        }

        private void btnElimar_Click(object sender, EventArgs e)
        {
            Producto seleccionado = lstProductos.SelectedItem as Producto;

            if (seleccionado == null)
                return;

            DialogResult confirm = MessageBox.Show(
                $"¿Seguro quiere eliminar '{seleccionado.Nombre}'?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            gestion_producto.Eliminar_producto(seleccionado.Nombre);

            Recargar_lista();
        }
    }
}