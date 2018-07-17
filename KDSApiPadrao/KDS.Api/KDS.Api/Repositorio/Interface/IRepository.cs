using KDS.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Repositorio.Interface
{
    public interface IRepository
    {
        IQueryable<Comanda> RetornaComandas();
        IQueryable<Comanda> RetornaComandaPorCanal(string canalAtendimento);
        IQueryable<Comanda> RetornaComandaPorStatus(string codigoStatusPedido);
        Pedido PegaItensPorPedido(Pedido pedido);
        IQueryable<Pedido> RetornaPedidos();
        Comanda InserePedido(Comanda comanda, string canaldeEntrada);
        bool AlteraStatusPedido(Pedido pedido, long idStatus = 0);
        bool AlteraStatusItem(long idPedido, long idItem, long idStatus);


    }
}
