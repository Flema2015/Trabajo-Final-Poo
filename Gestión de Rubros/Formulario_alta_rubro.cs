using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_Poo.Gestión_de_Rubros
{
    public partial class Formulario_alta_rubro : Form
    {
        private Gestion_rubro gestion_rubro = new Gestion_rubro();
        public Formulario_alta_rubro()
        {
            InitializeComponent();
            lstRubros.DataSource = gestion_rubro.ObtenerRubros();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevoRubro = txtAgregarRubro.Text.Trim();
            if (string.IsNullOrEmpty(nuevoRubro))
            {
                MessageBox.Show("El nombre del rubro no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            gestion_rubro.Agregar_rubro(nuevoRubro);
            lstRubros.DataSource = gestion_rubro.ObtenerRubros();
            txtAgregarRubro.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var rubroSeleccionado = lstRubros.SelectedItem as string;
            if (rubroSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un rubro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult confirm = MessageBox.Show(
                $"¿Seguro quiere eliminar '{rubroSeleccionado}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
                {
                gestion_rubro.Eliminar_rubro(rubroSeleccionado);
                lstRubros.DataSource = gestion_rubro.ObtenerRubros();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
