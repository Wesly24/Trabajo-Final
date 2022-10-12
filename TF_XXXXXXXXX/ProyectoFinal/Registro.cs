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
    public partial class Registro : Form
    {
        nUsuarios nusuarios=new nUsuarios();
        
        public Registro()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();            
            if (result == DialogResult.OK)
            {
                pictureBox1.Image=Image.FromFile(openFileDialog.FileName);
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            int val = 0;
            int p1=0, p2=0, p3=0;
            MemoryStream memStream = new MemoryStream();
            
            string sitlab="";
            if (radioButton1.Checked == true) { sitlab="Empleado"; }else if(radioButton2.Checked == true) { sitlab="Desempleado"; }

            if (checkBox1.Checked) { p1 = 1; }
            if (checkBox2.Checked) { p1 = 0; }
            if (checkBox3.Checked) { p2 = 1; }
            if (checkBox4.Checked) { p2 = 0; }
            if (checkBox5.Checked) { p3 = 1; }
            if (checkBox6.Checked) { p3 = 0; }




            if (tbNOMBRE.Text.Trim().Length > 0&&tbDNI.Text.Trim().Length > 0&&tbTLF.Text.Trim().Length > 0&&cbDISTRITO.Text.Trim().Length>0)
            {
                if (!(pictureBox1.Image==null)) {
                    pictureBox1.Image.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    string respuesta = nusuarios.Insertar(tbNOMBRE.Text.Trim(), tbDNI.Text.Trim(), tbTLF.Text.Trim(), tbMAIL.Text.Trim(), cbDISTRITO.Text.Trim(), sitlab,
                    tbDESC.Text.Trim(), tbL1.Text.Trim(), tbL2.Text.Trim(), tbL3.Text.Trim(), tbL4.Text.Trim(), cbC1.Text.Trim(), cbC2.Text.Trim(), cbC3.Text.Trim(), cbC4.Text.Trim(),
                    memStream.GetBuffer(), val, p1, p2, p3, tbLink.Text.Trim());
                    Close();
                }
                else { MessageBox.Show("INGRESE SU FOTO"); }
            }
            else { MessageBox.Show("COMPLETE LOS DATOS");}
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
