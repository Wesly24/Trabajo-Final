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
using System.Data.SqlClient;
using Entidad;
using Negocio;
namespace ProyectoFinal
{
    
    public partial class Empleador   : Form
    {
        nUsuarios nusuarios = new nUsuarios();
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        private BindingSource bindingSource3 = new BindingSource();
        private BindingSource bindingSource4 = new BindingSource();
        public Empleador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           byte[] datos = new byte[0];
           int a = Convert.ToInt32(dataGridView1.SelectedCells[18].Value.ToString());
           int b = Convert.ToInt32(dataGridView1.SelectedCells[19].Value.ToString());
           int c = Convert.ToInt32(dataGridView1.SelectedCells[20].Value.ToString());
           int sum = a + b + c;

           int cod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
           datos = nusuarios.VerFoto(cod);

           int val = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);

           MemoryStream ms = new MemoryStream(datos);
           pictureBox1.Image = Bitmap.FromStream(ms);

           LBTL.Text = dataGridView1.SelectedCells[3].Value.ToString();
           LBCR.Text = dataGridView1.SelectedCells[4].Value.ToString();
           LBDS.Text = dataGridView1.SelectedCells[5].Value.ToString();
           LBSL.Text = dataGridView1.SelectedCells[6].Value.ToString();
           LB1.Text = dataGridView1.SelectedCells[8].Value.ToString();
           LB2.Text = dataGridView1.SelectedCells[9].Value.ToString();
           LB3.Text = dataGridView1.SelectedCells[10].Value.ToString();
           LB4.Text = dataGridView1.SelectedCells[11].Value.ToString();
           lblptcn.Text = dataGridView1.SelectedCells[17].Value.ToString() + "/5";

