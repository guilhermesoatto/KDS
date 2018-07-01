using KDSWebApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Services
{
    public class Servicos
    {
        private Repositorio.Repositorio repositorio = new Repositorio.Repositorio();

       /// <summary>
        /// Retorna todos os pedidos e seus itens
        /// </summary>
        /// <returns></returns>
        public IQueryable<Pedido> RetornaPedidos()
        {
            var pedidos = repositorio.RetornaPedidos().ToList();
            var listaPedido = new List<Pedido>();
            if (pedidos.Count > 0)
            {
                foreach (Pedido item in pedidos)
                {
                    listaPedido.Add(repositorio.PegaItensPorPedido(pedidos.FirstOrDefault(x => x.idPedido == item.idPedido)));
                }
            }
            return listaPedido.AsQueryable();
        }

        public Pedido PreencheItensPorPedido(Pedido pedido)
        {
            return repositorio.PegaItensPorPedido(pedido);
        }
        public IQueryable<Comanda> RetornaComandas()
        {
            var comandas = repositorio.RetornaComandas().ToList();
            foreach (var comanda in comandas)
            {
                comanda.success = true;
                //comanda.pedidos = new List<Pedido>();
                comanda.pedidos = RetornaPedidos().Where(x => x.idComanda == comanda.idComanda).ToList();
            }
            return comandas.AsQueryable(); ;
        }
		
		public bool AlteraStatusItem(int idPedido, int idItem, int idStatus)
        {
            return repositorio.AlteraStatusItem(idPedido, idItem, idStatus);
        }

        public bool AlteraStatusPedido(int idPedido, int idStatus)
        {
            var pedido = RetornaPedidos().FirstOrDefault(x => x.idPedido == idPedido);
            return repositorio.AlteraStatusPedido(pedido, idStatus);
        }

        public Comanda InserePedido(Comanda comanda, string canaldeEntrada)
        {
            return repositorio.InserePedido(comanda, canaldeEntrada);
        }

    }
}