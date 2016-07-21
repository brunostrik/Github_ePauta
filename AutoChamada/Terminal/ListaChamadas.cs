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
    public partial class ListaChamadas : Form
    {
        private DAO dao;

        public ListaChamadas()
        {
            InitializeComponent();
            dao = new DAO();
            cal.SetDate(DateTime.Now);
        }
        
        
        private void CarregarChamadas(int mes)
        {
            List<CalendarioDTO> diasChamada = dao.CarregarChamadasCalendario(mes);

            //Configura a grid
            dgv.DataSource = diasChamada;
            dgv.Columns["DiaDaSemana"].Visible = false;
            dgv.Columns["DiaDaSemanaString"].HeaderText = "Dia da Semana";
            dgv.Columns["Matutino"].HeaderText = "CH Matutino";
            dgv.Columns["VespertinoA"].HeaderText = "CH Vespertino A";
            dgv.Columns["VespertinoB"].HeaderText = "CH Vespertino B";
            dgv.Columns["Total"].HeaderText = "CH Total";
            dgv.Columns["idMatutino"].Visible = false;
            dgv.Columns["idVespertinoA"].Visible = false;
            dgv.Columns["idVespertinoB"].Visible = false;
            //Configura o mini calendário e calcula a CH total
            double chTotal = 0;
            DateTime[] diasNegrito = new DateTime[diasChamada.Count];
            for (int i=0; i< diasNegrito.Length; i++)
            {
                diasNegrito[i] = diasChamada[i].Dia;
                chTotal += diasChamada[i].Total;
            }
            cal.BoldedDates = diasNegrito;
            lblTotal.Text = chTotal + " horas";
        }

        private void novoToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        public void atualizartoolStripButton_Click(object sender, EventArgs e)
        {
            cal.SetDate(DateTime.Now);
        }

        private void cal_DateChanged(object sender, DateRangeEventArgs e)
        {
            CarregarChamadas(e.Start.Month);
        }

        private void matutinoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //EXCLUIR MATUTINO
            //Validar se existe mesmo no selecionado
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idMatutino"].Value);
            string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
            if (id == 0)
            {
                Program.Alerta("Não há registro para ser excluído no dia "+dia+" período Matutino");
                return;
            }
            //Pedir confirmação
            if (!Program.Pergunta("Tem certeza que deseja excluir o item " + dia + " período Matutino?")) return;
            //Excluir
            try
            {
                dao.ExcluirChamada(id);
            }catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            //Atualizar
            atualizartoolStripButton_Click(null, null);
        }

        private void vespertinoAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //EXCLUIR VESPERTINO A
            //Validar se existe mesmo no selecionado
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idVespertinoA"].Value);
            string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
            if (id == 0)
            {
                Program.Alerta("Não há registro para ser excluído no dia " + dia + " período Vespertino A");
                return;
            }
            //Pedir confirmação
            if (!Program.Pergunta("Tem certeza que deseja excluir o item " + dia + " período Vespertino A?")) return;
            //Excluir
            try
            {
                dao.ExcluirChamada(id);
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            //Atualizar
            atualizartoolStripButton_Click(null, null);
        }

        private void vespertinoBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //EXCLUIR VESPERTINO B
            //Validar se existe mesmo no selecionado
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idVespertinoB"].Value);
            string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
            if (id == 0)
            {
                Program.Alerta("Não há registro para ser excluído no dia " + dia + " período Vespertino B");
                return;
            }
            //Pedir confirmação
            if (!Program.Pergunta("Tem certeza que deseja excluir o item " + dia + " período Vespertino B?")) return;
            //Excluir
            try
            {
                dao.ExcluirChamada(id);
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            //Atualizar
            atualizartoolStripButton_Click(null, null);
        }

        private void todoODiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EXCLUIR O DIA TODO
            string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();          
            //Pedir confirmação
            if (!Program.Pergunta("Tem certeza que deseja excluir todos os items do dia " + dia + "?")) return;
            //Excluir
            try
            {
                dao.ExcluirChamadaDia((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value);
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            //Atualizar
            atualizartoolStripButton_Click(null, null);
        }

        private void matutinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EDITAR MATUTINO
            //OBS MATUTINO
            try
            {
                int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idMatutino"].Value);
                if (id == 0)
                {
                    string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
                    Program.Alerta("Não há registro do dia " + dia + " período Matutino");
                    return;
                }
                Chamada c = dao.CarregarChamada(id);
                Program.formObservacoesChamada = new FormChamada(c);
                Program.formObservacoesChamada.ShowDialog();
            }catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void vespertinoAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EDITAR VESPERTINO A
            try
            {
                int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idVespertinoA"].Value);
                if (id == 0)
                {
                    string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
                    Program.Alerta("Não há registro do dia " + dia + " período Vespertino A");
                    return;
                }
                Chamada c = dao.CarregarChamada(id);
                Program.formObservacoesChamada = new FormChamada(c);
                Program.formObservacoesChamada.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void vespertinoBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EDITAR VESPERTINO B
            try
            {
                int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idVespertinoB"].Value);
                if (id == 0)
                {
                    string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
                    Program.Alerta("Não há registro do dia " + dia + " período Vespertino B");
                    return;
                }
                Chamada c = dao.CarregarChamada(id);
                Program.formObservacoesChamada = new FormChamada(c, true);
                Program.formObservacoesChamada.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void matutinoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //OBS MATUTINO
            try
            {
                int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idMatutino"].Value);
                if (id == 0)
                {
                    string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
                    Program.Alerta("Não há registro do dia " + dia + " período Matutino");
                    return;
                }
                Chamada c = dao.CarregarChamada(id);
                Program.formObservacoesChamada = new FormChamada(c, true);
                Program.formObservacoesChamada.ShowDialog();
            }catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void vespertinoAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //OBS VESPERTINO A
            try
            {
                int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idVespertinoA"].Value);
                if (id == 0)
                {
                    string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
                    Program.Alerta("Não há registro do dia " + dia + " período Vespertino A");
                    return;
                }
                Chamada c = dao.CarregarChamada(id);
                Program.formObservacoesChamada = new FormChamada(c, true);
                Program.formObservacoesChamada.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void vespertinoBToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //OBS VESPERTINO B
            try
            {
                int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["idVespertinoB"].Value);
                if (id == 0)
                {
                    string dia = ((DateTime)dgv.SelectedRows[0].Cells["Dia"].Value).ToShortDateString();
                    Program.Alerta("Não há registro do dia " + dia + " período Vespertino B");
                    return;
                }
                Chamada c = dao.CarregarChamada(id);
                Program.formObservacoesChamada = new FormChamada(c, true);
                Program.formObservacoesChamada.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }

        private void diaLetivoSimplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chamada c = new Chamada();
            Program.formObservacoesChamada = new FormChamada(c);
            Program.formObservacoesChamada.ShowDialog();
        }

        private void mêsLetivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formMesLetivo = new FormMesLetivo();
            Program.formMesLetivo.ShowDialog();
        }
    }
}
