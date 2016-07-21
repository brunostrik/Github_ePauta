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
    public partial class FormMesLetivo : Form, DataSelectorReturn
    {
        private DAO dao;
        private List<DateTime> feriados;
        private List<DateTime> matutinos;
        private List<DateTime> vespertinosA;
        private List<DateTime> vespertinosB;

        public FormMesLetivo()
        {
            InitializeComponent();            
            dao = new DAO();
            feriados = new List<DateTime>();
            matutinos = new List<DateTime>();
            vespertinosA = new List<DateTime>();
            vespertinosB = new List<DateTime>();     
        }
        private void DefineCampos()
        {                    
            
        }

        private void FormProjeto_Load(object sender, EventArgs e)
        {
            DefineCampos();          
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Program.Pergunta("O programa irá agora salvar os dias definidos como letivos da maneira que estão sendo mostrados na tela agora.\r\n"+
                "A carga horária será de 4:15 para projetos matutinos e 1:30 para vespertinos.\r\nCaso existam chamadas abertas em conflito com as aqui existentes, elas serão mantidas como estavam.\r\nConfirma a operação?")) return;
            List<Chamada> chamadas = new List<Chamada>();
            foreach(DateTime d in matutinos) //MATUTINO
            {
                Chamada c = new Chamada();
                c.CargaHoraria = 255;
                c.Dia = d;
                c.Obs = "";
                c.Turno = 1;
                chamadas.Add(c);
            }
            foreach (DateTime d in vespertinosA) //VESPERTINO A
            {
                Chamada c = new Chamada();
                c.CargaHoraria = 90;
                c.Dia = d;
                c.Obs = "";
                c.Turno = 2;
                chamadas.Add(c);
            }
            foreach (DateTime d in vespertinosB) //VESPERTINO B
            {
                Chamada c = new Chamada();
                c.CargaHoraria = 90;
                c.Dia = d;
                c.Obs = "";
                c.Turno = 3;
                chamadas.Add(c);
            }
            try
            {
                dao.InserirChamadaMulti(chamadas);
                Program.listaChamadas.atualizartoolStripButton_Click(null, null);
                Program.Mensagem("Chamadas geradas com sucesso!");
                this.Close();
            }catch(Exception ex)
            {
                Program.Erro(ex.Message);
            }
            
        }
        

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //REMOVER APENAS SE ESTIVER SELECIONADO ALGO
            if (listFeriados.SelectedItem == null) return;
            string dataRemover = listFeriados.SelectedItem.ToString();
            for (int i=0;i<feriados.Count;i++)
            {
                if (dataRemover == feriados[i].ToShortDateString())
                {
                    feriados.RemoveAt(i);
                    listFeriados.Items.Remove(dataRemover);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnGerarMatutino_Click(null, null);
            btnGerarVespertinoA_Click(null, null);
            btnGerarVespertinoB_Click(null, null);
        }

        public void RetornaData(DateTime data)
        {
            //verifica duplicidade, se sim nao segue em frente
            for (int i = 0; i < feriados.Count; i++)
            {
                if (feriados[i].ToShortDateString() == data.ToShortDateString()) return;
            }

            //adiciona item feriado selecionado;
            feriados.Add(data);
            listFeriados.Items.Add(data.ToShortDateString());
            listFeriados.Refresh();
        }

        private void lblAddFeriado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.dialogAddFeriado = new DialogAddFeriado(this);
            Program.dialogAddFeriado.ShowDialog();
        }

        private void lblRemoveMatutino_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //REMOVER APENAS SE ESTIVER SELECIONADO ALGO
            if (listMatutino.SelectedItem == null) return;
            string dataRemover = listMatutino.SelectedItem.ToString();
            for (int i = 0; i < matutinos.Count; i++)
            {
                if (dataRemover == matutinos[i].ToShortDateString())
                {
                    matutinos.RemoveAt(i);
                    listMatutino.Items.Remove(dataRemover);
                }
            }
            listMatutino.Refresh();
        }

        private void lblRemoveVespertinoA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //REMOVER APENAS SE ESTIVER SELECIONADO ALGO
            if (listVespertinoA.SelectedItem == null) return;
            string dataRemover = listVespertinoA.SelectedItem.ToString();
            for (int i = 0; i < vespertinosA.Count; i++)
            {
                if (dataRemover == vespertinosA[i].ToShortDateString())
                {
                    vespertinosA.RemoveAt(i);
                    listVespertinoA.Items.Remove(dataRemover);
                }
            }
            listVespertinoA.Refresh();
        }

        private void lblRemoveVespertinoB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //REMOVER APENAS SE ESTIVER SELECIONADO ALGO
            if (listVespertinoB.SelectedItem == null) return;
            string dataRemover = listVespertinoB.SelectedItem.ToString();
            for (int i = 0; i < vespertinosB.Count; i++)
            {
                if (dataRemover == vespertinosB[i].ToShortDateString())
                {
                    vespertinosB.RemoveAt(i);
                    listVespertinoB.Items.Remove(dataRemover);
                }
            }
            listVespertinoB.Refresh();
        }

        private void btnGerarMatutino_Click(object sender, EventArgs e)
        {
            matutinos = GerarDiasLetivos(dtpInicio.Value, dtpFim.Value, cbxMatSeg.Checked, cbxMatTer.Checked, cbxMatQua.Checked, cbxMatQui.Checked, cbxMatSex.Checked, cbxMatSab.Checked, feriados);
            listMatutino.Items.Clear();
            foreach (var d in matutinos)
            {
                listMatutino.Items.Add(d.ToShortDateString());
            }
        }

        private void btnGerarVespertinoA_Click(object sender, EventArgs e)
        {
            vespertinosA = GerarDiasLetivos(dtpInicio.Value, dtpFim.Value, cbxVespASeg.Checked, cbxVespATer.Checked, cbxVespAQua.Checked, cbxVespAQui.Checked, cbxVespASex.Checked, cbxVespASab.Checked, feriados);
            listVespertinoA.Items.Clear();
            foreach (var d in vespertinosA)
            {
                listVespertinoA.Items.Add(d.ToShortDateString());
            }
        }

        private void btnGerarVespertinoB_Click(object sender, EventArgs e)
        {
            vespertinosB = GerarDiasLetivos(dtpInicio.Value, dtpFim.Value, cbxVespBSeg.Checked, cbxVespBTer.Checked, cbxVespBQua.Checked, cbxVespBQui.Checked, cbxVespBSex.Checked, cbxVespBSab.Checked, feriados);
            listVespertinoB.Items.Clear();
            foreach (var d in vespertinosB)
            {
                listVespertinoB.Items.Add(d.ToShortDateString());
            }
        }
        public List<DateTime> GerarDiasLetivos(DateTime dataInicio, DateTime dataFim, bool seg, bool ter, bool qua, bool qui, bool sex, bool sab, List<DateTime> feriados)
        {
            List<DateTime> dias = new List<DateTime>();
            for (DateTime data = dataInicio; data <= dataFim; data = data.AddDays(1))
            {
                bool add = true;
                //Validar se não é feriado
                foreach(DateTime feriado in feriados)
                {
                    if (feriado.ToShortDateString() == data.ToShortDateString())
                    {
                        add = false; //é feriado
                        break;
                    }
                }
                //Validar conforme os dias da semana               
                if (data.DayOfWeek == DayOfWeek.Monday)//segunda
                {
                    if (!seg) add = false;
                }
                if (data.DayOfWeek == DayOfWeek.Tuesday)//terça
                {
                    if (!ter) add = false;
                }
                if (data.DayOfWeek == DayOfWeek.Wednesday)//quarta
                {
                    if (!qua) add = false;
                }
                if (data.DayOfWeek == DayOfWeek.Thursday)//quinta
                {
                    if (!qui) add = false;
                }
                if (data.DayOfWeek == DayOfWeek.Friday)//sexta
                {
                    if (!sex) add = false;
                }
                if (data.DayOfWeek == DayOfWeek.Saturday)//sabado
                {
                    if (!sab) add = false;
                }
                if(data.DayOfWeek == DayOfWeek.Sunday)
                {
                    add = false;
                }
                if (add) //se add for true ainda, adicionar
                {
                    dias.Add(data);
                }
            }
            return dias;
        }
    }
}
