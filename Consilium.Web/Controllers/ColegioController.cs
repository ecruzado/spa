﻿using Consilium.Entity;
using Consilium.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Consilium.Web.Controllers
{
    public class ColegioController : ApiController
    {
        // GET api/usuario
        public IEnumerable<Colegio> Get()
        {
            var lista = ColegioLogica.Instancia.List();
            return lista;
        }
        public Colegio Get(int colegioId)
        {
            var colegio = ColegioLogica.Instancia.Get(colegioId);
            return colegio;
        }

        // POST api/usuario
        public void Post([FromBody]Colegio colegio)
        {
            if (colegio.ColegioId == 0)
            {
                ColegioLogica.Instancia.Insert(colegio);
            }
            else
            {
                ColegioLogica.Instancia.Update(colegio);
            }
        }

        [HttpPost]
        public void Exportar([FromBody]ColegioExportar colegioExportar)
        {
            ColegioLogica.Instancia.Exportar(colegioExportar);
        }
    }
}
