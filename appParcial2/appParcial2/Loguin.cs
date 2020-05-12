using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appParcial2.Vista;

namespace appParcial2
{
    public partial class Loguin : Form
    {
        public Loguin()
        {
            InitializeComponent();
        }

        private string user = "master";
        private string pass = "123";

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == user && txtPass.Text == pass)
            {
                Registros R = new Registros();
                R.Show();
            }
            else
            {
                MessageBox.Show("Las credenciales ingresadas no son validas");
            }
        }
    }
}
