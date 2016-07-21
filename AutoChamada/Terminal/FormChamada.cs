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
    public partial class FormChamada : Form
    {
        private Chamada chamada;
        private DAO dao;

        public FormChamada(Chamada c, bool modoObs = false)
        {
            InitializeComponent();
            this.chamada = c;
            dao = new DAO();
            if (modoObs)
            {
                lblDia.Visible = false;
                dtpDia.Visible = false;
                lblTurno.Visible = false;
                cmbTurno.Visible = false;
                lblCH.Visible = false;
                txtCH.Visible = false;
                lblMinutos.Visible = false;
                lblObs.Top = lblDia.Top;
                txtObs.Top = dtpDia.Top;
            }
        }
        private void DefineCampos()
        {                    
            txtObs.Text = chamada.Obs;
            txtCH.Text = chamada.CargaHoraria.ToString();
            cmbTurno.SelectedIndex = chamada.Turno - 1;
            if (cmbTurno.SelectedIndex < 0) cmbTurno.SelectedIndex = 0;
            dtpDia.Value = chamada.Dia;
        }

        private void FormProjeto_Load(object sender, EventArgs e)
        {
            DefineCampos();          
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //validacao dos dados
            try
            {
                chamada.CargaHoraria = Convert.ToInt32(txtCH.Text);
                if (chamada.CargaHoraria < 0)
                {
                    Program.Erro("O valor digitado para carga horária não é um número válido.");
                    txtCH.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                Program.Erro("O valor digitado para carga horária não é um número válido.");
                txtCH.Focus();
                return;
            }
            
            chamada.Dia = dtpDia.Value;
            chamada.Turno = cmbTurno.SelectedIndex + 1;
            chamada.Obs = txtObs.Text;

            //validar se ja nao existe neste dia e periodo chamada existente, que tenha o id diferente dessa
            if (dao.ChamadaEmConflito(chamada)){
                Program.Erro("Já existe uma chamada cadastrada para o dia " + chamada.Dia.ToShortDateString() + " e turno " + Program.Turno(chamada.Turno)+"\r\nNão é possível salvar em duplicidade");
                return;
            }
            try
            {
                if (chamada.Id != 0)
                {
                    dao.AtualizarChamada(chamada);
                    Program.Mensagem("Dados atualizados com sucesso");
                }
                else
                {
                    dao.InserirChamada(chamada);
                    Program.Mensagem("Dados inseridos com sucesso");
                }
                Program.listaChamadas.atualizartoolStripButton_Click(null, null);
                this.Close();
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            
        }

        private void txtCH_Leave(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(txtCH.Text);
                
                if (n < 0)
                {
                    Program.Erro("O valor digitado não é um número válido.");
                }
            }catch (Exception)
            {
                Program.Erro("O valor digitado não é um número válido.");
            }
        }

        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCHTurno();
        }
        private void AtualizarCHTurno()
        {
            switch (cmbTurno.SelectedIndex)
            {
                case 0:
                    txtCH.Text = 255.ToString();
                    break;
                case 1:
                case 2:
                    txtCH.Text = 90.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
