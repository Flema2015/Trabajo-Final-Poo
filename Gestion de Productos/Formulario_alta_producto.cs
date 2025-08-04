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
namespace Trabajo_Final_Poo
{
    public partial class Formulario_alta_producto : Form
    {
        const string CARPETA = "files";
        string ruta_archivo_producto = Path.Combine(CARPETA, "productos.txt");
        string ruta_archivo_rubros = Path.Combine(CARPETA, "rubros.txt");
        //List<Gestion_rubro> rubros = new List<Gestion_rubro>();
        Gestion_rubro gestion_rubro = new Gestion_rubro();

        public Formulario_alta_producto()
        {
            InitializeComponent();
            List<String> cargar_rubros = gestion_rubro.CargarRubros();
            cmbRubro.DataSource = cargar_rubros;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    var rubros = gestion_rubro.Obtener_rubros_desde_archivo(ruta_archivo_rubros);
        //    cmbRubro.Items.Add(rubros);
        //    cmbRubro.DataSource = gestion_rubro.cargar_rubros();
        //    cmbRubro.DisplayMember = "Nombre"; // Asegúrate de que la clase Rubro tenga una propiedad Nombre
                
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Gestion_producto gestion_Producto = new Gestion_producto();
            try
            {
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtdescripcion.Text.Trim();
                decimal precio_compra = decimal.Parse(txtPrecio.Text.Trim());
                int stock = int.Parse(txtStock.Text.Trim());
                string rubro = cmbRubro.SelectedItem?.ToString() ?? string.Empty;
                DateTime vencimiento = dtpVencimiento.Value.Date;

                Producto nuevo_producto = new Producto(nombre, descripcion, precio_compra, stock, rubro, vencimiento);

                // Validar si el rubro existe
                var rubros_validos = gestion_rubro.CargarRubros();
                gestion_Producto.Guardar_producto(nuevo_producto);

                MessageBox.Show("Producto agregado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}");
            }
            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult resultado = MessageBox.Show("¿Desea ingresar otro producto antes de cerrar este formulario?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                LimpiarCampos();
            }
            else
            {
                this.Close();
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
