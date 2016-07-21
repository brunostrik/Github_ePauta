namespace Terminal
{
    partial class ListaChamadas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaChamadas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.novoToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.diaLetivoSimplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mêsLetivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.matutinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vespertinoAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vespertinoBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.matutinoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vespertinoAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vespertinoBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.todoODiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizartoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.matutinoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.vespertinoAToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.vespertinoBToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cal = new System.Windows.Forms.MonthCalendar();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripButton,
            this.editarToolStripButton,
            this.excluirToolStripButton,
            this.atualizartoolStripButton,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(868, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // novoToolStripButton
            // 
            this.novoToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diaLetivoSimplesToolStripMenuItem,
            this.mêsLetivoToolStripMenuItem});
            this.novoToolStripButton.Image = global::Terminal.Properties.Resources.add;
            this.novoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.novoToolStripButton.Name = "novoToolStripButton";
            this.novoToolStripButton.Size = new System.Drawing.Size(65, 22);
            this.novoToolStripButton.Text = "Novo";
            this.novoToolStripButton.Click += new System.EventHandler(this.novoToolStripButton_Click);
            // 
            // diaLetivoSimplesToolStripMenuItem
            // 
            this.diaLetivoSimplesToolStripMenuItem.Image = global::Terminal.Properties.Resources.date;
            this.diaLetivoSimplesToolStripMenuItem.Name = "diaLetivoSimplesToolStripMenuItem";
            this.diaLetivoSimplesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.diaLetivoSimplesToolStripMenuItem.Text = "Dia Letivo";
            this.diaLetivoSimplesToolStripMenuItem.Click += new System.EventHandler(this.diaLetivoSimplesToolStripMenuItem_Click);
            // 
            // mêsLetivoToolStripMenuItem
            // 
            this.mêsLetivoToolStripMenuItem.Image = global::Terminal.Properties.Resources.calendar;
            this.mêsLetivoToolStripMenuItem.Name = "mêsLetivoToolStripMenuItem";
            this.mêsLetivoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mêsLetivoToolStripMenuItem.Text = "Período Letivo";
            this.mêsLetivoToolStripMenuItem.Click += new System.EventHandler(this.mêsLetivoToolStripMenuItem_Click);
            // 
            // editarToolStripButton
            // 
            this.editarToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matutinoToolStripMenuItem,
            this.vespertinoAToolStripMenuItem,
            this.vespertinoBToolStripMenuItem});
            this.editarToolStripButton.Image = global::Terminal.Properties.Resources.pencil;
            this.editarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editarToolStripButton.Name = "editarToolStripButton";
            this.editarToolStripButton.Size = new System.Drawing.Size(66, 22);
            this.editarToolStripButton.Text = "Editar";
            // 
            // matutinoToolStripMenuItem
            // 
            this.matutinoToolStripMenuItem.Name = "matutinoToolStripMenuItem";
            this.matutinoToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.matutinoToolStripMenuItem.Text = "Matutino";
            this.matutinoToolStripMenuItem.Click += new System.EventHandler(this.matutinoToolStripMenuItem_Click);
            // 
            // vespertinoAToolStripMenuItem
            // 
            this.vespertinoAToolStripMenuItem.Name = "vespertinoAToolStripMenuItem";
            this.vespertinoAToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.vespertinoAToolStripMenuItem.Text = "Vespertino A";
            this.vespertinoAToolStripMenuItem.Click += new System.EventHandler(this.vespertinoAToolStripMenuItem_Click);
            // 
            // vespertinoBToolStripMenuItem
            // 
            this.vespertinoBToolStripMenuItem.Name = "vespertinoBToolStripMenuItem";
            this.vespertinoBToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.vespertinoBToolStripMenuItem.Text = "Vespertino B";
            this.vespertinoBToolStripMenuItem.Click += new System.EventHandler(this.vespertinoBToolStripMenuItem_Click);
            // 
            // excluirToolStripButton
            // 
            this.excluirToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matutinoToolStripMenuItem1,
            this.vespertinoAToolStripMenuItem1,
            this.vespertinoBToolStripMenuItem1,
            this.todoODiaToolStripMenuItem});
            this.excluirToolStripButton.Image = global::Terminal.Properties.Resources.delete;
            this.excluirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excluirToolStripButton.Name = "excluirToolStripButton";
            this.excluirToolStripButton.Size = new System.Drawing.Size(70, 22);
            this.excluirToolStripButton.Text = "Excluir";
            // 
            // matutinoToolStripMenuItem1
            // 
            this.matutinoToolStripMenuItem1.Name = "matutinoToolStripMenuItem1";
            this.matutinoToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.matutinoToolStripMenuItem1.Text = "Matutino";
            this.matutinoToolStripMenuItem1.Click += new System.EventHandler(this.matutinoToolStripMenuItem1_Click);
            // 
            // vespertinoAToolStripMenuItem1
            // 
            this.vespertinoAToolStripMenuItem1.Name = "vespertinoAToolStripMenuItem1";
            this.vespertinoAToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.vespertinoAToolStripMenuItem1.Text = "Vespertino A";
            this.vespertinoAToolStripMenuItem1.Click += new System.EventHandler(this.vespertinoAToolStripMenuItem1_Click);
            // 
            // vespertinoBToolStripMenuItem1
            // 
            this.vespertinoBToolStripMenuItem1.Name = "vespertinoBToolStripMenuItem1";
            this.vespertinoBToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.vespertinoBToolStripMenuItem1.Text = "Vespertino B";
            this.vespertinoBToolStripMenuItem1.Click += new System.EventHandler(this.vespertinoBToolStripMenuItem1_Click);
            // 
            // todoODiaToolStripMenuItem
            // 
            this.todoODiaToolStripMenuItem.Name = "todoODiaToolStripMenuItem";
            this.todoODiaToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.todoODiaToolStripMenuItem.Text = "Todo o dia";
            this.todoODiaToolStripMenuItem.Click += new System.EventHandler(this.todoODiaToolStripMenuItem_Click);
            // 
            // atualizartoolStripButton
            // 
            this.atualizartoolStripButton.Image = global::Terminal.Properties.Resources.arrow_refresh;
            this.atualizartoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.atualizartoolStripButton.Name = "atualizartoolStripButton";
            this.atualizartoolStripButton.Size = new System.Drawing.Size(73, 22);
            this.atualizartoolStripButton.Text = "Atualizar";
            this.atualizartoolStripButton.Click += new System.EventHandler(this.atualizartoolStripButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matutinoToolStripMenuItem2,
            this.vespertinoAToolStripMenuItem2,
            this.vespertinoBToolStripMenuItem2});
            this.toolStripButton1.Image = global::Terminal.Properties.Resources.book_edit;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(103, 22);
            this.toolStripButton1.Text = "Observações";
            // 
            // matutinoToolStripMenuItem2
            // 
            this.matutinoToolStripMenuItem2.Name = "matutinoToolStripMenuItem2";
            this.matutinoToolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.matutinoToolStripMenuItem2.Text = "Matutino";
            this.matutinoToolStripMenuItem2.Click += new System.EventHandler(this.matutinoToolStripMenuItem2_Click);
            // 
            // vespertinoAToolStripMenuItem2
            // 
            this.vespertinoAToolStripMenuItem2.Name = "vespertinoAToolStripMenuItem2";
            this.vespertinoAToolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.vespertinoAToolStripMenuItem2.Text = "Vespertino A";
            this.vespertinoAToolStripMenuItem2.Click += new System.EventHandler(this.vespertinoAToolStripMenuItem2_Click);
            // 
            // vespertinoBToolStripMenuItem2
            // 
            this.vespertinoBToolStripMenuItem2.Name = "vespertinoBToolStripMenuItem2";
            this.vespertinoBToolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.vespertinoBToolStripMenuItem2.Text = "Vespertino B";
            this.vespertinoBToolStripMenuItem2.Click += new System.EventHandler(this.vespertinoBToolStripMenuItem2_Click);
            // 
            // cal
            // 
            this.cal.Location = new System.Drawing.Point(18, 34);
            this.cal.MaxSelectionCount = 1;
            this.cal.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.cal.Name = "cal";
            this.cal.TabIndex = 2;
            this.cal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cal_DateChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(258, 34);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowTemplate.Height = 18;
            this.dgv.RowTemplate.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(598, 360);
            this.dgv.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 199);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(9, 33);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(67, 18);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "X horas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carga horária total neste mês";
            // 
            // ListaChamadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 406);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cal);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListaChamadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendário Letivo";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton atualizartoolStripButton;
        private System.Windows.Forms.MonthCalendar cal;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStripDropDownButton editarToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem matutinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vespertinoAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vespertinoBToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton excluirToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem matutinoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vespertinoAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vespertinoBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem todoODiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem matutinoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem vespertinoAToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem vespertinoBToolStripMenuItem2;
        private System.Windows.Forms.ToolStripDropDownButton novoToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem diaLetivoSimplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mêsLetivoToolStripMenuItem;
    }
}