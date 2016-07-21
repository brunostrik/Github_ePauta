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
    public partial class FormMatricula : Form
    {

        private MatriculaDTO matriculas;
        private DAO dao;
        private int idAluno;

        public FormMatricula(int idAluno)
        {
            InitializeComponent();
            dao = new DAO();
            this.idAluno = idAluno;
        }
        private void IniciaCombos()
        {
            //Iniciar combos individualmente, carregando apenas os projetos possíveis para aquele dia da semana e turno e a opção 0-Nenhum
            List<ProjetoDTO> mid = dao.CarregarProjetosDiaTurno(-1, 1);
            //MATUTINO
            cmbProjetoMatutino.DataSource = mid;
            DefineCombo(cmbProjetoMatutino, matriculas.projetoMatutino);
            //SEGUNDA
            cmbProjetoD0T2.DataSource = dao.CarregarProjetosDiaTurno(0, 2);
            DefineCombo(cmbProjetoD0T2, matriculas.projetoD0T2);
            cmbProjetoD0T3.DataSource = dao.CarregarProjetosDiaTurno(0, 3);
            DefineCombo(cmbProjetoD0T3, matriculas.projetoD0T3);
            //TERÇA
            cmbProjetoD1T2.DataSource = dao.CarregarProjetosDiaTurno(1, 2);
            DefineCombo(cmbProjetoD1T2, matriculas.projetoD1T2);
            cmbProjetoD1T3.DataSource = dao.CarregarProjetosDiaTurno(1, 3);
            DefineCombo(cmbProjetoD1T3, matriculas.projetoD1T3);
            //QUARTA
            cmbProjetoD2T2.DataSource = dao.CarregarProjetosDiaTurno(2, 2);
            DefineCombo(cmbProjetoD2T2, matriculas.projetoD2T2);
            cmbProjetoD2T3.DataSource = dao.CarregarProjetosDiaTurno(2, 3);
            DefineCombo(cmbProjetoD2T3, matriculas.projetoD2T3);
            //QUINTA
            cmbProjetoD3T2.DataSource = dao.CarregarProjetosDiaTurno(3, 2);
            DefineCombo(cmbProjetoD3T2, matriculas.projetoD3T2);
            cmbProjetoD3T3.DataSource = dao.CarregarProjetosDiaTurno(3, 3);
            DefineCombo(cmbProjetoD3T3, matriculas.projetoD3T3);
            //SEXTA
            cmbProjetoD4T2.DataSource = dao.CarregarProjetosDiaTurno(4, 2);
            DefineCombo(cmbProjetoD4T2, matriculas.projetoD4T2);
            cmbProjetoD4T3.DataSource = dao.CarregarProjetosDiaTurno(4, 3);
            DefineCombo(cmbProjetoD4T3, matriculas.projetoD0T3);
        }
        private void CarregarDados()
        {
            //Carrega quais os projetos escolhidos pelo estudante e depois marca na combo aquela opção
            matriculas = dao.CarregarMatriculas(idAluno);
            lblEstudante.Text = matriculas.aluno.Nome;
        }

        private void FormMatricula_Load(object sender, EventArgs e)
        {
            CarregarDados();
            IniciaCombos();          
        }

        private void DefineCombo(ComboBox cmb, AlunoProjeto ap)
        {
            if (ap == null)
            {
                ap = new AlunoProjeto();
                ap.Id = 0;
                ap.IdAluno = idAluno;
                ap.IdProjeto = 0;
            }
            cmb.SelectedValue = ap.IdProjeto;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //validar a carga horaria e pedir janela de confirmacao se tem certeza, observando que segundo o ppc sao 9h aula a tarde
            //Validar se escolheu projeto obrigatório matutino
            if (cmbProjetoMatutino.Text == "Nenhum")
            {
                if (!Program.Pergunta("Você selecionou nenhum projeto matutino.\r\nDeseja prosseguir?")) return;
            }
            //validar se os projetos da tarde cumprem a CH de 9h do PPC
            double chTarde = 0;
            if (cmbProjetoD0T2.Text != "Nenhum") chTarde += 1.5; //SEG A
            if (cmbProjetoD0T3.Text != "Nenhum") chTarde += 1.5; //SEG B
            if (cmbProjetoD1T2.Text != "Nenhum") chTarde += 1.5; //TER A
            if (cmbProjetoD1T3.Text != "Nenhum") chTarde += 1.5; //TER B
            if (cmbProjetoD2T2.Text != "Nenhum") chTarde += 1.5; //QUA A
            if (cmbProjetoD2T3.Text != "Nenhum") chTarde += 1.5; //QUA B
            if (cmbProjetoD3T2.Text != "Nenhum") chTarde += 1.5; //QUI A
            if (cmbProjetoD3T3.Text != "Nenhum") chTarde += 1.5; //QUI B
            if (cmbProjetoD4T2.Text != "Nenhum") chTarde += 1.5; //SEX A
            if (cmbProjetoD4T3.Text != "Nenhum") chTarde += 1.5; //SEX B
            if (chTarde < 9)
            {
                if (!Program.Pergunta("Os projetos optativos (tarde) selecionados não totalizam a carga horária de 9 horas semanais definidas no PPC do curso (Você selecionou "+chTarde+").\r\nDeseja prosseguir?")) return;
            }
            ///// MATUTINO /////
            if (matriculas.projetoMatutino == null)
            {
                matriculas.projetoMatutino = new AlunoProjeto();
                matriculas.projetoMatutino.IdAluno = idAluno;
            }
            matriculas.projetoMatutino.IdProjeto = ((ProjetoDTO)cmbProjetoMatutino.SelectedItem).Id;

            ///// SEGUNDA FEIRA /////
            //A
            if (matriculas.projetoD0T2 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD0T2 = new AlunoProjeto();
                matriculas.projetoD0T2.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD0T2.IdProjeto = ((ProjetoDTO)cmbProjetoD0T2.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD0T2.Id != 0 && matriculas.projetoD0T2.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Segunda-feira Vespertino A.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }
            //B
            if (matriculas.projetoD0T3 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD0T3 = new AlunoProjeto();
                matriculas.projetoD0T3.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD0T3.IdProjeto = ((ProjetoDTO)cmbProjetoD0T3.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD0T3.Id != 0 && matriculas.projetoD0T3.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Segunda-feira Vespertino B.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }

            ///// TERÇA FEIRA /////
            //A
            if (matriculas.projetoD1T2 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD1T2 = new AlunoProjeto();
                matriculas.projetoD1T2.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD1T2.IdProjeto = ((ProjetoDTO)cmbProjetoD1T2.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD1T2.Id != 0 && matriculas.projetoD1T2.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Terça-feira Vespertino A.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }
            //B
            if (matriculas.projetoD1T3 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD1T3 = new AlunoProjeto();
                matriculas.projetoD1T3.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD1T3.IdProjeto = ((ProjetoDTO)cmbProjetoD1T3.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD1T3.Id != 0 && matriculas.projetoD1T3.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Terça-feira Vespertino B.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }

            ///// QUARTA FEIRA /////
            //A
            if (matriculas.projetoD2T2 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD2T2 = new AlunoProjeto();
                matriculas.projetoD2T2.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD2T2.IdProjeto = ((ProjetoDTO)cmbProjetoD2T2.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD2T2.Id != 0 && matriculas.projetoD2T2.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Quarta-feira Vespertino A.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }
            //B
            if (matriculas.projetoD2T3 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD2T3 = new AlunoProjeto();
                matriculas.projetoD2T3.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD2T3.IdProjeto = ((ProjetoDTO)cmbProjetoD2T3.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD2T3.Id != 0 && matriculas.projetoD2T3.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Quarta-feira Vespertino B.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }

            ///// QUINTA FEIRA /////
            //A
            if (matriculas.projetoD3T2 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD3T2 = new AlunoProjeto();
                matriculas.projetoD3T2.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD3T2.IdProjeto = ((ProjetoDTO)cmbProjetoD3T2.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD3T2.Id != 0 && matriculas.projetoD3T2.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Quinta-feira Vespertino A.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }
            //B
            if (matriculas.projetoD3T3 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD3T3 = new AlunoProjeto();
                matriculas.projetoD3T3.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD3T3.IdProjeto = ((ProjetoDTO)cmbProjetoD3T3.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD3T3.Id != 0 && matriculas.projetoD3T3.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Quinta-feira Vespertino B.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }

            ///// SEXTA FEIRA /////
            //A
            if (matriculas.projetoD4T2 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD4T2 = new AlunoProjeto();
                matriculas.projetoD4T2.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD4T2.IdProjeto = ((ProjetoDTO)cmbProjetoD4T2.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD4T2.Id != 0 && matriculas.projetoD4T2.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Sexta-feira Vespertino A.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }
            //B
            if (matriculas.projetoD4T3 == null) //Analisa se a entidade esta nula e cria se necessario
            {
                matriculas.projetoD4T3 = new AlunoProjeto();
                matriculas.projetoD4T3.IdAluno = idAluno;
            }
            //Atualiza a entidade
            matriculas.projetoD4T3.IdProjeto = ((ProjetoDTO)cmbProjetoD4T3.SelectedItem).Id; //Coloca o projeto selecionado dentro da entidade

            if (matriculas.projetoD4T3.Id != 0 && matriculas.projetoD4T3.IdProjeto == 0) //Analisa se não está removendo o projeto da agenda do aluno
            {
                if (!Program.Pergunta("Você removeu o projeto da Sexta-feira Vespertino B.\r\nAs chamadas deste estudante já registradas neste dia e turno serão perdidas.\r\nDeseja prosseguir?")) return;
            }

            //HORA DE PERSISTIR
            try
            {
                dao.SalvarMatriculas(matriculas);
                Program.Mensagem("Projetos do estudante " + lblEstudante.Text + " salvos com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
        }
    }
}
