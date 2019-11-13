using CliqueAgua.Data.Controllers;
using CliqueAgua.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CliqueAgua.Desktop.VIews
{
    public partial class frmConsultaCadastroUsuario : Form
    {
        PessoaModel pessoaModel = new PessoaModel();
        PessoaController pessoaCont = new PessoaController();
        public frmConsultaCadastroUsuario()
        {
            InitializeComponent();
            
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            
        }

        private void frmConsultaCadastroUsuario_Load(object sender, EventArgs e)
        {
            //dgvDados.DataSource = pessoaCont.Listar( pessoaModel);
        }
    }
}
