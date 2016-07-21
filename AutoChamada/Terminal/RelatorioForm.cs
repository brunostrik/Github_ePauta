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
    public partial class RelatorioForm : Form
    {

        private DAO dao;

        public RelatorioForm()
        {
            InitializeComponent();
            dao = new DAO();
            CarregarCombos();
        }
        private void CarregarCombos()
        {
            cmbProjeto.DataSource = dao.TodosProjetos(null);
            cmbProjeto.DisplayMember = "nome";
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            dgv.DataSource = dao.RelatorioPivot((Projeto)cmbProjeto.SelectedItem, dtpInicio.Value, dtpFim.Value, null);
            btnExcel.Enabled = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
            if (dgv.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    XcelApp.Cells[1, 1] = cmbProjeto.Text.ToUpper();
                    for (int i = 1; i < dgv.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[2, i] = dgv.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 3, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
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
