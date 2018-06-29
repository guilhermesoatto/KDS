using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KDSWebApiMVC.Models;
using KDSWebApiMVC.Services;

namespace KDSWebApiMVC.Controllers
{
    public class PedidoController : ApiController
    {
        private Servicos servicos = new Servicos();

        // GET: api/Pedido
        public IQueryable<Pedido> GetPedido()
        {
            return servicos.RetornaPedidos().AsQueryable();
        }

        // GET: api/Pedido/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult GetPedido(int id)
        {
            Pedido pedido = GetPedido().FirstOrDefault(x => x.idPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }


        [Route("api/Pedido/NovoPedido")]
        [HttpPost]
        public HttpResponseMessage NovoPedido(Comanda comanda)
        {
            var a = Request.Content.GetType();

            if (servicos.InserePedido(comanda) == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
