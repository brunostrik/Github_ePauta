using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //VER SE O BD ESTA FUNCIONANDO
            if (!new DAO().TestarBD())
            {
                Program.Erro("Não foi possível conectar ao banco de dados.\r\nVerifique sua conexão na rede do IFPR.");
                Application.Exit();
            }

            this.Visible = false;
            Program.loginForm = new LoginForm();
            Program.loginForm.ShowDialog();
        }

        private void porProjetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.relatorioForm = new RelatorioForm();
            Program.relatorioForm.MdiParent = this;
            Program.relatorioForm.Show();
        }

        private void porEstudanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.relatorioEstudanteForm = new RelatorioEstudanteForm();
            Program.relatorioEstudanteForm.MdiParent = this;
            Program.relatorioEstudanteForm.Show();
        }

        private void estudantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir lista de estudantes
            Program.listaAlunos = new ListaAlunos();
            Program.listaAlunos.MdiParent = this;
            Program.listaAlunos.Show();
        }

        private void projetosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir lista de projetos
            Program.listaProjetos = new ListaProjetos();
            Program.listaProjetos.MdiParent = this;
            Program.listaProjetos.Show();
        }

        private void calendárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.listaChamadas = new ListaChamadas();
            Program.listaChamadas.MdiParent = this;
            Program.listaChamadas.Show();
        }

        private void terminalDeChamadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.telaTerminal = new TelaTerminal();
            Program.telaTerminal.ShowDialog();
        }
    }
}
