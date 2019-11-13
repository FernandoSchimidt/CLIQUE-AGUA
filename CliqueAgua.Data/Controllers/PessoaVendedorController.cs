using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PessoaVendedorController
    {
        ControllerHelper<PessoaVendedorModel> helper;

        public PessoaVendedorController()
        {
            helper = new ControllerHelper<PessoaVendedorModel>();
        }

        public PessoaVendedorModel Gravar(PessoaVendedorModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PessoaVendedorModel model)
        {
            helper.Excluir(model.Id);
        }
        public IEnumerable<PessoaVendedorModel> Listar()
        {
            return helper.Listar();
        }
        public PessoaVendedorModel Consultar(PessoaVendedorModel model)
        {
            return helper.Consultar(model.Id);
        }

    }
}