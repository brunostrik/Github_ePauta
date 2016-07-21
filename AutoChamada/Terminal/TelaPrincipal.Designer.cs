namespace Terminal
{
    partial class TelaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porProjetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porEstudanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estudantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalDeChamadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ePauta10BrunostrikifpredubrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatóriosToolStripMenuItem,
            this.estudantesToolStripMenuItem,
            this.projetosToolStripMenuItem,
            this.calendárioToolStripMenuItem,
            this.terminalDeChamadasToolStripMenuItem,
            this.ePauta10BrunostrikifpredubrToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1112, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porProjetoToolStripMenuItem,
            this.porEstudanteToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Image = global::Terminal.Properties.Resources.report;
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // porProjetoToolStripMenuItem
            // 
            this.porProjetoToolStripMenuItem.Image = global::Terminal.Properties.Resources.book_open;
            this.porProjetoToolStripMenuItem.Name = "porProjetoToolStripMenuItem";
            this.porProjetoToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.porProjetoToolStripMenuItem.Text = "Por projeto";
            this.porProjetoToolStripMenuItem.Click += new System.EventHandler(this.porProjetoToolStripMenuItem_Click);
            // 
            // porEstudanteToolStripMenuItem
            // 
            this.porEstudanteToolStripMenuItem.Image = global::Terminal.Properties.Resources.group;
            this.porEstudanteToolStripMenuItem.Name = "porEstudanteToolStripMenuItem";
            this.porEstudanteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.porEstudanteToolStripMenuItem.Text = "Por estudante";
            this.porEstudanteToolStripMenuItem.Click += new System.EventHandler(this.porEstudanteToolStripMenuItem_Click);
            // 
            // estudantesToolStripMenuItem
            // 
            this.estudantesToolStripMenuItem.Image = global::Terminal.Properties.Resources.group;
            this.estudantesToolStripMenuItem.Name = "estudantesToolStripMenuItem";
            this.estudantesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.estudantesToolStripMenuItem.Text = "Estudantes";
            this.estudantesToolStripMenuItem.Click += new System.EventHandler(this.estudantesToolStripMenuItem_Click);
            // 
            // projetosToolStripMenuItem
            // 
            this.projetosToolStripMenuItem.Image = global::Terminal.Properties.Resources.book_open;
            this.projetosToolStripMenuItem.Name = "projetosToolStripMenuItem";
            this.projetosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.projetosToolStripMenuItem.Text = "Projetos";
            this.projetosToolStripMenuItem.Click += new System.EventHandler(this.projetosToolStripMenuItem_Click);
            // 
            // calendárioToolStripMenuItem
            // 
            this.calendárioToolStripMenuItem.Image = global::Terminal.Properties.Resources.calendar;
            this.calendárioToolStripMenuItem.Name = "calendárioToolStripMenuItem";
            this.calendárioToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.calendárioToolStripMenuItem.Text = "Calendário";
            this.calendárioToolStripMenuItem.Click += new System.EventHandler(this.calendárioToolStripMenuItem_Click);
            // 
            // terminalDeChamadasToolStripMenuItem
            // 
            this.terminalDeChamadasToolStripMenuItem.Image = global::Terminal.Properties.Resources.computer;
            this.terminalDeChamadasToolStripMenuItem.Name = "terminalDeChamadasToolStripMenuItem";
            this.terminalDeChamadasToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.terminalDeChamadasToolStripMenuItem.Text = "Painel de Chamadas";
            this.terminalDeChamadasToolStripMenuItem.Click += new System.EventHandler(this.terminalDeChamadasToolStripMenuItem_Click);
            // 
            // ePauta10BrunostrikifpredubrToolStripMenuItem
            // 
            this.ePauta10BrunostrikifpredubrToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ePauta10BrunostrikifpredubrToolStripMenuItem.Enabled = false;
            this.ePauta10BrunostrikifpredubrToolStripMenuItem.Name = "ePauta10BrunostrikifpredubrToolStripMenuItem";
            this.ePauta10BrunostrikifpredubrToolStripMenuItem.Size = new System.Drawing.Size(207, 20);
            this.ePauta10BrunostrikifpredubrToolStripMenuItem.Text = "ePauta 1.0 - bruno.strik@ifpr.edu.br";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 482);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaPrincipal";
            this.Text = "IFPR Câmpus Avançado Astorga";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porProjetoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porEstudanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estudantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminalDeChamadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ePauta10BrunostrikifpredubrToolStripMenuItem;
    }
}