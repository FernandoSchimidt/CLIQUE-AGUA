using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class EnderecoController
    {
        ControllerHelper<EnderecoModel> helper;

        public EnderecoController()
        {
            helper = new ControllerHelper<EnderecoModel>();
        }

        public EnderecoModel Gravar(EnderecoModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(EnderecoModel model)
        {
            helper.Excluir(model.Id);
        }

        public EnderecoModel Consultar(EnderecoModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<EnderecoModel> Listar()
        {
            return helper.Listar();
        }
    }
}