using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Entidad;
using Negocio;
namespace ProyectoFinal
{
    public partial class Master : Form
    {

        nUsuarios nusuarios = new nUsuarios();
        private BindingSource bindingSource1 = new BindingSource();
        public Master()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string sitlab = "";
            if (radioButton1.Checked == true) { sitlab = "Empleado"; } else if (radioButton2.Checked == true) { sitlab = "Desempleado"; }
            int cod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            nusuarios.Modificar(cod,
                tbNOMBRE.Text.ToString(),
                tbDNI.Text.ToString(),
                tbTLF.Text.ToString(),
                tbMAIL.Text.ToString(),
                tbDISTRI.Text.ToString(),
                sitlab);
            dataGridView1.AutoGenerateColumns = true;
            bindingSource1.DataSource = nusuarios.Listar();
            dataGridView1.DataSource = bindingSource1;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                       
            byte[] datos = new byte[0];
            tbNOMBRE.Text = dataGridView1.SelectedCells[1].Value.ToString();
            tbDNI.Text = dataGridView1.SelectedCells[2].Value.ToString();
            tbTLF.Text= dataGridView1.SelectedCells[3].Value.ToString();
            tbMAIL.Text=dataGridView1.SelectedCells[4].Value.ToString();
            tbDISTRI.Text= dataGridView1.SelectedCells[5].Value.ToString();          

            int cod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            lblcod.Text = cod.ToString();
            datos = nusuarios.VerFoto(cod);
            MemoryStream ms = new MemoryStream(datos);
            pictureBox1.Image = Bitmap.FromStream(ms);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            bindingSource1.DataSource = nusuarios.Listar();
            dataGridView1.DataSource = bindingSource1;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            nusuarios.Eliminar(cod);
            dataGridView1.AutoGenerateColumns = true;
            bindingSource1.DataSource = nusuarios.Listar();
            dataGridView1.DataSource = bindingSource1;

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }
        }
    }
}
