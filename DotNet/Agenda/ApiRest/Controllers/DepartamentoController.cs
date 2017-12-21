using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ApiRest.Models;

namespace ApiRest.Controllers
{
    public class DepartamentoController : ApiController
    {
        private smolEntities db = new smolEntities();

        // GET api/Departamento
        public IEnumerable<Deparment> GetDeparments()
        {
            return db.Deparments.AsEnumerable();
        }

        // GET api/Departamento/5
        public Deparment GetDeparment(int id)
        {
            Deparment deparment = db.Deparments.Find(id);
            if (deparment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return deparment;
        }

        // PUT api/Departamento/5
        public HttpResponseMessage PutDeparment(int id, Deparment deparment)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != deparment.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(deparment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Departamento
        public HttpResponseMessage PostDeparment(Deparment deparment)
        {
            if (ModelState.IsValid)
            {
                db.Deparments.Add(deparment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, deparment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = deparment.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Departamento/5
        public HttpResponseMessage DeleteDeparment(int id)
        {
            Deparment deparment = db.Deparments.Find(id);
            if (deparment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Deparments.Remove(deparment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, deparment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}