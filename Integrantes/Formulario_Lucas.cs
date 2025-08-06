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
    public partial class Formulario_Lucas : Form
    {
        public Formulario_Lucas()
        {
            InitializeComponent();
            lst_Lucas.Items.Add("Nombre: Lucas Suleta");
            lst_Lucas.Items.Add("Edad: 25 años");
            lst_Lucas.Items.Add("Mail: SuletaLucas@hotmail.com");
            lst_Lucas.Items.Add("Nacionalidad: Argentina.");
            lst_Lucas.Items.Add("Rol: Programador.");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
