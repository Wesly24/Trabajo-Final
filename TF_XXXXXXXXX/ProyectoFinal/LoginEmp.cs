using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class LoginEmp : Form
    {
        public LoginEmp()
        {
            InitializeComponent();
        }

        private void btnENTRAR_Click(object sender, EventArgs e)
        {          

            Empleador empleador = new Empleador();
            Master master=new Master();
            if (tbusr.Text.Trim() == "admin" && tbpass.Text.Trim() == "admin")
            {
                empleador.Show();
                Close();
            }else if (tbusr.Text.Trim() == "master" && tbpass.Text.Trim() == "master")
            {
                master.Show();
                Close();
            }
            else { MessageBox.Show("USUARIO Y/O CONTRASEÑA INCORRECTOS"); }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
