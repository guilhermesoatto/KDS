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
    }
}