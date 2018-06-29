using KDSWebApiMVC.Models;
using System;
using System.Collections.Generic;
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