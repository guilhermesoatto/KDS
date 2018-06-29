using KDSWebApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Services
{
    public class Servicos
    {
        private Repositorio.Repositorio reposito = new Repositorio.Repositorio();

        public List<Pedido> GetPedido()
        {
            return reposito.RetornaPedidos();
        }

        public bool AlteraStatusItem(int idPedido, int idItem, int idStatus)
        {
            return reposito.AlteraStatusItem(idPedido, idItem, idStatus);
        }

        public bool AlteraStatusPedido(int idPedido, int idStatus)
        {
            var pedido = GetPedido().FirstOrDefault(x => x.IdPedido == idPedido);
            return reposito.AlteraStatusPedido(pedido, idStatus);
        }

        public Comanda InserePedido(Comanda comanda)
        {
            return reposito.InserePedido(comanda);
        }

    }
}