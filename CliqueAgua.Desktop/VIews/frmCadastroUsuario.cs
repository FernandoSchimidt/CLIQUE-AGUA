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
    public partial class frmCadastroUsuario : Form
    {
        PessoaModel pessoaModel = new PessoaModel();
        PessoaController pessoaCont = new PessoaController();
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!txtNome.Text.Equals(null))
            {
                if (!txtEmail.Text.Equals(null))
                {
                    if(txtSenha.Text != txtConfirmaSenha.Text)
                    {
                        MessageBox.Show("As senhas não correspondem!");

                    }
                    else
                    {
                        try
                        {
                            pessoaModel.Nome = txtNome.Text;
                            pessoaModel.Email = txtEmail.Text;
                            pessoaModel.Senha = txtSenha.Text;

                            pessoaCont.Gravar(pessoaModel);

                            MessageBox.Show("Usuario cadastrado com sucesso!");
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Erro ao gravar o usuario " + ex);
                        }
                       
                    }
                }
                else
                {
                    MessageBox.Show("O campo email não pode ser vazio!");

                }
            }
            else
            {
                MessageBox.Show("O campo nome não pode ser vazio!");
            }

        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
