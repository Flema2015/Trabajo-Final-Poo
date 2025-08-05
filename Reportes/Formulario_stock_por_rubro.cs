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
    public partial class Formulario_stock_por_rubro : Form
    {
        Gestion_reportes gestor_reportes = new Gestion_reportes();
        Gestion_rubro gestor_rubros = new Gestion_rubro();
        public Formulario_stock_por_rubro()
        {
            InitializeComponent();
            cmbRubros.DataSource = gestor_rubros.ObtenerRubros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string rubro = cmbRubros.Text.Trim();
            var lista_stock = gestor_reportes.Stock_actual_por_rubro(rubro);
            if (lista_stock == null || lista_stock.Count == 0)
            {
                MessageBox.Show("No se encontraron productos en el rubro especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int total_stock = lista_stock.Sum(item => item.cantidad_stock);

            lstStockPorRubro.Items.Clear();
            lstStockPorRubro.Items.Add($"Stock total en {rubro}: {total_stock}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
