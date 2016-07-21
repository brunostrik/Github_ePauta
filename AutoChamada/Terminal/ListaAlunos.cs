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
    public partial class ListaAlunos : Form
    {
        private DAO dao;

        public ListaAlunos()
        {
            InitializeComponent();
            dao = new DAO();
            CarregarGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Program.formAluno = new FormAluno(new Aluno());
            Program.formAluno.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            Program.formAluno = new FormAluno(dao.CarregarAluno(id));
            Program.formAluno.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!Program.Pergunta("Deseja realmente excluir este estudante do sistema?")) return;
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            try
            {
                dao.ExcluirAluno(id);
            }catch(Exception ex)
            {
                Program.Erro(ex.Message);
            }
            CarregarGrid();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEditar_Click(null, null);
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExcluir_Click(null, null);
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnExcluir_Click(null, null);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        public void CarregarGrid()
        {
            dgv.DataSource = dao.TodosAlunos();
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Nome";
            dgv.Columns[2].HeaderText = "Matrícula (Cartão)";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
            if (dgv.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgv.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    XcelApp.Columns.AutoFit();
                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    Program.Erro(ex.Message);
                    XcelApp.Quit();
                }
            }
        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            Program.formMatricula = new FormMatricula(id);
            Program.formMatricula.ShowDialog();
        }

        private void projetosDoEstudanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMatricula_Click(null, null);
        }

        private void btnChamadaAvulsa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            Program.formChamadaAvulsa = new FormChamadaAvulsa(id);
            Program.formChamadaAvulsa.ShowDialog();
        }

        private void chamadaAvulsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChamadaAvulsa_Click(null, null);
        }
    }
}
