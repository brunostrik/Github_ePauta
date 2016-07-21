using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal
{
    static class Program
    {

        public static TelaTerminal telaTerminal;
        public static RelatorioForm relatorioForm;
        public static LoginForm loginForm;
        public static TelaPrincipal formPrincipal;
        public static RelatorioEstudanteForm relatorioEstudanteForm;
        public static ListaProjetos listaProjetos;
        public static FormProjeto formProjeto;
        public static ListaAlunos listaAlunos;
        public static FormAluno formAluno;
        public static FormMatricula formMatricula;
        public static ListaChamadas listaChamadas;
        public static FormChamada formObservacoesChamada;
        public static FormChamadaAvulsa formChamadaAvulsa;
        public static FormMesLetivo formMesLetivo;
        public static DialogAddFeriado dialogAddFeriado;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formPrincipal = new TelaPrincipal();
            Application.Run(formPrincipal);            
        }

        //INTERACOES COMUNS UNIFICADAS
        public static void Alerta(string mensagem)
        {
            MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void Mensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        public static void Erro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Pergunta(string mensagem)
        {
            return MessageBox.Show(mensagem, "Pergunta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static string DiaDaSemana(int dia)
        {
            switch (dia)
            {
                case 0:
                    return "Segunda-feira";
                case 1:
                    return "Terça-feira";
                case 2:
                    return "Quarta-feira";
                case 3:
                    return "Quinta-feira";
                case 4:
                    return "Sexta-feira";
                case 5:
                    return "Sábado";
                case 6:
                    return "Domingo";
                default:
                    return "Semanal";
            }
        }
        public static string Turno(int turno)
        {
            switch (turno)
            {
                case 1:
                    return "Matutino";
                case 2:
                    return "Vespertino A";
                case 3:
                    return "Vespertino B";
                default:
                    return "ERRO";
            }
        }
    }
}
