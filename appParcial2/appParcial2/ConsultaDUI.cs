using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appParcial2.Model;

namespace appParcial2
{
    public partial class ConsultaDUI : Form
    {
        public ConsultaDUI()
        {
            InitializeComponent();
            lblName.Visible = false;
            lblBenef.Visible = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Loguin L = new Loguin();
            L.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using (gobEntities1 db = new gobEntities1())
            {
                var verificar = from usuario in db.usuarios
                    where usuario.Dui == txtConsultar.Text
                    select usuario;

                if (verificar.Count() > 0)
                {
                    var nombreB = from usuario in db.usuarios
                        where usuario.Dui == txtConsultar.Text
                        select new
                        {
                            nombre = usuario.nombre.ToString()
                        };
                    foreach (var obtenerNombre in nombreB)
                    {
                        lblName.Text = obtenerNombre.nombre.ToString();

                        lblName.Visible = true;
                        lblBenef.Visible = true;
                    }
                }
                else
                {
                    lblName.Text = "Lo sentimos no eres beneficiario";
                    lblName.Visible = true;
                    lblBenef.Visible = false;
                }
            }
        }
    }
}
