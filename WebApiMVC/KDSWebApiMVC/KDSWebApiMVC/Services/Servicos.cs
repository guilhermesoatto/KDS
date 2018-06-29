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
                    listaPedido.Add(repositorio.PegaItensPorPedido(pedidos.Find(x => x.IdPedido == item.IdPedido)));

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
                comanda.Pedidos = new List<Pedido>();
                comanda.Pedidos = RetornaPedidos().FindAll(x => x.IdComanda == comanda.IdComanda);
            }
            return comandas.ToList();
        }
    }
}