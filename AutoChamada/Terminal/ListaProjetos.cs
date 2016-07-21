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
    public partial class ListaProjetos : Form
    {
        private DAO dao;

        public ListaProjetos()
        {
            InitializeComponent();
            dao = new DAO();
            CarregarGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Program.formProjeto = new FormProjeto(new Projeto());
            Program.formProjeto.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            Program.formProjeto = new FormProjeto(dao.CarregarProjeto(id));
            Program.formProjeto.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!Program.Pergunta("Deseja realmente excluir este projeto?")) return;
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            try
            {
                dao.ExcluirProjeto(id);
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
            dgv.DataSource = dao.TodosProjetosDTO();
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Nome do Projeto";
            dgv.Columns[2].HeaderText = "Dia da Semana";
            dgv.Columns[3].HeaderText = "Turno";
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                dgvr.Cells[2].Value = Program.DiaDaSemana(Convert.ToInt32(dgvr.Cells[2].Value));
                dgvr.Cells[3].Value = Program.Turno(Convert.ToInt32(dgvr.Cells[3].Value));
            }
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
    }
}
