﻿using KDS.Api.Models;
using KDS.Api.Repositorio.Interface;
using KDS.Api.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Services
{
    public class Servicos : IService
    {
        //private Repositorio.Repositorio repositorio = new Repositorio.Repositorio();

        private readonly IRepository repositorio;

        public Servicos(IRepository _repositorio)
        {
            repositorio = _repositorio;
        }

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

        public IQueryable<Comanda> RetornaComandaPorStatus(string codigoStatusPedido)
        {
            var comandas = repositorio.RetornaComandas().ToList();
            var listaStatus = codigoStatusPedido.Split('_').ToList();
            foreach (var comanda in comandas)
            {
                comanda.success = true;
                //comanda.pedidos = new List<Pedido>();                
                comanda.pedidos = RetornaPedidos().Where(x => x.idComanda == comanda.idComanda &&
                listaStatus.Contains(x.codigoStatusAtualPedido.ToString())).ToList();
                //comanda.pedidos = RetornaPedidos().Where(x => x.idComanda == comanda.idComanda &&
                //x.codigoStatusAtualPedido == int.Parse(codigoStatusPedido)).ToList();
            }
            return comandas.AsQueryable();
        }

        public IQueryable<Comanda> RetornaComandaPorCanal(string canalDeAtendimento)
        {
            var comandas = repositorio.RetornaComandas().ToList();
            foreach (var comanda in comandas)
            {
                comanda.success = true;
                //comanda.pedidos = new List<Pedido>();
                comanda.pedidos = RetornaPedidos().Where(x => x.idComanda == comanda.idComanda &&
                x.canalAtendimento == canalDeAtendimento).ToList();
            }
            return comandas.AsQueryable();
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
            return comandas.AsQueryable();
        }

        public bool AlteraStatusItem(long idPedido, long idItem, long idStatus)
        {
            return repositorio.AlteraStatusItem(idPedido, idItem, idStatus);
        }

        public bool AlteraStatusPedido(long idPedido, long idStatus)
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
