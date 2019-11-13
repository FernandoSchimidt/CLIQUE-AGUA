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
        public int SalvarEndereco()
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
            if (!txtNome.Text.Trim().Equals(""))
            {
                if (!txtCpfCnpj.Text.Trim().Equals(""))
                {
                    if (!mskFone.Text.Trim().Equals(""))
                    {
                        if (!txtEmail.Text.Trim().Equals(""))
                        {
                            if (!txtSenha.Text.Trim().Equals(""))
                            {
                                if (!txtRgIe.Text.Trim().Equals(""))
                                {
                                    if (!txtEndereco.Text.Trim().Equals(""))
                                    {
                                        if (!txtNumero.Text.Trim().Equals(""))
                                        {
                                            if (!mskCep.Text.Trim().Equals(""))
                                            {
                                                if (!txtCidade.Text.Trim().Equals(""))
                                                {
                                                    if (!txtEstado.Text.Trim().Equals(""))
                                                    {


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
                                                                if(txtSenha.Text != txtConfirmaSenha.Text)
                                                                {
                                                                    MessageBox.Show("As senhas não correspondem");
                                                                    txtSenha.Focus();
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    pessoaF.Senha = txtSenha.Text;
                                                                                                                                        
                                                                }
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
                                                                if (txtSenha.Text != txtConfirmaSenha.Text)
                                                                {
                                                                    MessageBox.Show("As senhas não correspondem");
                                                                    txtSenha.Focus();
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    pessoaJ.Senha = txtSenha.Text;

                                                                }
                                                               
                                                                pessoaJ.IdEndereco = SalvarEndereco();


                                                                pessoaJCon.Gravar(pessoaJ);
                                                                MessageBox.Show("Cliente cadastrado com sucesso!");
                                                                alteraBotoes(1);
                                                                Limpartela();

                                                            }

                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Erro ao cadastrar " + ex);
                                                        }



                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("O campo estado não pode ser vazio.");
                                                        txtEstado.Focus();
                                                        return;

                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("O campo cidade não pode ser vazio.");
                                                    txtCidade.Focus();
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("O campo CEP não pode ser vazio.");
                                                mskCep.Focus();
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("O campo numero não pode ser vazio.");
                                            txtNumero.Focus();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("O campo endereço não pode ser vazio.");
                                        txtEndereco.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("O campo RG/IE não pode ser vazio.");
                                    txtRgIe.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("O campo senha não pode ser vazio.");
                                txtSenha.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("O campo email não pode ser vazio.");
                            txtEmail.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("O campo telefone não pode ser vazio.");
                        mskFone.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("O campo CPF/CNPJ não pode ser vazio.");
                    txtCpfCnpj.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("O campo nome não pode ser vazio.");
                txtNome.Focus();
                return;
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
            txtEstado.Clear();
        }

        private void txtConfirmaSenha_Leave(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.Limpartela();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            alteraBotoes(1);
            Limpartela();
        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
        

            frmConsultaCliente f = new frmConsultaCliente();
            f.ShowDialog();

            txtCodigo.Text = f.pessoaModel.Id.ToString();
            txtNome.Text = f.pessoaModel.Nome.ToString();
            mskFone.Text = f.pessoaModel.Telefone.ToString();
            txtEmail.Text = f.pessoaModel.Email.ToString();
            if(f.pessoaModel.Fisica == true)
            {
                radioFisica.Checked = true;
            }
            else
            {
                radioJuridica.Checked = true;
            }

            // incluir rotina de preencher os campos

            f.Dispose();
            
            //apos ter puxado o dado
            alteraBotoes(3);
        }
        public void alteraBotoes(int op)
        {
            //op = operações que serão feitas com os botoes
            // 1 = preparar os botoes para inserir e localiza
            // 2 = prepara os botoes para inserir/alterar um registro
            // 3 = prepara a tela para excluir ou alterar

            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnPesquisar.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;

            if (op.Equals(1))
            {
                btnNovo.Enabled = true;
                btnPesquisar.Enabled = true;
            }
            if (op.Equals(2))
            {
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                btnExcluir.Enabled = false;
            }
            if (op.Equals(3))
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            alteraBotoes(1);
        }

        private void frmCadastroClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
