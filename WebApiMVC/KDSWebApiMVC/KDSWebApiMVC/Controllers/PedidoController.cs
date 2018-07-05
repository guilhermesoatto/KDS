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


        // PUT: api/Pedido/5/item/50/AlteraStatusItem/2
        [Route("api/Pedido/{idPedido}/item/{idItem}/AlteraStatusItem/{idStatus}")]
        [HttpPut]
        public IHttpActionResult AlteraStatusItem(int idPedido, int idItem, int idStatus)
        {
            if (servicos.AlteraStatusItem(idPedido, idItem, idStatus) == false)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.OK);

        }

        // PUT: api/Pedido/5/AlteraStatusPedido/2
        [Route("api/Pedido/{idPedido}/AlteraStatusPedido/{idStatus}")]
        [HttpPut]
        public IHttpActionResult AlteraStatusPedido(int idPedido, int idStatus)
        {
            if (servicos.AlteraStatusPedido(idPedido, idStatus) == false)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.OK);

        }


        [Route("api/Pedido/NovoPedido")]
        [HttpPut]
        public HttpResponseMessage NovoPedido(Comanda comanda,string canaldeEntrada)
        {
            var a = Request.Content.GetType();

            if (servicos.InserePedido(comanda,canaldeEntrada) == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
