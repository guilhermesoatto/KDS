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
        Pedido PegaItensPorPedido(Pedido pedido);
        IQueryable<Pedido> RetornaPedidos();
        Comanda InserePedido(Comanda comanda, string canaldeEntrada);
        bool AlteraStatusPedido(Pedido pedido, int idStatus = 0);
        bool AlteraStatusItem(int idPedido, int idItem, int idStatus);


    }
}
