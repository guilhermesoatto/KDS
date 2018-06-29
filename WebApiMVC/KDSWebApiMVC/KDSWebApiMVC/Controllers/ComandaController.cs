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
using System.Web.Http.Results;
using KDSWebApiMVC.Models;
using KDSWebApiMVC.Services;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;

namespace KDSWebApiMVC.Controllers
{
    public class ComandaController : ApiController
    {
        private DataModel db = new DataModel();
        private Servicos servicos = new Servicos();

        // GET: api/Comanda
        public IQueryable<Comanda> GetComanda(string codigoStatusPedido, string canalAtendimento)
        {
            if (!string.IsNullOrEmpty(codigoStatusPedido))
            {
                //filtra pedido de comanda que possue itens neste estatos
            }
            else if (!string.IsNullOrEmpty(canalAtendimento))
            {
                //filtra pedidos de comanda por canal de atedieto
            }
            return servicos.RetornaComandas();

            // return JsonConvert.SerializeObject(comandas,Formatting.Indented);
        }

        // GET: api/Comanda/5
        [ResponseType(typeof(Comanda))]
        public IHttpActionResult GetComanda(int id)
        {
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        // PUT: api/Comanda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComanda(int id, Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comanda.idComanda)
            {
                return BadRequest();
            }

            db.Entry(comanda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Comanda
        [ResponseType(typeof(Comanda))]
        public IHttpActionResult PostComanda(Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comanda.Add(comanda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comanda.idComanda }, comanda);
        }

        // DELETE: api/Comanda/5
        [ResponseType(typeof(Comanda))]
        public IHttpActionResult DeleteComanda(int id)
        {
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return NotFound();
            }

            db.Comanda.Remove(comanda);
            db.SaveChanges();

            return Ok(comanda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComandaExists(int id)
        {
            return db.Comanda.Count(e => e.idComanda == id) > 0;
        }
    }
}