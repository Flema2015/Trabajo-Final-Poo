using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_Poo.Reportes
{
    public partial class Formulario_movimientos_por_proveedor : Form
    {
        Gestion_reportes gestor_reportes = new Gestion_reportes();
        
        public Formulario_movimientos_por_proveedor()
        {
            InitializeComponent();
            cmbProveedores.DataSource = new Gestion_proveedores().Obtener_proveedores();
            cmbProveedores.DisplayMember = "nombre";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string proveedorSeleccionado = cmbProveedores.SelectedItem.ToString();

            var movimientos = gestor_reportes.Listar_ingresos_por_proveedor(proveedorSeleccionado);

            foreach (var item in movimientos)
            {
                lstProductosPorProveedor.Items.Add(item);
            }

            //lstProductosPorProveedor.DataSource = movimientos;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
