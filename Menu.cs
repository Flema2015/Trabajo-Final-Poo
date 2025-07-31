using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_Poo.Gestion_de_Productos;

namespace Trabajo_Final_Poo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void gestiónDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestiónDeMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gestiónDeReportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void productosDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_todos_los_productos"];
            if (form_open == null)
            {
                Formulario_todos_los_productos form_productos = new Formulario_todos_los_productos();
                form_productos.MdiParent = this;
                form_productos.Show();
            }
        }

        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_modificar_producto"];
            if (form_open == null)
            {
                Formulario_modificar_producto form_modificar = new Formulario_modificar_producto();
                form_modificar.MdiParent = this;
                form_modificar.Show();
            }
        }

        private void altaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // para poder abrirlo una sola vez
            Form form_open = Application.OpenForms["Formulario_alta_producto"];
            if (form_open == null)
            {
                Formulario_alta_producto form_alta = new Formulario_alta_producto();
                form_alta.MdiParent = this;
                form_alta.Show();
            }
        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_baja_producto"];
            if (form_open == null)
            {
                Formulario_baja_producto form_baja = new Formulario_baja_producto();
                form_baja.MdiParent = this;
                form_baja.Show();
            }
        }
    }
}
