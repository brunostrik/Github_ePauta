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
    public partial class TelaTerminal : Form
    {
        private DAO dao;
        private int turno;
        MemoryStream ms;
        public TelaTerminal()
        {
            InitializeComponent();
            dao = new DAO();
            timer_Tick(null, null);
            Log("Sistema iniciado");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AtualizaRelogio();
        }
        private void AtualizaRelogio()
        {
            lblRelogio.Text = DateTime.Now.ToLocalTime().ToString();
            if (DateTime.Now.Hour < 12) 
            {
                txtTurno.Text = "TURNO MATUTINO";
                turno = 1;
            } else if (DateTime.Now.Hour < 15 || (DateTime.Now.Hour == 15 && DateTime.Now.Minute <= 5))
            {
                txtTurno.Text = "TURNO VESPERTINO 1";
                turno = 2;
            } else if (DateTime.Now.Hour < 18)
            {
                txtTurno.Text = "TURNO VESPERTINO 2";
                turno = 3;
            }
            else
            {
                txtTurno.Text = "FORA DE TURNO";
                turno = 0;
            }
        }

        
        private void txtLeitor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (turno != 0)
                {
                    Registrar();
                }else
                {
                    Log("NÃO É POSSÍVEL REGISTRAR CHAMADA FORA DO TURNO");
                }
                txtLeitor.Text = string.Empty;
                txtLeitor.Focus();
            }else if (e.KeyCode == Keys.F4)
            {
                this.Close();
            }
        }
        private void Registrar()
        {
            try
            {
                ChamadaDTO chamada = dao.Registrar(txtLeitor.Text.Trim(), turno, DateTime.Now);
                AlertaOK(chamada);        
            }catch (Exception ex)
            {
                AlertaErro(ex.Message);
                Log(ex.Message);
            }
        }
        private void AlertaOK(ChamadaDTO dto)
        {
            txtNome.Text = dto.aluno.Nome.ToUpper();
            txtProjeto.Text = "PROJETO " + dto.projeto.Nome.ToUpper();
            //FOTOGRAFIA
            try
            {
                picFoto.Image = dao.CarregarFotoAluno(dto.aluno.Id).Foto;
            }
            catch (Exception) { }//ignora erro, pois é aluno sem foto
            lblRegistroOK.Visible = true;
            txtProjeto.Visible = true;
            Log("REGISTRO: " + dto.aluno.Nome.ToUpper() + " - PROJETO: "+ dto.projeto.Nome.ToUpper());
            Limpa();
        }
        private void AlertaErro(String exceptionMessage)
        {
            txtRegistroERRO.Visible = true;
            txtRegistroERRO.Text = exceptionMessage;
            Limpa();           
        }
        private void Log(String txt)
        {
            txtLog.Text = (DateTime.Now.ToLocalTime() + " " + txt.ToUpper() + "\r\n") + txtLog.Text;
            txtLog.ScrollToCaret();
        }
        private async Task Limpa() //Aguarda 3 segundos
        {
            await Task.Delay(3000);
            lblRegistroOK.Visible = false;
            txtProjeto.Visible = false;
            //FOTOGRAFIA
            picFoto.Image = null;
            txtNome.Text = string.Empty;
            txtRegistroERRO.Visible = false;
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtLeitor.Focus();
        }

        private void txtProjeto_Enter(object sender, EventArgs e)
        {
            txtLeitor.Focus();
        }

        private void txtRegistroERRO_Enter(object sender, EventArgs e)
        {
            txtLeitor.Focus();
        }
    }
}
