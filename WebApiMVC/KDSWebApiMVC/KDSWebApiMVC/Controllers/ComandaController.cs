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

namespace KDSWebApiMVC.Controllers
{
    public class ComandaController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/Comanda
        public IQueryable<Comanda> GetComanda()
        {
            return db.Comanda;
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

            if (id != comanda.IdComanda)
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

            return CreatedAtRoute("DefaultApi", new { id = comanda.IdComanda }, comanda);
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
            return db.Comanda.Count(e => e.IdComanda == id) > 0;
        }
    }
}