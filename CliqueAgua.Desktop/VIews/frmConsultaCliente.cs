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
    public partial class frmConsultaCliente : Form
    {
        PessoaModel pessoaModel = new PessoaModel();
        PessoaController pessoaCont = new PessoaController();
        public frmConsultaCliente()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = pessoaCont.ConsultarPorEmail(pessoaModel);
            
        }

        private void frmConsultaCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
