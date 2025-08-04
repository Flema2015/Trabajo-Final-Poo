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
    public partial class Formulario_modificar_proveedor : Form
    {
        Gestion_proveedores gestor_proveedores = new Gestion_proveedores();
        public Formulario_modificar_proveedor()
        {
            InitializeComponent();
            
        }

        private void btnBuscarProveedores_Click(object sender, EventArgs e)
        {
            lstProveedores.DataSource = gestor_proveedores.Obtener_proveedores();
            this.lstProveedores.SelectedIndexChanged += new System.EventHandler(this.lstProveedores_SelectedIndexChanged);
        }

        private void lstProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lstProveedores.SelectedItem is Proveedor proveedor)
            {
                txtNombre.Text = proveedor.nombre;
                txtContacto.Text = proveedor.contacto;
                txtTelefono.Text = proveedor.telefono.ToString();
                txtDireccion.Text = proveedor.direccion;
            }
        }

        private void ActualizarLista()
        {
            int idx = lstProveedores.SelectedIndex;
            lstProveedores.DataSource = null;
            lstProveedores.DataSource = gestor_proveedores.Obtener_proveedores();
            if (idx >= 0 && idx < lstProveedores.Items.Count)
                lstProveedores.SelectedIndex = idx;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstProveedores.SelectedItem is Proveedor proveedorOriginal)
                {
                    var proveedorModificado = new Proveedor(
                        txtNombre.Text,
                        txtContacto.Text,
                        int.Parse(txtTelefono.Text),
                        txtDireccion.Text
                    );

                    gestor_proveedores.Modificar_proveedor(proveedorOriginal.nombre, proveedorModificado);
                    ActualizarLista();
                    MessageBox.Show("Proveedor modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un proveedor para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstProveedores.SelectedItem is Proveedor proveedor)
                {
                    gestor_proveedores.Eliminar_proveedor(proveedor.nombre);
                    ActualizarLista();
                    MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un proveedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
