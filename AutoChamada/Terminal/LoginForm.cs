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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.telaTerminal = new TelaTerminal();
            Program.telaTerminal.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entrar();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Entrar()
        {
            if (new DAO().Config("senha") == txtSenha.Text)
            {
                this.Close();
            }else
            {
                Program.Alerta("Senha incorreta");
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Entrar();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                string modoTerminal = System.Configuration.ConfigurationSettings.AppSettings["MODO_TERMINAL"];
                if(modoTerminal == "true")
                {
                    button1_Click(null, null);
                }
            }
            catch (Exception) { }
        }
    }
}
