using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KDS.Api.Models;
using KDS.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace KDS.Api.Controllers
{
    //[Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly DataModel _db;
        private readonly Servicos servicos;

        public ValuesController(DataModel db, Servicos _servicos)
        {
            _db = db;
            servicos = _servicos;
        }


        //private Servicos servicos;

        //public ValuesController(Servicos _servicos)
        //{
        //    servicos = _servicos;
        //}

        

        //public ValuesController(Servicos _servicos)
        //{
        //    servicos = _servicos;
        //}

        // GET api/values
        [HttpGet("api/values")]
        public List<Comanda> Get()
        {
            var h = _db.Comanda.ToList();
            return h;

            //return new string[] { "value1", "value2" };
        }



        #region Comanda
        [HttpGet("api/Comanda")]
        public IQueryable<Comanda> GetComanda(string codigoStatusPedido = null, string canalAtendimento = null)
        {
            if (!string.IsNullOrEmpty(codigoStatusPedido))
            {
                return servicos.RetornaComandaPorStatus(codigoStatusPedido).AsQueryable();
            }
            else if (!string.IsNullOrEmpty(canalAtendimento))
            {
                return servicos.RetornaComandaPorCanal(canalAtendimento).AsQueryable();
            }
            return servicos.RetornaComandas();

            // return JsonConvert.SerializeObject(comandas,Formatting.Indented);
        }

        #endregion




        #region Pedidos

        // GET: api/Pedido
        [HttpGet("api/Pedido")]
        public IQueryable<Pedido> GetPedido()
        {
            return servicos.RetornaPedidos().AsQueryable();
        }

        // PUT: api/Pedido/5/item/50/AlteraStatusItem/2
        //[Route("api/Pedido/{idPedido}/item/{idItem}/AlteraStatusItem/{idStatus}")]
        [HttpPut ("api/Pedido/{idPedido}/item/{idItem}/AlteraStatusItem/{idStatus}")]
        public HttpResponseMessage AlteraStatusItem(int idPedido, int idItem, int idStatus)
        {
            if (servicos.AlteraStatusItem(idPedido, idItem, idStatus) == false)
            {
                return new HttpResponseMessage (HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage (HttpStatusCode.OK);

        }

        // PUT: api/Pedido/5/AlteraStatusPedido/2
        //[Route("api/Pedido/{idPedido}/AlteraStatusPedido/{idStatus}")]
        [HttpPut("api/Pedido/{idPedido}/AlteraStatusPedido/{idStatus}")]
        public HttpResponseMessage AlteraStatusPedido(int idPedido, int idStatus)
        {
            if (servicos.AlteraStatusPedido(idPedido, idStatus) == false)
            {
                return new HttpResponseMessage (HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage (HttpStatusCode.OK);

        }


        //[Route("api/Pedido/NovoPedido")]
        [HttpPut("api/Pedido/NovoPedido")]
        public HttpResponseMessage NovoPedido(Comanda comanda, string canaldeEntrada)
        {
            //var a = Request.ContentType.GetType();

            if (servicos.InserePedido(comanda, canaldeEntrada) == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        #endregion

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
