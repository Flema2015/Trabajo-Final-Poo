using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_Poo.Gestión_de_movimientos;
using Trabajo_Final_Poo.Gestion_de_Productos;
using Trabajo_Final_Poo.Gestión_de_Proveedores;
using Trabajo_Final_Poo.Gestión_de_Rubros;

namespace Trabajo_Final_Poo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void productosDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_todos_los_productos"];

            foreach (Form child in this.MdiChildren)
                child.Close();

            if (form_open == null)
            {
                Formulario_todos_los_productos form_productos = new Formulario_todos_los_productos();
                form_productos.MdiParent = this;
                form_productos.Dock = DockStyle.Fill;
                form_productos.FormBorderStyle = FormBorderStyle.None;
                form_productos.Show();
            }
        }

        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_modificar_producto"];

            foreach (Form child in this.MdiChildren)
                child.Close();

            if (form_open == null)
            {
                Formulario_modificar_producto form_modificar = new Formulario_modificar_producto();
                form_modificar.MdiParent = this;
                form_modificar.Dock = DockStyle.Fill;
                form_modificar.FormBorderStyle = FormBorderStyle.None;
                form_modificar.Show();
               
            }
        }

        private void altaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form form_open = Application.OpenForms["Formulario_alta_producto"];

            foreach (Form child in this.MdiChildren)
                child.Close();

            if (form_open == null)
            {

                Formulario_alta_producto form_alta = new Formulario_alta_producto();
                form_alta.MdiParent = this;
                form_alta.Show();
            }
        }

        //private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Form form_open = Application.OpenForms["Formulario_modificar_producto"];
        //    if (form_open == null)
        //    {
        //        Formulario_modificar_producto form_modificar = new Formulario_modificar_producto();
        //        form_modificar.MdiParent = this;
        //        form_modificar.Show();
        //    }
        //}

   


        private void altaProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_alta_proveedor"];

            foreach (Form child in this.MdiChildren)
                child.Close();

            if (form_open == null)
            {
                Formulario_alta_proveedor form_alta_proveedor = new Formulario_alta_proveedor();
                form_alta_proveedor.MdiParent = this;
                form_alta_proveedor.Dock = DockStyle.Fill;
                form_alta_proveedor.FormBorderStyle = FormBorderStyle.None;
                form_alta_proveedor.Show();
            }
        }

        private void modificarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_modificar_proveedor"];

            foreach (Form child in this.MdiChildren)
                child.Close();

            if (form_open == null)
            {
                Formulario_modificar_proveedor form_modificar_proveedor = new Formulario_modificar_proveedor();
                form_modificar_proveedor.MdiParent = this;
                form_modificar_proveedor.Dock = DockStyle.Fill;
                form_modificar_proveedor.FormBorderStyle = FormBorderStyle.None;
                form_modificar_proveedor.Show();
            }
        }


        private void ingresoDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_ingreso_stock"];
            if (form_open == null)
            {
                Formulario_ingreso_stock form_ingreso_stock = new Formulario_ingreso_stock();
                form_ingreso_stock.MdiParent = this;
                form_ingreso_stock.Show();
            }
        }

        private void egresoDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form_open = Application.OpenForms["Formulario_egreso_stock"];
            if (form_open == null)
            {
                Formulario_egreso_stock form_egreso_stock = new Formulario_egreso_stock();
                form_egreso_stock.MdiParent = this;
                form_egreso_stock.Show();
            }
        }
    }
}
