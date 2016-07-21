namespace Terminal
{
    partial class TelaTerminal
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProjeto = new System.Windows.Forms.TextBox();
            this.lblRegistroOK = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLeitor = new System.Windows.Forms.TextBox();
            this.txtRegistroERRO = new System.Windows.Forms.TextBox();
            this.lblRelogio = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picFoto);
            this.groupBox1.Controls.Add(this.txtProjeto);
            this.groupBox1.Controls.Add(this.lblRegistroOK);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLeitor);
            this.groupBox1.Controls.Add(this.txtRegistroERRO);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtProjeto
            // 
            this.txtProjeto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProjeto.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjeto.Location = new System.Drawing.Point(231, 175);
            this.txtProjeto.Name = "txtProjeto";
            this.txtProjeto.Size = new System.Drawing.Size(535, 25);
            this.txtProjeto.TabIndex = 11;
            this.txtProjeto.TabStop = false;
            this.txtProjeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProjeto.Enter += new System.EventHandler(this.txtProjeto_Enter);
            // 
            // lblRegistroOK
            // 
            this.lblRegistroOK.AutoSize = true;
            this.lblRegistroOK.BackColor = System.Drawing.Color.LimeGreen;
            this.lblRegistroOK.Font = new System.Drawing.Font("Lucida Sans Unicode", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistroOK.Location = new System.Drawing.Point(187, 242);
            this.lblRegistroOK.Name = "lblRegistroOK";
            this.lblRegistroOK.Size = new System.Drawing.Size(438, 42);
            this.lblRegistroOK.TabIndex = 9;
            this.lblRegistroOK.Text = "CHAMADA REGISTRADA";
            this.lblRegistroOK.Visible = false;
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(231, 132);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(535, 30);
            this.txtNome.TabIndex = 8;
            this.txtNome.TabStop = false;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Apresente seu cartão ao leitor de código de barras";
            // 
            // txtLeitor
            // 
            this.txtLeitor.Location = new System.Drawing.Point(268, 88);
            this.txtLeitor.Name = "txtLeitor";
            this.txtLeitor.Size = new System.Drawing.Size(459, 20);
            this.txtLeitor.TabIndex = 3;
            this.txtLeitor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLeitor_KeyDown);
            // 
            // txtRegistroERRO
            // 
            this.txtRegistroERRO.BackColor = System.Drawing.Color.Tomato;
            this.txtRegistroERRO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegistroERRO.Font = new System.Drawing.Font("Lucida Sans Unicode", 26.25F, System.Drawing.FontStyle.Bold);
            this.txtRegistroERRO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRegistroERRO.Location = new System.Drawing.Point(121, 230);
            this.txtRegistroERRO.Name = "txtRegistroERRO";
            this.txtRegistroERRO.Size = new System.Drawing.Size(561, 54);
            this.txtRegistroERRO.TabIndex = 12;
            this.txtRegistroERRO.TabStop = false;
            this.txtRegistroERRO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegistroERRO.Visible = false;
            this.txtRegistroERRO.Enter += new System.EventHandler(this.txtRegistroERRO_Enter);
            // 
            // lblRelogio
            // 
            this.lblRelogio.AutoSize = true;
            this.lblRelogio.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelogio.Location = new System.Drawing.Point(451, 71);
            this.lblRelogio.Name = "lblRelogio";
            this.lblRelogio.Size = new System.Drawing.Size(276, 21);
            this.lblRelogio.TabIndex = 2;
            this.lblRelogio.Text = "00/00/0000 00:00:00";
            this.lblRelogio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTurno);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.lblRelogio);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 121);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtTurno
            // 
            this.txtTurno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTurno.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTurno.Location = new System.Drawing.Point(437, 29);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Size = new System.Drawing.Size(300, 30);
            this.txtTurno.TabIndex = 7;
            this.txtTurno.TabStop = false;
            this.txtTurno.Text = "TURNO VESPERTINO 2";
            this.txtTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Terminal.Properties.Resources.ifpr_logo;
            this.pictureBox1.Location = new System.Drawing.Point(11, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 96);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(12, 461);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 127);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(9, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(757, 102);
            this.txtLog.TabIndex = 0;
            this.txtLog.TabStop = false;
            // 
            // picFoto
            // 
            this.picFoto.InitialImage = global::Terminal.Properties.Resources.reitoria_vertical_1;
            this.picFoto.Location = new System.Drawing.Point(39, 20);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(135, 187);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 13;
            this.picFoto.TabStop = false;
            // 
            // TelaTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaTerminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal de Auto-Chamada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLeitor;
        private System.Windows.Forms.Label lblRelogio;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblRegistroOK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtProjeto;
        private System.Windows.Forms.TextBox txtRegistroERRO;
        private System.Windows.Forms.PictureBox picFoto;
    }
}