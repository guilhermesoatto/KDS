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

        enum StatusPedido
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
                int itensPedidoPronto = db.Item.Where(w => w.IdPedido == pedido.IdPedido && w.CodigoStatusAtualItem == (int)StatusPedido.Pronto).Count();
                int itensPedidoCancelado = db.Item.Where(w => w.IdPedido == pedido.IdPedido && w.CodigoStatusAtualItem == (int)StatusPedido.Cancelado).Count();
                int itensPedidoEmPreparo = db.Item.Where(w => w.IdPedido == pedido.IdPedido && w.CodigoStatusAtualItem == (int)StatusPedido.EmPreparo).Count();

                if (totalItensPedido == itensPedidoPronto)
                {
                    pedido.StatusAtualPedido = "PRONTO";
                    pedido.CodigoStatusAtualPedido = (int)StatusPedido.Pronto;
                }
                else if (itensPedidoCancelado > 0)
                {
                    if (totalItensPedido == itensPedidoCancelado)
                    {
                        pedido.StatusAtualPedido = "CANCELADO";
                        pedido.CodigoStatusAtualPedido = (int)StatusPedido.Cancelado;
                    }
                }
                else if (itensPedidoEmPreparo > 0)
                {
                    if (totalItensPedido == itensPedidoEmPreparo)
                    {
                        pedido.StatusAtualPedido = "EM PREPARO";
                        pedido.CodigoStatusAtualPedido = (int)StatusPedido.EmPreparo;
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

        public Comanda InserePedido(Comanda comanda)
        {

            Comanda gravaComanda = new Comanda();

            gravaComanda.NumeroComanda = comanda.NumeroComanda;
            db.Comanda.Add(gravaComanda);
            db.SaveChanges();




            Pedido gravaPedido = new Pedido();

            gravaPedido.IdComanda = gravaComanda.IdComanda;
            gravaPedido.CanalAtendimento = comanda.Pedidos.FirstOrDefault().CanalAtendimento;
            gravaPedido.CodigoPedido = GeraCodigoPedido();
            gravaPedido.StatusAtualPedido = "PREPARAR";
            //gravaPedido
            

            comanda.success = true;
            return null;
        }

        private int GeraCodigoPedido()
        {
            return DateTime.Now.Minute;
        }

        #endregion

        #region LISTAGEM
            public List<Pedido> RetornaPedidos()
            {
                return db.Pedido.ToList();
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