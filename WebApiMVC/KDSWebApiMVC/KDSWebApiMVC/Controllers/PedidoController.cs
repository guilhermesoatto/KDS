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
        private DataModel db = new DataModel();
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
            Pedido pedido = db.Pedido.Find(id);
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

        // PUT: api/Pedido/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPedido(int id, int idStatus, string statusAtual, Pedido pedido)
        //{
        //    if (servicos.AlteraStatus(id, idStatus, statusAtual) == false)
        //    {
        //        return StatusCode(HttpStatusCode.BadRequest);
        //    }

        //    return StatusCode(HttpStatusCode.OK);

        //}

        // POST: api/Pedido
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult PostPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedido.Add(pedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido.IdPedido }, pedido);
        }

        // DELETE: api/Pedido/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult DeletePedido(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            db.Pedido.Remove(pedido);
            db.SaveChanges();

            return Ok(pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoExists(int id)
        {
            return db.Pedido.Count(e => e.IdPedido == id) > 0;
        }
    }
}