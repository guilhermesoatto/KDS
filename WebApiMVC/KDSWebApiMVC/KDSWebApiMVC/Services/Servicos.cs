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
        public List<Pedido> RetornaPedidos()
        {
            var pedidos = repositorio.RetornaPedidos().ToList();
            var listaPedido = new List<Pedido>();
            if (pedidos.Count > 0)
            {
                foreach (Pedido item in pedidos)
                {
                    listaPedido.Add(repositorio.PegaItensPorPedido(pedidos.Find(x => x.idPedido == item.idPedido)));
                }
            }
            return listaPedido;
        }

        public Pedido PreencheItensPorPedido(Pedido pedido)
        {
            return repositorio.PegaItensPorPedido(pedido);
        }
        public List<Comanda> RetornaComandas()
        {
            var comandas = repositorio.RetornaComandas().ToList();
            foreach (var comanda in comandas)
            {
                comanda.success = true;
                comanda.pedidos = new List<Pedido>();
                comanda.pedidos = RetornaPedidos().FindAll(x => x.idComanda == comanda.idComanda);
            }
            return comandas.ToList();
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

        public Comanda InserePedido(Comanda comanda)
        {
            return repositorio.InserePedido(comanda);
        }

    }
}