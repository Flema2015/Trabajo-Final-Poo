using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_Poo.Gestión_de_Proveedores
{
    public partial class Formulario_alta_proveedor : Form
    {

        public Formulario_alta_proveedor()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Gestion_proveedores gestor_proveedores = new Gestion_proveedores();
            try { 
                string nombre = txtNombre.Text.Trim();
                string contacto = txtContacto.Text.Trim();
                int telefono = int.Parse(txtTelefono.Text.Trim());
                string direccion = txtDireccion.Text.Trim();

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contacto) || telefono <= 0 || string.IsNullOrEmpty(direccion))
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Proveedor nuevo_proveedor = new Proveedor(nombre, contacto, telefono, direccion);

                gestor_proveedores.Alta_proveedor(nuevo_proveedor);

                MessageBox.Show("Proveedor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DialogResult resultado = MessageBox.Show("¿Desea ingresar otro proveedor antes de cerrar este formulario?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            txtContacto.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
