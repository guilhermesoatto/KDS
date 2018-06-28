using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KDSApi.Domain.Entities;
using KDSApi.Infra.SqlServer.Context;

namespace KDSApi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Comanda")]
    public class ComandaController : Controller
    {
        private readonly SqlServerCrudDbContext _context;

        public ComandaController(SqlServerCrudDbContext context)
        {
            _context = context;
        }

        // GET: api/Comanda
        [HttpGet]
        public IEnumerable<Comanda> GetComanda()
        {
            return _context.Comanda;
        }

        // GET: api/Comanda/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComanda([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comanda = await _context.Comanda.SingleOrDefaultAsync(m => m.IdComanda == id);

            if (comanda == null)
            {
                return NotFound();
            }

            return Ok(comanda);
        }

        // PUT: api/Comanda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComanda([FromRoute] int id, [FromBody] Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comanda.IdComanda)
            {
                return BadRequest();
            }

            _context.Entry(comanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/Comanda
        [HttpPost]
        public async Task<IActionResult> PostComanda([FromBody] Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comanda.Add(comanda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComanda", new { id = comanda.IdComanda }, comanda);
        }

        // DELETE: api/Comanda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComanda([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comanda = await _context.Comanda.SingleOrDefaultAsync(m => m.IdComanda == id);
            if (comanda == null)
            {
                return NotFound();
            }

            _context.Comanda.Remove(comanda);
            await _context.SaveChangesAsync();

            return Ok(comanda);
        }

        private bool ComandaExists(int id)
        {
            return _context.Comanda.Any(e => e.IdComanda == id);
        }
    }
}