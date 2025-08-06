using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_Poo.Integrantes
{
    public partial class Formulario_Emanuel : Form
    {
        public Formulario_Emanuel()
        {
            InitializeComponent();
            lst_Emanuel.Items.Add("Nombre: Emanuel Hamui");
            lst_Emanuel.Items.Add("Edad: 19 años");
            lst_Emanuel.Items.Add("Mail: Hamuiemanuel@gmail.com");
            lst_Emanuel.Items.Add("Nacionalidad: Argentina.");
            lst_Emanuel.Items.Add("Rol: Programador.");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
