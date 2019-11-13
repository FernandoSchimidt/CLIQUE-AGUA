using CliqueAgua.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueAgua.Data.Controllers
{
    public partial class PedidoVendaController
    {
        ControllerHelper<PedidoVendaModel> helper;

        public PedidoVendaController()
        {
            helper = new ControllerHelper<PedidoVendaModel>();
        }

        public PedidoVendaModel Gravar(PedidoVendaModel model)
        {
            if (model.Id == 0)
            {
                model.Data = DateTime.Now;
            }
            return helper.Gravar(model, model.Id);
        }

        public void Excluir(PedidoVendaModel model)
        {
            helper.Excluir(model.Id);
        }

        public PedidoVendaModel Consultar(PedidoVendaModel model)
        {
            return helper.Consultar(model.Id);
        }
        public IEnumerable<PedidoVendaModel> Listar()
        {
            return helper.Listar();
        }

        public DataTable ConsultarRawPorCliente(PedidoVendaModel model)
        {
            string query = $@"
select 
	pes.Nome as PessoaCliente_Nome,
	ven.nome as PessoaVendedor_Nome,
	pv.* 
from pedidovenda as pv
inner join Pessoa as pes on pes.id = pv.IdPessoa
left join Pessoa as ven on ven.id = pv.IdPessoaVendedor
where
    pv.idpessoa = {model.IdPessoa}
";
            return helper.ListarRaw(query);
        }

    }
}