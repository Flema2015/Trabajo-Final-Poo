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
        const string CARPETA = "files";
        string ruta_archivo_producto = Path.Combine(CARPETA, "productos.txt");
        string ruta_archivo_rubros = Path.Combine(CARPETA, "rubros.txt");
        Gestion_rubro gestion_rubro = new Gestion_rubro();
        Gestion_producto gestion_Producto = new Gestion_producto();
        public Formulario_modificar_producto()
        {
            InitializeComponent();
            //if (lstProductos.SelectedItems != null)
            //{
            //    List<String> cargar_rubros = gestion_rubro.CargarRubros();
            //    cmbRubro.DataSource = cargar_rubros;
            //}
            
        }

        private void btnBuscar_producto_Click(object sender, EventArgs e)
        {
            if (cmbRubro.DataSource == null)
            {
                cmbRubro.DataSource = gestion_rubro.CargarRubros();
            }
            
            try
            {
                //string nombre = txtNombre.Text.Trim();
                //string descripcion = txtdescripcion.Text.Trim();
                //decimal precio_compra = decimal.Parse(txtPrecio.Text.Trim());
                //int stock = int.Parse(txtStock.Text.Trim());
                //string rubro = cmbRubro.SelectedItem?.ToString() ?? string.Empty;
                //DateTime vencimiento = dtpVencimiento.Value.Date;

                //Producto nuevo_producto = new Producto(nombre, descripcion, precio_compra, stock, rubro, vencimiento);

                // Validar si el rubro existe
                var rubros_validos = gestion_rubro.CargarRubros();
                
                //List<Producto> lista_productos = gestion_Producto.Obtener_productos();

                //lstProductos.DataSource = gestion_Producto.Obtener_productos();

                foreach (var p in gestion_Producto.Obtener_productos())
                {
                    string productos = $"{p.Nombre} | {p.Descripcion} | {p.PrecioCompra} | {p.Stock} | {p.Rubro} | {p.FechaVencimiento.ToShortDateString()} | ${p.PrecioVenta}";
                    lstProductos.Items.Add(productos);
                }
                //MessageBox.Show("Producto modificado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}");
            }
            
            //DialogResult resultado = MessageBox.Show("¿Desea ingresar otro producto antes de cerrar este formulario?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resultado == DialogResult.Yes)
            //{
            //    LimpiarCampos();
            //}
            //else
            //{
            //    this.Close();
            //}
        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProductos.SelectedItems != null)
            {
                //Gestion_producto gestion_Producto = new Gestion_producto();
                Producto producto = new Producto();
                producto = lstProductos.SelectedItem as Producto;
                if (producto != null)
                {
                    txtNombre.Text = producto.Nombre;
                    txtdescripcion.Text = producto.Descripcion;
                    txtPrecio.Text = producto.PrecioCompra.ToString();
                    txtStock.Text = producto.Stock.ToString();
                    cmbRubro.SelectedItem = producto.Rubro;
                    dtpVencimiento.Value = producto.FechaVencimiento;
                }

            }
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
