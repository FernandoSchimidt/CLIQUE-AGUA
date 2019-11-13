using CliqueAgua.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class CidadeController
    {
        ControllerHelper<CidadeModel> helper;

        public CidadeController()
        {
            helper = new ControllerHelper<CidadeModel>();
        }

        public CidadeModel Gravar(CidadeModel model)
        {
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(CidadeModel model)
        {
            helper.Excluir(model.Id);
        }

        public CidadeModel Consultar(CidadeModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<CidadeModel> Listar()
        {
            return helper.Listar();
        }
    }
}