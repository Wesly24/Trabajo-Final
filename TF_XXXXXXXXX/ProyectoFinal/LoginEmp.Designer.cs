namespace ProyectoFinal
{
    partial class LoginEmp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbusr = new System.Windows.Forms.TextBox();
            this.tbpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnENTRAR = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbusr
            // 
            this.tbusr.Location = new System.Drawing.Point(34, 39);
            this.tbusr.Name = "tbusr";
            this.tbusr.Size = new System.Drawing.Size(212, 22);
            this.tbusr.TabIndex = 0;
            // 
            // tbpass
            // 
            this.tbpass.Location = new System.Drawing.Point(34, 99);
            this.tbpass.Name = "tbpass";
            this.tbpass.PasswordChar = '*';
            this.tbpass.Size = new System.Drawing.Size(212, 22);
            this.tbpass.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(87, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "CONTRASEÑA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(104, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "USUARIO";
            // 
            // btnENTRAR
            // 
            this.btnENTRAR.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnENTRAR.Location = new System.Drawing.Point(50, 144);
            this.btnENTRAR.Margin = new System.Windows.Forms.Padding(4);
            this.btnENTRAR.Name = "btnENTRAR";
            this.btnENTRAR.Size = new System.Drawing.Size(172, 31);
            this.btnENTRAR.TabIndex = 59;
            this.btnENTRAR.Text = "ENTRAR";
            this.btnENTRAR.UseVisualStyleBackColor = true;
            this.btnENTRAR.Click += new System.EventHandler(this.btnENTRAR_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(262, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 36);
            this.button1.TabIndex = 60;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnENTRAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbpass);
            this.Controls.Add(this.tbusr);
            this.Name = "LoginEmp";
            this.Text = "Login Empleador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbusr;
        private System.Windows.Forms.TextBox tbpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnENTRAR;
        private System.Windows.Forms.Button button1;
    }
}