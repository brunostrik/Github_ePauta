using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Terminal
{
    public partial class FormChamadaAvulsa : Form
    {
        private Aluno aluno;
        private DAO dao;

        public FormChamadaAvulsa(int idAluno)
        {
            InitializeComponent();           
            dao = new DAO();
            this.aluno = dao.CarregarAluno(idAluno);
        }
        private void DefineCampos()
        {
            txtAluno.Text = aluno.Nome;
            cmbTurno.SelectedIndex = 0;
        }

        private void FormProjeto_Load(object sender, EventArgs e)
        {
            DefineCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {            
            try
            {
                ChamadaDTO cha = dao.Registrar(aluno.Cartao, cmbTurno.SelectedIndex + 1, dtpDia.Value);
                Program.Mensagem("Chamada registrada para\r\nEstudante: " + aluno.Nome + "\r\nProjeto: " + cha.projeto.Nome + "\r\nDia: " + dtpDia.Value.ToShortDateString() + " Turno: " + cmbTurno.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }           
        }
    }
}
