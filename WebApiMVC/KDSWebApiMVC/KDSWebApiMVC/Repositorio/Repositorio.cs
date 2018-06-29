using KDSWebApiMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace KDSWebApiMVC.Repositorio
{
    public class Repositorio : IDisposable
    {
        private DataModel db = new DataModel();

        public void Dispose()
        {
            Dispose(true);
        }

        #region UPDATES
        enum CodStatusPedido
        {
            Preparar = 1,
            EmPreparo = 2,
            Pronto = 3,
            Entregue = 4,
            Cancelado = 5
        }

        /// <summary>
        /// Atualiza Item, caso todos os itens estejam no mesmo status atualiza o pedido 
        /// </summary>
        /// <param name="idPedido">Id Pedido</param>
        /// <param name="idItem">Id Item</param>
        /// <param name="idStatus">id Status</param>
        /// <returns></returns>
        public bool AlteraStatusItem(int idPedido, int idItem, int idStatus)
        {

            if (idPedido == 0 || idItem == 0)
            {
                return false;
            }

            //Faz a alteração do Item do Pedido
            Item item = db.Item.Find(idItem);
            Status status = db.Status.Find(idStatus);
            Pedido pedido = db.Pedido.Find(idPedido);

            item.CodigoStatusAtualItem = status.IdStatus;
            item.StatusAtualItem = status.Descricao;

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return AlteraStatusPedido(pedido);
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        /// <summary>
        /// Atualiza o Status do Pedido... Tanto sendo acessado pela atualização de Itens como pelo Pedido direto
        /// </summary>
        /// <param name="pedido">Classe Pedidos</param>
        /// <param name="idStatus">Id Status</param>
        /// <returns></returns>
        public bool AlteraStatusPedido(Pedido pedido, int idStatus = 0)
        {

            /*
             Se for maior que 0, a requisição veio pelo Pedido direto e com isso inicia
             a atualização do Status do Pedido e de seus ítens.
            */
            if (idStatus > 0)
            {
                //Atualiza o Pedido
                Status status = db.Status.Find(idStatus);
                pedido.CodigoStatusAtualPedido = status.IdStatus;
                pedido.StatusAtualPedido = status.Descricao;

                //Faz a busca pelos itens do pedido e os atualiza com o Status do pedido
                var ItensPedido = db.Item.Where(w => w.IdPedido == pedido.IdPedido).ToList();

                foreach (var item in ItensPedido)
                {
                    item.CodigoStatusAtualItem = status.IdStatus;
                    item.StatusAtualItem = status.Descricao;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
            else
            {
                /*
                 Se não tiver Status do pedido, a requisição foi feita pela Classe de atualiza item
                 com isso ele varre e atualiza apenas os itens, mas trata em alguns Status a mudança do Pedido também.
                */

                int totalItensPedido = db.Item.Where(w => w.IdPedido == pedido.IdPedido).Count();
                int itensPedidoPronto = db.Item.Where(w => w.IdPedido == pedido.IdPedido && w.CodigoStatusAtualItem == (int)CodStatusPedido.Pronto).Count();
                int itensPedidoCancelado = db.Item.Where(w => w.IdPedido == pedido.IdPedido && w.CodigoStatusAtualItem == (int)CodStatusPedido.Cancelado).Count();
                int itensPedidoEmPreparo = db.Item.Where(w => w.IdPedido == pedido.IdPedido && w.CodigoStatusAtualItem == (int)CodStatusPedido.EmPreparo).Count();

                if (totalItensPedido == itensPedidoPronto)
                {
                    pedido.StatusAtualPedido = "PRONTO";
                    pedido.CodigoStatusAtualPedido = (int)CodStatusPedido.Pronto;
                }
                else if (itensPedidoCancelado > 0)
                {
                    if (totalItensPedido == itensPedidoCancelado)
                    {
                        pedido.StatusAtualPedido = "CANCELADO";
                        pedido.CodigoStatusAtualPedido = (int)CodStatusPedido.Cancelado;
                    }
                }
                else if (itensPedidoEmPreparo > 0)
                {
                    if (totalItensPedido == itensPedidoEmPreparo)
                    {
                        pedido.StatusAtualPedido = "EM PREPARO";
                        pedido.CodigoStatusAtualPedido = (int)CodStatusPedido.EmPreparo;
                    }
                }
            }

            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Inclusão de Pedido recebido em JSON pelo ATM
        /// </summary>
        /// <param name="comanda"></param>
        /// <returns></returns>
        public Comanda InserePedido(Comanda comanda)
        {
            //Grava a Comanda
            Comanda gravaComanda = new Comanda();
            try
            {                
                gravaComanda.NumeroComanda = comanda.NumeroComanda;
                db.Comanda.Add(gravaComanda);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                comanda.success = false;
            }

            //Gravando Pedido vinculado ao Item
            Pedido gravaPedido = new Pedido();
            try
            {
                gravaPedido.IdComanda = gravaComanda.IdComanda;
                gravaPedido.CanalAtendimento = comanda.Pedidos.FirstOrDefault().CanalAtendimento;
                gravaPedido.CodigoPedido = GeraCodigoPedido();
                gravaPedido.StatusAtualPedido = "PREPARAR";
                gravaPedido.CodigoStatusAtualPedido = (int)CodStatusPedido.Preparar;

                db.Pedido.Add(gravaPedido);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                comanda.success = false;
            }


            //Gravando Item do Pedido vinculado ao Pedido
            foreach (var item in comanda.Pedidos.FirstOrDefault().ItensDoPedido)
            {

                Item gravaItem = new Item();
                try
                {
                    gravaItem.IdPedido = gravaPedido.IdPedido;
                    gravaItem.ObjectId = item.ObjectId;
                    gravaItem.CodigoStatusAtualItem = (int)CodStatusPedido.Preparar;
                    gravaItem.StatusAtualItem = "PREPARAR";
                    gravaItem.Descricao = item.Descricao;
                    gravaItem.Observacao = item.Observacao;
                    gravaItem.TempoMedioPreparacaoEmMinutos = item.TempoMedioPreparacaoEmMinutos;
                    db.Item.Add(gravaItem);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    comanda.success = false;
                }

                //Gravando Item Adicional vinculado ao Item
                foreach (var itemIa in item.AdicionaisItem)
                {
                    ItemAdicional gravaItemAdicional = new ItemAdicional();
                    try
                    {
                        gravaItemAdicional.IdItem = gravaItem.IdItem;
                        gravaItemAdicional.Descricao = itemIa.Descricao;
                        db.ItemAdicional.Add(gravaItemAdicional);
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        comanda.success = false;
                    }
                }

                //Gravando Item Insumo vinculado ao Item
                foreach (var itemI in item.InsumoItem)
                {
                    ItemInsumo gravaItemInsumo = new ItemInsumo();
                    try
                    {
                        gravaItemInsumo.IdItem = gravaItem.IdItem;
                        gravaItemInsumo.ObjectId = itemI.ObjectId;
                        gravaItemInsumo.Descricao = itemI.Descricao;
                        gravaItemInsumo.Remover = itemI.Remover;
                        gravaItemInsumo.Quantidade = itemI.Quantidade;
                        db.ItemInsumo.Add(gravaItemInsumo);
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        comanda.success = false;
                    }
                }

            }

            db.SaveChanges();
            db.Dispose();

            comanda.success = true;
            return comanda;
        }



        /// <summary>
        /// Gerador de Código até 9999, código informado para o cliente para retirada do Pedido
        /// </summary>
        /// <returns></returns>
        private int GeraCodigoPedido()
        {
            var UltimoCodigoPedido = db.Pedido.OrderByDescending(o => o.IdPedido).FirstOrDefault();
            int NovoCodigoPedido = 0;

            if (UltimoCodigoPedido.CodigoPedido == 9999)
            {
                NovoCodigoPedido = 1;
            }
            else
            {
                NovoCodigoPedido = UltimoCodigoPedido.CodigoPedido + 1;
            }

            return NovoCodigoPedido;
        }

        #endregion

        #region LISTAGEM

        public IQueryable<Pedido> RetornaPedidos()
        {
            return db.Pedido;
        }

        public Pedido PegaItensPorPedido(Pedido pedido)
        {
            var itensPedido = new List<Item>();
            itensPedido = db.Item.Where(x => x.IdPedido == pedido.IdPedido).ToList();
            if (itensPedido.Count > 0)
                foreach (var item in itensPedido)
                {
                    item.AdicionaisItem = db.ItemAdicional.Where(x => x.IdItem == item.IdItem).ToList();
                    item.InsumoItem = db.ItemInsumo.Where(x => x.IdItem == item.IdItem).ToList();
                }
            pedido.ItensDoPedido = itensPedido;
            return pedido;
        }

        public IQueryable<Comanda> RetornaComandas()
        {
            return db.Comanda;
        }
        #endregion

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            Dispose(disposing);
        }

    }
}