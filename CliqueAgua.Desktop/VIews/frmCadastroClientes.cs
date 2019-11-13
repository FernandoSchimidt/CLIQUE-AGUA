using CliqueAgua.Data.Controllers;
using CliqueAgua.Data.Ferramentas;
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
    public partial class frmCadastroClientes : Form
    {
        PessoaFisicaModel pessoaF = new PessoaFisicaModel();
        PessoaJuridicaModel pessoaJ = new PessoaJuridicaModel();
        PessoaFisicaController pessoaFCon = new PessoaFisicaController();
        PessoaJuridicaController pessoaJCon = new PessoaJuridicaController();
        EnderecoModel endModel = new EnderecoModel();
        EnderecoController endCont = new EnderecoController();
        CidadeModel cidModel = new CidadeModel();
        CidadeController cidCont = new CidadeController();
        

        public frmCadastroClientes()
        {
            InitializeComponent();
        }

        private void mskCep_Leave(object sender, EventArgs e)
        {
            if (buscarEndereco.verificaCEP(mskCep.Text).Equals(true))
            {
                txtEstado.Text = buscarEndereco.estado;
                txtCidade.Text = buscarEndereco.cidade;
                txtEndereco.Text = buscarEndereco.endereco;
            }
        }

        private void radioJuridica_CheckedChanged(object sender, EventArgs e)
        {
            txtRazaoSocial.Enabled = true;
        }

        private void txtCpfCnpj_Leave(object sender, EventArgs e)
        {
            lblInvalido.Visible = false;
            if (radioFisica.Checked == true)
            {
                //validar o cpf
                if (validacoes.IsCpf(txtCpfCnpj.Text).Equals(false))
                {
                    lblInvalido.Visible = true;
                }
            }
            else
            {
                if (validacoes.IsCnpj(txtCpfCnpj.Text).Equals(false))
                {
                    lblInvalido.Visible = true;
                    txtCpfCnpj.Focus();
                }
            }
        }

        private void radioFisica_CheckedChanged(object sender, EventArgs e)
        {
            txtRazaoSocial.Enabled = false;
        }
        public int  SalvarEndereco()
        {
            
            //Cadastra a Cidade
            cidModel.Nome = txtCidade.Text;
            cidModel.Uf = txtEstado.Text;
            cidModel = cidCont.Gravar(cidModel);
            
            //Cadastra o endereco
            endModel.IdCidade = cidModel.Id;
            endModel.Complemento = txtComplemento.Text;
            endModel.Cep = mskCep.Text;
            endModel.Logradouro = txtEndereco.Text;
            endModel.Numero = txtNumero.Text;
            endModel = endCont.Gravar(endModel);

            //retorno do id para ser usado na classe pessoa
            return endModel.Id;

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text != null)
            {
                if(txtCpfCnpj.Text != null)
                {
                    if(mskFone.Text != null)
                    {

                    }
                    else
                    {
                        MessageBox.Show("O campo nome não pode ser vazio.");
                        mskFone.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("O campo CPF/CNPJ não pode ser vazio.");
                    txtCpfCnpj.Focus();
                }
            }
            else
            {
                MessageBox.Show("O campo nome não pode ser vazio.");
                txtNome.Focus();
            }

            SalvarEndereco();
            try
            {
                //Cadastro de Cliente fisica
                if (radioFisica.Checked)
                {
                    pessoaF.Nome = txtNome.Text;
                    pessoaF.Telefone = mskFone.Text;
                    pessoaF.Email = txtEmail.Text;
                    pessoaF.Fisica = true;
                    pessoaF.Cpf = txtCpfCnpj.Text;
                    pessoaF.Rg = txtRgIe.Text;
                    pessoaF.Senha = txtSenha.Text;
                    pessoaF.IdEndereco = SalvarEndereco();
                    
                    pessoaFCon.Gravar(pessoaF);
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                    Limpartela();
                }
                else
                {
                    //Cadastro de Cliente juridica
                    pessoaJ.Nome = txtNome.Text;
                    pessoaJ.Telefone = mskFone.Text;
                    pessoaJ.Email = txtEmail.Text;
                    pessoaJ.Fisica = true;
                    pessoaJ.Cnpj = txtCpfCnpj.Text;
                    pessoaJ.InsEstadual = txtRgIe.Text;
                    pessoaJ.Senha = txtSenha.Text;
                    pessoaJ.IdEndereco = SalvarEndereco();


                    pessoaJCon.Gravar(pessoaJ);
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                    Limpartela();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar " + ex);
            }


        }

        private void txtConfirmaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        public void Limpartela()
        {
            //Limpa os campos 

            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtConfirmaSenha.Clear();
            txtEndereco.Clear();
            mskFone.Clear();
            mskCep.Clear();
            txtCpfCnpj.Clear();
            txtRgIe.Clear();
            txtNumero.Clear();
            txtCidade.Clear();
        }

        private void txtConfirmaSenha_Leave(object sender, EventArgs e)
        {
            //Ativa o label se as senhas nao corresponderem
            if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                lblSenhas.Enabled = true;
                txtSenha.Focus();
            }
        }
    }
}
