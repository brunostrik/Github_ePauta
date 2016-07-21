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
    public partial class DialogAddFeriado : Form
    {
        DataSelectorReturn retornar;
        public DialogAddFeriado(DataSelectorReturn dsr)
        {
            InitializeComponent();
            this.retornar = dsr;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            retornar.RetornaData(dtpFeriado.Value);
            this.Close();
        }
    }
}
