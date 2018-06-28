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

        public List<Pedido> RetornaPedidos()
        {
            return db.Pedido.ToList();
        }

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