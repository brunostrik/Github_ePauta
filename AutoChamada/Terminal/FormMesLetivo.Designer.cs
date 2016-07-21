namespace Terminal
{
    partial class FormMesLetivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMesLetivo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGerarMatutino = new System.Windows.Forms.Button();
            this.listMatutino = new System.Windows.Forms.ListBox();
            this.lblRemoveMatutino = new System.Windows.Forms.LinkLabel();
            this.cbxMatSab = new System.Windows.Forms.CheckBox();
            this.cbxMatSex = new System.Windows.Forms.CheckBox();
            this.cbxMatQui = new System.Windows.Forms.CheckBox();
            this.cbxMatQua = new System.Windows.Forms.CheckBox();
            this.cbxMatTer = new System.Windows.Forms.CheckBox();
            this.cbxMatSeg = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listFeriados = new System.Windows.Forms.ListBox();
            this.lblRemoveFeriado = new System.Windows.Forms.LinkLabel();
            this.lblAddFeriado = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGerarVespertinoA = new System.Windows.Forms.Button();
            this.listVespertinoA = new System.Windows.Forms.ListBox();
            this.lblRemoveVespertinoA = new System.Windows.Forms.LinkLabel();
            this.cbxVespASab = new System.Windows.Forms.CheckBox();
            this.cbxVespASex = new System.Windows.Forms.CheckBox();
            this.cbxVespAQui = new System.Windows.Forms.CheckBox();
            this.cbxVespAQua = new System.Windows.Forms.CheckBox();
            this.cbxVespATer = new System.Windows.Forms.CheckBox();
            this.cbxVespASeg = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGerarVespertinoB = new System.Windows.Forms.Button();
            this.listVespertinoB = new System.Windows.Forms.ListBox();
            this.lblRemoveVespertinoB = new System.Windows.Forms.LinkLabel();
            this.cbxVespBSab = new System.Windows.Forms.CheckBox();
            this.cbxVespBSex = new System.Windows.Forms.CheckBox();
            this.cbxVespBQui = new System.Windows.Forms.CheckBox();
            this.cbxVespBQua = new System.Windows.Forms.CheckBox();
            this.cbxVespBTer = new System.Windows.Forms.CheckBox();
            this.cbxVespBSeg = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 77);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Terminal.Properties.Resources.ifpr_logo;
            this.pictureBox1.InitialImage = global::Terminal.Properties.Resources.ifpr_logo;
            this.pictureBox1.Location = new System.Drawing.Point(16, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(475, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(392, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Assistente Gerador de Período Letivo - Chamada";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGerarMatutino);
            this.groupBox2.Controls.Add(this.listMatutino);
            this.groupBox2.Controls.Add(this.lblRemoveMatutino);
            this.groupBox2.Controls.Add(this.cbxMatSab);
            this.groupBox2.Controls.Add(this.cbxMatSex);
            this.groupBox2.Controls.Add(this.cbxMatQui);
            this.groupBox2.Controls.Add(this.cbxMatQua);
            this.groupBox2.Controls.Add(this.cbxMatTer);
            this.groupBox2.Controls.Add(this.cbxMatSeg);
            this.groupBox2.Location = new System.Drawing.Point(231, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 358);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Turno Matutino";
            // 
            // btnGerarMatutino
            // 
            this.btnGerarMatutino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarMatutino.Image = global::Terminal.Properties.Resources.table_gear;
            this.btnGerarMatutino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarMatutino.Location = new System.Drawing.Point(137, 28);
            this.btnGerarMatutino.Name = "btnGerarMatutino";
            this.btnGerarMatutino.Size = new System.Drawing.Size(62, 24);
            this.btnGerarMatutino.TabIndex = 27;
            this.btnGerarMatutino.Text = "Gerar";
            this.btnGerarMatutino.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarMatutino.UseVisualStyleBackColor = true;
            this.btnGerarMatutino.Click += new System.EventHandler(this.btnGerarMatutino_Click);
            // 
            // listMatutino
            // 
            this.listMatutino.FormattingEnabled = true;
            this.listMatutino.Location = new System.Drawing.Point(11, 173);
            this.listMatutino.Name = "listMatutino";
            this.listMatutino.Size = new System.Drawing.Size(188, 173);
            this.listMatutino.TabIndex = 11;
            // 
            // lblRemoveMatutino
            // 
            this.lblRemoveMatutino.AutoSize = true;
            this.lblRemoveMatutino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveMatutino.Location = new System.Drawing.Point(149, 157);
            this.lblRemoveMatutino.Name = "lblRemoveMatutino";
            this.lblRemoveMatutino.Size = new System.Drawing.Size(50, 13);
            this.lblRemoveMatutino.TabIndex = 12;
            this.lblRemoveMatutino.TabStop = true;
            this.lblRemoveMatutino.Text = "Remover";
            this.lblRemoveMatutino.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemoveMatutino_LinkClicked);
            // 
            // cbxMatSab
            // 
            this.cbxMatSab.AutoSize = true;
            this.cbxMatSab.Location = new System.Drawing.Point(11, 143);
            this.cbxMatSab.Name = "cbxMatSab";
            this.cbxMatSab.Size = new System.Drawing.Size(63, 17);
            this.cbxMatSab.TabIndex = 10;
            this.cbxMatSab.Text = "Sábado";
            this.cbxMatSab.UseVisualStyleBackColor = true;
            // 
            // cbxMatSex
            // 
            this.cbxMatSex.AutoSize = true;
            this.cbxMatSex.Location = new System.Drawing.Point(11, 120);
            this.cbxMatSex.Name = "cbxMatSex";
            this.cbxMatSex.Size = new System.Drawing.Size(79, 17);
            this.cbxMatSex.TabIndex = 9;
            this.cbxMatSex.Text = "Sexta-Feira";
            this.cbxMatSex.UseVisualStyleBackColor = true;
            // 
            // cbxMatQui
            // 
            this.cbxMatQui.AutoSize = true;
            this.cbxMatQui.Location = new System.Drawing.Point(11, 97);
            this.cbxMatQui.Name = "cbxMatQui";
            this.cbxMatQui.Size = new System.Drawing.Size(83, 17);
            this.cbxMatQui.TabIndex = 8;
            this.cbxMatQui.Text = "Quinta-Feira";
            this.cbxMatQui.UseVisualStyleBackColor = true;
            // 
            // cbxMatQua
            // 
            this.cbxMatQua.AutoSize = true;
            this.cbxMatQua.Location = new System.Drawing.Point(11, 74);
            this.cbxMatQua.Name = "cbxMatQua";
            this.cbxMatQua.Size = new System.Drawing.Size(84, 17);
            this.cbxMatQua.TabIndex = 7;
            this.cbxMatQua.Text = "Quarta-Feira";
            this.cbxMatQua.UseVisualStyleBackColor = true;
            // 
            // cbxMatTer
            // 
            this.cbxMatTer.AutoSize = true;
            this.cbxMatTer.Location = new System.Drawing.Point(11, 51);
            this.cbxMatTer.Name = "cbxMatTer";
            this.cbxMatTer.Size = new System.Drawing.Size(80, 17);
            this.cbxMatTer.TabIndex = 6;
            this.cbxMatTer.Text = "Terça-Feira";
            this.cbxMatTer.UseVisualStyleBackColor = true;
            // 
            // cbxMatSeg
            // 
            this.cbxMatSeg.AutoSize = true;
            this.cbxMatSeg.Location = new System.Drawing.Point(11, 28);
            this.cbxMatSeg.Name = "cbxMatSeg";
            this.cbxMatSeg.Size = new System.Drawing.Size(95, 17);
            this.cbxMatSeg.TabIndex = 5;
            this.cbxMatSeg.Text = "Segunda-Feira";
            this.cbxMatSeg.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFim);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listFeriados);
            this.groupBox1.Controls.Add(this.lblRemoveFeriado);
            this.groupBox1.Controls.Add(this.lblAddFeriado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 358);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações de Geração";
            // 
            // listFeriados
            // 
            this.listFeriados.FormattingEnabled = true;
            this.listFeriados.Location = new System.Drawing.Point(12, 170);
            this.listFeriados.Name = "listFeriados";
            this.listFeriados.Size = new System.Drawing.Size(188, 173);
            this.listFeriados.TabIndex = 4;
            // 
            // lblRemoveFeriado
            // 
            this.lblRemoveFeriado.AutoSize = true;
            this.lblRemoveFeriado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveFeriado.Location = new System.Drawing.Point(150, 154);
            this.lblRemoveFeriado.Name = "lblRemoveFeriado";
            this.lblRemoveFeriado.Size = new System.Drawing.Size(50, 13);
            this.lblRemoveFeriado.TabIndex = 3;
            this.lblRemoveFeriado.TabStop = true;
            this.lblRemoveFeriado.Text = "Remover";
            this.lblRemoveFeriado.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // lblAddFeriado
            // 
            this.lblAddFeriado.AutoSize = true;
            this.lblAddFeriado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddFeriado.Location = new System.Drawing.Point(93, 154);
            this.lblAddFeriado.Name = "lblAddFeriado";
            this.lblAddFeriado.Size = new System.Drawing.Size(51, 13);
            this.lblAddFeriado.TabIndex = 2;
            this.lblAddFeriado.TabStop = true;
            this.lblAddFeriado.Text = "Adicionar";
            this.lblAddFeriado.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddFeriado_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Feriados";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGerarVespertinoA);
            this.groupBox3.Controls.Add(this.listVespertinoA);
            this.groupBox3.Controls.Add(this.lblRemoveVespertinoA);
            this.groupBox3.Controls.Add(this.cbxVespASab);
            this.groupBox3.Controls.Add(this.cbxVespASex);
            this.groupBox3.Controls.Add(this.cbxVespAQui);
            this.groupBox3.Controls.Add(this.cbxVespAQua);
            this.groupBox3.Controls.Add(this.cbxVespATer);
            this.groupBox3.Controls.Add(this.cbxVespASeg);
            this.groupBox3.Location = new System.Drawing.Point(445, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 358);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Turno Vespertino A";
            // 
            // btnGerarVespertinoA
            // 
            this.btnGerarVespertinoA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarVespertinoA.Image = global::Terminal.Properties.Resources.table_gear;
            this.btnGerarVespertinoA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarVespertinoA.Location = new System.Drawing.Point(137, 28);
            this.btnGerarVespertinoA.Name = "btnGerarVespertinoA";
            this.btnGerarVespertinoA.Size = new System.Drawing.Size(62, 24);
            this.btnGerarVespertinoA.TabIndex = 28;
            this.btnGerarVespertinoA.Text = "Gerar";
            this.btnGerarVespertinoA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarVespertinoA.UseVisualStyleBackColor = true;
            this.btnGerarVespertinoA.Click += new System.EventHandler(this.btnGerarVespertinoA_Click);
            // 
            // listVespertinoA
            // 
            this.listVespertinoA.FormattingEnabled = true;
            this.listVespertinoA.Location = new System.Drawing.Point(11, 173);
            this.listVespertinoA.Name = "listVespertinoA";
            this.listVespertinoA.Size = new System.Drawing.Size(188, 173);
            this.listVespertinoA.TabIndex = 18;
            // 
            // lblRemoveVespertinoA
            // 
            this.lblRemoveVespertinoA.AutoSize = true;
            this.lblRemoveVespertinoA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveVespertinoA.Location = new System.Drawing.Point(149, 157);
            this.lblRemoveVespertinoA.Name = "lblRemoveVespertinoA";
            this.lblRemoveVespertinoA.Size = new System.Drawing.Size(50, 13);
            this.lblRemoveVespertinoA.TabIndex = 19;
            this.lblRemoveVespertinoA.TabStop = true;
            this.lblRemoveVespertinoA.Text = "Remover";
            this.lblRemoveVespertinoA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemoveVespertinoA_LinkClicked);
            // 
            // cbxVespASab
            // 
            this.cbxVespASab.AutoSize = true;
            this.cbxVespASab.Location = new System.Drawing.Point(11, 143);
            this.cbxVespASab.Name = "cbxVespASab";
            this.cbxVespASab.Size = new System.Drawing.Size(63, 17);
            this.cbxVespASab.TabIndex = 17;
            this.cbxVespASab.Text = "Sábado";
            this.cbxVespASab.UseVisualStyleBackColor = true;
            // 
            // cbxVespASex
            // 
            this.cbxVespASex.AutoSize = true;
            this.cbxVespASex.Location = new System.Drawing.Point(11, 120);
            this.cbxVespASex.Name = "cbxVespASex";
            this.cbxVespASex.Size = new System.Drawing.Size(79, 17);
            this.cbxVespASex.TabIndex = 16;
            this.cbxVespASex.Text = "Sexta-Feira";
            this.cbxVespASex.UseVisualStyleBackColor = true;
            // 
            // cbxVespAQui
            // 
            this.cbxVespAQui.AutoSize = true;
            this.cbxVespAQui.Location = new System.Drawing.Point(11, 97);
            this.cbxVespAQui.Name = "cbxVespAQui";
            this.cbxVespAQui.Size = new System.Drawing.Size(83, 17);
            this.cbxVespAQui.TabIndex = 15;
            this.cbxVespAQui.Text = "Quinta-Feira";
            this.cbxVespAQui.UseVisualStyleBackColor = true;
            // 
            // cbxVespAQua
            // 
            this.cbxVespAQua.AutoSize = true;
            this.cbxVespAQua.Location = new System.Drawing.Point(11, 74);
            this.cbxVespAQua.Name = "cbxVespAQua";
            this.cbxVespAQua.Size = new System.Drawing.Size(84, 17);
            this.cbxVespAQua.TabIndex = 14;
            this.cbxVespAQua.Text = "Quarta-Feira";
            this.cbxVespAQua.UseVisualStyleBackColor = true;
            // 
            // cbxVespATer
            // 
            this.cbxVespATer.AutoSize = true;
            this.cbxVespATer.Location = new System.Drawing.Point(11, 51);
            this.cbxVespATer.Name = "cbxVespATer";
            this.cbxVespATer.Size = new System.Drawing.Size(80, 17);
            this.cbxVespATer.TabIndex = 13;
            this.cbxVespATer.Text = "Terça-Feira";
            this.cbxVespATer.UseVisualStyleBackColor = true;
            // 
            // cbxVespASeg
            // 
            this.cbxVespASeg.AutoSize = true;
            this.cbxVespASeg.Location = new System.Drawing.Point(11, 28);
            this.cbxVespASeg.Name = "cbxVespASeg";
            this.cbxVespASeg.Size = new System.Drawing.Size(95, 17);
            this.cbxVespASeg.TabIndex = 12;
            this.cbxVespASeg.Text = "Segunda-Feira";
            this.cbxVespASeg.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGerarVespertinoB);
            this.groupBox4.Controls.Add(this.listVespertinoB);
            this.groupBox4.Controls.Add(this.lblRemoveVespertinoB);
            this.groupBox4.Controls.Add(this.cbxVespBSab);
            this.groupBox4.Controls.Add(this.cbxVespBSex);
            this.groupBox4.Controls.Add(this.cbxVespBQui);
            this.groupBox4.Controls.Add(this.cbxVespBQua);
            this.groupBox4.Controls.Add(this.cbxVespBTer);
            this.groupBox4.Controls.Add(this.cbxVespBSeg);
            this.groupBox4.Location = new System.Drawing.Point(659, 91);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 358);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TurnoVespertino B";
            // 
            // btnGerarVespertinoB
            // 
            this.btnGerarVespertinoB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarVespertinoB.Image = global::Terminal.Properties.Resources.table_gear;
            this.btnGerarVespertinoB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarVespertinoB.Location = new System.Drawing.Point(137, 28);
            this.btnGerarVespertinoB.Name = "btnGerarVespertinoB";
            this.btnGerarVespertinoB.Size = new System.Drawing.Size(62, 24);
            this.btnGerarVespertinoB.TabIndex = 28;
            this.btnGerarVespertinoB.Text = "Gerar";
            this.btnGerarVespertinoB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGerarVespertinoB.UseVisualStyleBackColor = true;
            this.btnGerarVespertinoB.Click += new System.EventHandler(this.btnGerarVespertinoB_Click);
            // 
            // listVespertinoB
            // 
            this.listVespertinoB.FormattingEnabled = true;
            this.listVespertinoB.Location = new System.Drawing.Point(11, 173);
            this.listVespertinoB.Name = "listVespertinoB";
            this.listVespertinoB.Size = new System.Drawing.Size(188, 173);
            this.listVespertinoB.TabIndex = 25;
            // 
            // lblRemoveVespertinoB
            // 
            this.lblRemoveVespertinoB.AutoSize = true;
            this.lblRemoveVespertinoB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveVespertinoB.Location = new System.Drawing.Point(149, 157);
            this.lblRemoveVespertinoB.Name = "lblRemoveVespertinoB";
            this.lblRemoveVespertinoB.Size = new System.Drawing.Size(50, 13);
            this.lblRemoveVespertinoB.TabIndex = 20;
            this.lblRemoveVespertinoB.TabStop = true;
            this.lblRemoveVespertinoB.Text = "Remover";
            this.lblRemoveVespertinoB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRemoveVespertinoB_LinkClicked);
            // 
            // cbxVespBSab
            // 
            this.cbxVespBSab.AutoSize = true;
            this.cbxVespBSab.Location = new System.Drawing.Point(11, 143);
            this.cbxVespBSab.Name = "cbxVespBSab";
            this.cbxVespBSab.Size = new System.Drawing.Size(63, 17);
            this.cbxVespBSab.TabIndex = 24;
            this.cbxVespBSab.Text = "Sábado";
            this.cbxVespBSab.UseVisualStyleBackColor = true;
            // 
            // cbxVespBSex
            // 
            this.cbxVespBSex.AutoSize = true;
            this.cbxVespBSex.Location = new System.Drawing.Point(11, 120);
            this.cbxVespBSex.Name = "cbxVespBSex";
            this.cbxVespBSex.Size = new System.Drawing.Size(79, 17);
            this.cbxVespBSex.TabIndex = 23;
            this.cbxVespBSex.Text = "Sexta-Feira";
            this.cbxVespBSex.UseVisualStyleBackColor = true;
            // 
            // cbxVespBQui
            // 
            this.cbxVespBQui.AutoSize = true;
            this.cbxVespBQui.Location = new System.Drawing.Point(11, 97);
            this.cbxVespBQui.Name = "cbxVespBQui";
            this.cbxVespBQui.Size = new System.Drawing.Size(83, 17);
            this.cbxVespBQui.TabIndex = 22;
            this.cbxVespBQui.Text = "Quinta-Feira";
            this.cbxVespBQui.UseVisualStyleBackColor = true;
            // 
            // cbxVespBQua
            // 
            this.cbxVespBQua.AutoSize = true;
            this.cbxVespBQua.Location = new System.Drawing.Point(11, 74);
            this.cbxVespBQua.Name = "cbxVespBQua";
            this.cbxVespBQua.Size = new System.Drawing.Size(84, 17);
            this.cbxVespBQua.TabIndex = 21;
            this.cbxVespBQua.Text = "Quarta-Feira";
            this.cbxVespBQua.UseVisualStyleBackColor = true;
            // 
            // cbxVespBTer
            // 
            this.cbxVespBTer.AutoSize = true;
            this.cbxVespBTer.Location = new System.Drawing.Point(11, 51);
            this.cbxVespBTer.Name = "cbxVespBTer";
            this.cbxVespBTer.Size = new System.Drawing.Size(80, 17);
            this.cbxVespBTer.TabIndex = 20;
            this.cbxVespBTer.Text = "Terça-Feira";
            this.cbxVespBTer.UseVisualStyleBackColor = true;
            // 
            // cbxVespBSeg
            // 
            this.cbxVespBSeg.AutoSize = true;
            this.cbxVespBSeg.Location = new System.Drawing.Point(11, 28);
            this.cbxVespBSeg.Name = "cbxVespBSeg";
            this.cbxVespBSeg.Size = new System.Drawing.Size(95, 17);
            this.cbxVespBSeg.TabIndex = 19;
            this.cbxVespBSeg.Text = "Segunda-Feira";
            this.cbxVespBSeg.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::Terminal.Properties.Resources.table_gear;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(659, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 24);
            this.button1.TabIndex = 26;
            this.button1.Text = "Gerar Todos";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Image = global::Terminal.Properties.Resources.disk;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(759, 455);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(108, 24);
            this.btnSalvar.TabIndex = 27;
            this.btnSalvar.Text = "Salvar Gerados";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data de Início";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data de Término";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(12, 45);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(185, 20);
            this.dtpInicio.TabIndex = 11;
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(12, 92);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(185, 20);
            this.dtpFim.TabIndex = 12;
            // 
            // FormMesLetivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMesLetivo";
            this.Text = "Chamada";
            this.Load += new System.EventHandler(this.FormProjeto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxMatSab;
        private System.Windows.Forms.CheckBox cbxMatSex;
        private System.Windows.Forms.CheckBox cbxMatQui;
        private System.Windows.Forms.CheckBox cbxMatQua;
        private System.Windows.Forms.CheckBox cbxMatTer;
        private System.Windows.Forms.CheckBox cbxMatSeg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxVespASab;
        private System.Windows.Forms.CheckBox cbxVespASex;
        private System.Windows.Forms.CheckBox cbxVespAQui;
        private System.Windows.Forms.CheckBox cbxVespAQua;
        private System.Windows.Forms.CheckBox cbxVespATer;
        private System.Windows.Forms.CheckBox cbxVespASeg;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbxVespBSab;
        private System.Windows.Forms.CheckBox cbxVespBSex;
        private System.Windows.Forms.CheckBox cbxVespBQui;
        private System.Windows.Forms.CheckBox cbxVespBQua;
        private System.Windows.Forms.CheckBox cbxVespBTer;
        private System.Windows.Forms.CheckBox cbxVespBSeg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel lblRemoveFeriado;
        private System.Windows.Forms.LinkLabel lblAddFeriado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblRemoveMatutino;
        private System.Windows.Forms.LinkLabel lblRemoveVespertinoA;
        private System.Windows.Forms.LinkLabel lblRemoveVespertinoB;
        private System.Windows.Forms.ListBox listFeriados;
        private System.Windows.Forms.ListBox listMatutino;
        private System.Windows.Forms.ListBox listVespertinoA;
        private System.Windows.Forms.ListBox listVespertinoB;
        private System.Windows.Forms.Button btnGerarMatutino;
        private System.Windows.Forms.Button btnGerarVespertinoA;
        private System.Windows.Forms.Button btnGerarVespertinoB;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}