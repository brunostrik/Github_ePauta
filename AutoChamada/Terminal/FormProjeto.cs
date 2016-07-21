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
    public partial class FormProjeto : Form
    {
        private Projeto projeto;
        private DAO dao;

        public FormProjeto(Projeto p)
        {
            InitializeComponent();
            this.projeto = p;
            dao = new DAO();
        }
        private void DefineCampos()
        {
            txtNome.Text = projeto.Nome;
            cmbDiaDaSemana.SelectedIndex = projeto.DiaDaSemana;
            cmbTurno.SelectedIndex = projeto.Turno - 1;
            if (cmbDiaDaSemana.SelectedIndex < 0)
            {
                cmbDiaDaSemana.SelectedIndex = 0;
            }
            if (cmbTurno.SelectedIndex < 0)
            {
                cmbTurno.SelectedIndex = 0;
            }
        }

        private void FormProjeto_Load(object sender, EventArgs e)
        {
            DefineCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 1)
            {
                Program.Alerta("Por favor preencha o nome do projeto");
                return;
            }
            projeto.Nome = txtNome.Text;
            projeto.DiaDaSemana = cmbDiaDaSemana.SelectedIndex;
            projeto.Turno = cmbTurno.SelectedIndex + 1;
            try
            {
                if (projeto.Id == 0)
                {             
                    dao.ProjetoInsert(projeto);
                    Program.listaProjetos.CarregarGrid();
                    Program.Mensagem("Novo projeto adicionado com sucesso");
                    this.Close();                
                }else
                {
                    dao.ProjetoUpdate(projeto);
                    Program.listaProjetos.CarregarGrid();
                    Program.Mensagem("Projeto atualizado com sucesso");
                    this.Close();
                
                }
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            
        }

        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDiaDaSemana.Visible = (cmbTurno.Text != "Matutino");
            lblDiaDaSemana.Visible = (cmbTurno.Text != "Matutino");
            
        }
    }
}
