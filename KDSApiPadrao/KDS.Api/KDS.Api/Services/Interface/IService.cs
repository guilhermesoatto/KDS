using KDS.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KDS.Api.Services.Interface
{
    public interface IService
    {
        IQueryable<Pedido> RetornaPedidos();
        Pedido PreencheItensPorPedido(Pedido pedido);
        IQueryable<Comanda> RetornaComandas();
        IQueryable<Comanda> RetornaComandaPorCanal(string canalAtendimento);
        IQueryable<Comanda> RetornaComandaPorStatus(string codigoStatusPedido);
        bool AlteraStatusItem(int idPedido, int idItem, int idStatus);
        bool AlteraStatusPedido(int idPedido, int idStatus);
        Comanda InserePedido(Comanda comanda, string canaldeEntrada);

    }
}
