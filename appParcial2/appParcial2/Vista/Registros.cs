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
using appParcial2.Model;

namespace appParcial2.Vista
{
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
            cargardatos();
        }
        usuario U = new usuario();
        void cargardatos()
        {
            dgvRegistros.Rows.Clear();
            using (gobEntities1 db = new gobEntities1())
            {
                var tb_Usuarios = db.usuarios;
                foreach (var iterardatostbUsuario in tb_Usuarios)
                {
                    dgvRegistros.Rows.Add(iterardatostbUsuario.id, iterardatostbUsuario.nombre, iterardatostbUsuario.Dui);
                }
                //dvgUsuarios.DataSource = db.tb_usuarios.ToList();
            }
        }
        void limpiardatos()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDUI.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (gobEntities1 db = new gobEntities1())
            {
                U.nombre = txtName.Text;
                U.Dui = txtDUI.Text;
                db.usuarios.Add(U);
                db.SaveChanges();
            }
            cargardatos();
            limpiardatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (gobEntities1 db = new gobEntities1())
            {
                string Id = dgvRegistros.CurrentRow.Cells[0].Value.ToString();

                U = db.usuarios.Find(int.Parse(Id));
                db.usuarios.Remove(U);
                db.SaveChanges();
            }
            cargardatos();
            limpiardatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (gobEntities1 db = new gobEntities1())
            {
                string Id = dgvRegistros.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                U = db.usuarios.Where(VerificarId => VerificarId.id == IdC).First();
                U.nombre = txtName.Text;
                U.Dui = txtDUI.Text;
                db.Entry(U).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            cargardatos();
            limpiardatos();
        }

        private void dgvDUI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Id = dgvRegistros.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dgvRegistros.CurrentRow.Cells[1].Value.ToString();
            String DUI = dgvRegistros.CurrentRow.Cells[2].Value.ToString();
            txtId.Text = Id;
            txtName.Text = Nombre;
            txtDUI.Text = DUI;
        }
    }
}
