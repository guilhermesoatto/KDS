using KDS.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KDS.Api.Repositorio
{
    public class Repositorio : IDisposable
    {
        //private DataModel db = new DataModel();

        private readonly DataModel db;
        //private DbContext db = new DbContext;

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

            item.codigoStatusAtualItem = (int)status.idStatus;
            item.statusAtualItem = status.descricao;
            item.dataHoraInclusao = DateTime.Now;
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
                pedido.codigoStatusAtualPedido = (int)status.idStatus;
                pedido.statusAtualPedido = status.descricao;

                //Faz a busca pelos itens do pedido e os atualiza com o Status do pedido
                var ItensPedido = db.Item.Where(w => w.idPedido == pedido.idPedido).ToList();

                foreach (var item in ItensPedido)
                {
                    item.codigoStatusAtualItem = (int)status.idStatus;
                    item.statusAtualItem = status.descricao;
                    item.dataHoraInclusao = DateTime.Now;
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

                int totalItensPedido = db.Item.Where(w => w.idPedido == pedido.idPedido).Count();
                int itensPedidoPronto = db.Item.Where(w => w.idPedido == pedido.idPedido && w.codigoStatusAtualItem == (int)CodStatusPedido.Pronto).Count();
                int itensPedidoCancelado = db.Item.Where(w => w.idPedido == pedido.idPedido && w.codigoStatusAtualItem == (int)CodStatusPedido.Cancelado).Count();
                int itensPedidoEmPreparo = db.Item.Where(w => w.idPedido == pedido.idPedido && w.codigoStatusAtualItem == (int)CodStatusPedido.EmPreparo).Count();

                if (totalItensPedido == itensPedidoPronto)
                {
                    pedido.statusAtualPedido = "PRONTO";
                    pedido.codigoStatusAtualPedido = (int)CodStatusPedido.Pronto;
                }
                else if (itensPedidoCancelado > 0)
                {
                    if (totalItensPedido == itensPedidoCancelado)
                    {
                        pedido.statusAtualPedido = "CANCELADO";
                        pedido.codigoStatusAtualPedido = (int)CodStatusPedido.Cancelado;
                    }
                }
                else if (itensPedidoEmPreparo > 0)
                {
                    if (totalItensPedido == itensPedidoEmPreparo)
                    {
                        pedido.statusAtualPedido = "EM PREPARO";
                        pedido.codigoStatusAtualPedido = (int)CodStatusPedido.EmPreparo;
                    }
                }
            }
            pedido.dataHoraInclusao = DateTime.Now;
            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                db.Dispose();
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
        public Comanda InserePedido(Comanda comanda, string canaldeEntrada)
        {
            //Grava a Comanda
            Comanda gravaComanda = new Comanda();
            try
            {
                gravaComanda.numeroComanda = comanda.numeroComanda;
                gravaComanda.dataHoraInclusao = DateTime.Now;
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
                gravaPedido.idComanda = (int)gravaComanda.idComanda;
                gravaPedido.canalAtendimento = canaldeEntrada;
                gravaPedido.codigoPedido = 4;
                gravaPedido.statusAtualPedido = "PREPARAR";
                gravaPedido.codigoStatusAtualPedido = (int)CodStatusPedido.Preparar;
                gravaPedido.dataHoraInclusao = DateTime.Now;
                db.Pedido.Add(gravaPedido);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                comanda.success = false;
            }


            //Gravando Item do Pedido vinculado ao Pedido
            foreach (var item in comanda.pedidos.FirstOrDefault().itensDoPedido)
            {

                Item gravaItem = new Item();
                try
                {
                    gravaItem.idPedido = (int)gravaPedido.idPedido;
                    gravaItem.objectId = item.objectId;
                    gravaItem.codigoStatusAtualItem = (int)CodStatusPedido.Preparar;
                    gravaItem.statusAtualItem = "PREPARAR";
                    gravaItem.descricao = item.descricao;
                    gravaItem.observacao = item.observacao;
                    gravaItem.tempoMedioPreparacaoEmMinutos = item.tempoMedioPreparacaoEmMinutos;
                    gravaItem.dataHoraInclusao = DateTime.Now;
                    db.Item.Add(gravaItem);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    comanda.success = false;
                }

                //Gravando Item Adicional vinculado ao Item
                foreach (var itemIa in item.adicionaisItem)
                {
                    ItemAdicional gravaItemAdicional = new ItemAdicional();
                    try
                    {
                        gravaItemAdicional.idItem = (int)gravaItem.idItem;
                        gravaItemAdicional.descricao = itemIa.descricao;
                        db.ItemAdicional.Add(gravaItemAdicional);
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        comanda.success = false;
                    }
                }

                //Gravando Item Insumo vinculado ao Item
                foreach (var itemI in item.insumoItem)
                {
                    ItemInsumo gravaItemInsumo = new ItemInsumo();
                    try
                    {
                        gravaItemInsumo.idItem = (int)gravaItem.idItem;
                        gravaItemInsumo.objectId = itemI.objectId;
                        gravaItemInsumo.descricao = itemI.descricao;
                        gravaItemInsumo.remover = itemI.remover;
                        gravaItemInsumo.quantidade = itemI.quantidade;
                        db.ItemInsumo.Add(gravaItemInsumo);
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        comanda.success = false;
                    }
                }

            }
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
            var UltimoCodigoPedido = db.Pedido.OrderByDescending(o => o.idPedido).FirstOrDefault();
            int NovoCodigoPedido = 0;

            if (UltimoCodigoPedido.codigoPedido == 9999)
            {
                NovoCodigoPedido = 1;
            }
            else
            {
                NovoCodigoPedido = UltimoCodigoPedido.codigoPedido + 1;
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
            List<Item> itensPedido;
            itensPedido = db.Item.Where(x => x.idPedido == pedido.idPedido).ToList();
            if (itensPedido.Count() > 0)
                foreach (var item in itensPedido)
                {
                    item.adicionaisItem = db.ItemAdicional.Where(x => x.idItem == item.idItem).ToList();
                    item.insumoItem = db.ItemInsumo.Where(x => x.idItem == item.idItem).ToList();
                }
            pedido.itensDoPedido = itensPedido.ToList();
            return pedido;
        }

        public IQueryable<Comanda> RetornaComandas()
        {
            using (var db = new DataModel())
            {
                db.Database.OpenConnection();
                return db.Comanda;
            }

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
