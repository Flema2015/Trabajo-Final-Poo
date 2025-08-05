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
    public partial class Formulario_stock_por_producto : Form
    {
        Gestion_reportes gestor_reporte = new Gestion_reportes();
        public Formulario_stock_por_producto()
        {
            InitializeComponent();
            //lstStockDeProductos.DataSource = gestor_reporte.Stock_actual_por_producto();
            var lista_stock = gestor_reporte.Stock_actual_por_producto();
            lstStockDeProductos.Items.Clear();
            foreach (var item in lista_stock)
            {
                lstStockDeProductos.Items.Add(item);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