            if (sum == 0 && dataGridView1.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
           else if (sum != 0 && dataGridView1.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION PERO HAY POSIBLE EXPOSICION"; }
           else if (sum == 0 && dataGridView1.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
           else if (sum != 0 && dataGridView1.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y HAY POSIBLE EXPOSICION"; }

           textBox1.Text =
               dataGridView1.SelectedCells[12].Value.ToString().Trim() + "  " +
               dataGridView1.SelectedCells[13].Value.ToString().Trim() + "  " +
               dataGridView1.SelectedCells[14].Value.ToString().Trim() + "  " +
               dataGridView1.SelectedCells[15].Value.ToString().Trim();

           textBox2.Text = dataGridView1.SelectedCells[7].Value.ToString().Trim();                  
        }

        private void btnLIST_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns=true;
            bindingSource1.DataSource = nusuarios.Listar();
            dataGridView1.DataSource = bindingSource1;
            
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
            {
                int puntuacion = 0;
                if (radioButton1.Checked) { puntuacion = 1; }
                if (radioButton2.Checked) { puntuacion = 2; }
                if (radioButton3.Checked) { puntuacion = 3; }
                if (radioButton4.Checked) { puntuacion = 4; }
                if (radioButton5.Checked) { puntuacion = 5; }
                int cod = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                nusuarios.Puntuar(puntuacion, cod);
                lblptcn.Text = puntuacion.ToString() + "/5";

                dataGridView1.AutoGenerateColumns = true;
                bindingSource1.DataSource = nusuarios.Listar();
                dataGridView1.DataSource = bindingSource1;
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos");
                }

            }
            else { MessageBox.Show("PUNTUACION NO SELECCIONADA"); }      


        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.AutoGenerateColumns = true;
            bindingSource2.DataSource = nusuarios.Listarpunt();
            dataGridView2.DataSource = bindingSource2;

            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] datos = new byte[0];
            int a = Convert.ToInt32(dataGridView2.SelectedCells[18].Value.ToString());
            int b = Convert.ToInt32(dataGridView2.SelectedCells[19].Value.ToString());
            int c = Convert.ToInt32(dataGridView2.SelectedCells[20].Value.ToString());
            int sum = a + b + c;

            int cod = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            datos = nusuarios.VerFoto(cod);

            int val = Convert.ToInt32(dataGridView2.SelectedCells[0].Value);

            MemoryStream ms = new MemoryStream(datos);
            pictureBox1.Image = Bitmap.FromStream(ms);

            LBTL.Text = dataGridView2.SelectedCells[3].Value.ToString();
            LBCR.Text = dataGridView2.SelectedCells[4].Value.ToString();
            LBDS.Text = dataGridView2.SelectedCells[5].Value.ToString();
            LBSL.Text = dataGridView2.SelectedCells[6].Value.ToString();
            LB1.Text =  dataGridView2.SelectedCells[8].Value.ToString();
            LB2.Text =  dataGridView2.SelectedCells[9].Value.ToString();
            LB3.Text =  dataGridView2.SelectedCells[10].Value.ToString();
            LB4.Text =  dataGridView2.SelectedCells[11].Value.ToString();
            lblptcn.Text = dataGridView2.SelectedCells[17].Value.ToString() + "/5";

            if (sum == 0 && dataGridView2.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
            else if (sum != 0 && dataGridView2.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION PERO HAY POSIBLE EXPOSICION"; }
            else if (sum == 0 && dataGridView2.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
            else if (sum != 0 && dataGridView2.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y HAY POSIBLE EXPOSICION"; }

            textBox1.Text =
                dataGridView2.SelectedCells[12].Value.ToString().Trim() + "  " +
                dataGridView2.SelectedCells[13].Value.ToString().Trim() + "  " +
                dataGridView2.SelectedCells[14].Value.ToString().Trim() + "  " +
                dataGridView2.SelectedCells[15].Value.ToString().Trim();

            textBox2.Text = dataGridView2.SelectedCells[7].Value.ToString().Trim();
        }

        private void btnFDESC_Click(object sender, EventArgs e)
        {
            if (tbcar.TextLength>0)
            {
                dataGridView3.AutoGenerateColumns = true;
                bindingSource3.DataSource = nusuarios.Buscarc(tbcar.Text.Trim().ToString());
                dataGridView3.DataSource = bindingSource3;

                if (dataGridView3.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos");
                }
            }
            else { MessageBox.Show("Campo no completado");}
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] datos = new byte[0];
            int a = Convert.ToInt32(dataGridView3.SelectedCells[18].Value.ToString());
            int b = Convert.ToInt32(dataGridView3.SelectedCells[19].Value.ToString());
            int c = Convert.ToInt32(dataGridView3.SelectedCells[20].Value.ToString());
            int sum = a + b + c;

            int cod = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value);
            datos = nusuarios.VerFoto(cod);

            int val = Convert.ToInt32(dataGridView3.SelectedCells[0].Value);

            MemoryStream ms = new MemoryStream(datos);
            pictureBox1.Image = Bitmap.FromStream(ms);

            LBTL.Text = dataGridView3.SelectedCells[3].Value.ToString();
            LBCR.Text = dataGridView3.SelectedCells[4].Value.ToString();
            LBDS.Text = dataGridView3.SelectedCells[5].Value.ToString();
            LBSL.Text = dataGridView3.SelectedCells[6].Value.ToString();
            LB1.Text =  dataGridView3.SelectedCells[8].Value.ToString();
            LB2.Text =  dataGridView3.SelectedCells[9].Value.ToString();
            LB3.Text = dataGridView3.SelectedCells[10].Value.ToString();
            LB4.Text = dataGridView3.SelectedCells[11].Value.ToString();
            lblptcn.Text = dataGridView3.SelectedCells[17].Value.ToString() + "/5";

            if (sum == 0 && dataGridView3.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
            else if (sum != 0 && dataGridView3.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION PERO HAY POSIBLE EXPOSICION"; }
            else if (sum == 0 && dataGridView3.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
            else if (sum != 0 && dataGridView3.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y HAY POSIBLE EXPOSICION"; }

            textBox1.Text =
                dataGridView3.SelectedCells[12].Value.ToString().Trim() + "  " +
                dataGridView3.SelectedCells[13].Value.ToString().Trim() + "  " +
                dataGridView3.SelectedCells[14].Value.ToString().Trim() + "  " +
                dataGridView3.SelectedCells[15].Value.ToString().Trim();

            textBox2.Text = dataGridView3.SelectedCells[7].Value.ToString().Trim();
        }

        private void btnDISTRI_Click(object sender, EventArgs e)
        {
            if (cbDIS.Text.Trim().Length > 0)
            {
                dataGridView4.AutoGenerateColumns = true;
                bindingSource4.DataSource = nusuarios.BuscarDis(cbDIS.Text.Trim().ToString());
                dataGridView4.DataSource = bindingSource4;

                if (dataGridView4.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos");
                }
            }
            else { MessageBox.Show("Seleccione una opcion valida"); }

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] datos = new byte[0];
            int a = Convert.ToInt32(dataGridView4.SelectedCells[18].Value.ToString());
            int b = Convert.ToInt32(dataGridView4.SelectedCells[19].Value.ToString());
            int c = Convert.ToInt32(dataGridView4.SelectedCells[20].Value.ToString());
            int sum = a + b + c;

            int cod = Convert.ToInt32(dataGridView4.SelectedRows[0].Cells[0].Value);
            datos = nusuarios.VerFoto(cod);

            int val = Convert.ToInt32(dataGridView4.SelectedCells[0].Value);

            MemoryStream ms = new MemoryStream(datos);
            pictureBox1.Image = Bitmap.FromStream(ms);

            LBTL.Text = dataGridView4.SelectedCells[3].Value.ToString();
            LBCR.Text = dataGridView4.SelectedCells[4].Value.ToString();
            LBDS.Text = dataGridView4.SelectedCells[5].Value.ToString();
            LBSL.Text = dataGridView4.SelectedCells[6].Value.ToString();
            LB1.Text = dataGridView4.SelectedCells[8].Value.ToString();
            LB2.Text = dataGridView4.SelectedCells[9].Value.ToString();
            LB3.Text = dataGridView4.SelectedCells[10].Value.ToString();
            LB4.Text = dataGridView4.SelectedCells[11].Value.ToString();
            lblptcn.Text = dataGridView4.SelectedCells[17].Value.ToString() + "/5";

            if (sum == 0 && dataGridView4.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
            else if (sum != 0 && dataGridView4.SelectedCells[21].Value != null) { lbvacu.Text = "CUENTA CON CERTIFICADO DE VACUNACION PERO HAY POSIBLE EXPOSICION"; }
            else if (sum == 0 && dataGridView4.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y NO HAY EXPOSICION"; }
            else if (sum != 0 && dataGridView4.SelectedCells[21].Value == null) { lbvacu.Text = "NO CUENTA CON CERTIFICADO DE VACUNACION Y HAY POSIBLE EXPOSICION"; }

            textBox1.Text =
                dataGridView4.SelectedCells[12].Value.ToString().Trim() + "  " +
                dataGridView4.SelectedCells[13].Value.ToString().Trim() + "  " +
                dataGridView4.SelectedCells[14].Value.ToString().Trim() + "  " +
                dataGridView4.SelectedCells[15].Value.ToString().Trim();

            textBox2.Text = dataGridView4.SelectedCells[7].Value.ToString().Trim();

        }
    }
}
