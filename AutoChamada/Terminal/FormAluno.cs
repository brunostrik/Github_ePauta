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
    public partial class FormAluno : Form
    {
        private Aluno aluno;
        private FotoAlunoDTO foto;
        private DAO dao;

        public FormAluno(Aluno a)
        {
            InitializeComponent();
            this.aluno = a;
            dao = new DAO();
            //carregar foto
            foto = dao.CarregarFotoAluno(a.Id);
        }
        private void DefineCampos()
        {
            txtNome.Text = aluno.Nome;
            txtCartao.Text = aluno.Cartao;
            txtFoto.Text = foto.IdFoto.ToString();
            picFoto.Image = foto.Foto;
        }

        private void FormProjeto_Load(object sender, EventArgs e)
        {
            DefineCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 1)
            {
                Program.Alerta("Por favor preencha o nome do estudante");
                return;
            }
            if (txtNome.Text.Length < 1)
            {
                Program.Alerta("Por favor preencha o número do cartão");
                return;
            }
            if (txtFoto.Text.Length < 1)
            {
                if (!Program.Pergunta("Salvar sem foto?")) return;
            }
            aluno.Nome = txtNome.Text;
            aluno.Cartao = txtCartao.Text;
            try
            {
                if (aluno.Id == 0)
                {             
                    aluno.Id = dao.AlunoInsert(aluno);
                    //colocar foto tambem
                    SalvarFoto();
                    Program.listaAlunos.CarregarGrid();
                    Program.Mensagem("Novo estudante adicionado com sucesso");
                    this.Close();                
                }else
                {
                    dao.AlunoUpdate(aluno);
                    //colocar foto tambem
                    SalvarFoto();
                    Program.listaAlunos.CarregarGrid();
                    Program.Mensagem("Estudante atualizado com sucesso");
                    this.Close();
                
                }
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            
        }
        private void SalvarFoto()
        {
            try
            {
                if (txtFoto.Text.Length < 1) //SEM FOTO
                {
                    return;
                }
                try
                {
                    if (Convert.ToInt32(txtFoto.Text) == foto.IdFoto) //SEM ALTERACAO DA FOTO
                    {
                        return;
                    }
                }
                catch (Exception) { } //se deu pau é que está correto, vai ser nova foto
                
                if (foto == null)
                {
                    foto = new FotoAlunoDTO();
                    foto.IdAluno = aluno.Id;
                    foto.IdFoto = 0;
                }
                string FileName = txtFoto.Text;
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                foto.Imagem = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                dao.PersistirFotoAluno(foto);                
            }
            catch (Exception ex)
            {
                Program.Erro(ex.Message);
            }
            
        }
        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFoto.Text = ofd.FileName;
                picFoto.Image = Image.FromFile(ofd.FileName);                
            }
        }
    }
}
