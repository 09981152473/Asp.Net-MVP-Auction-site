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
using Portal_aukcyjny.Repositories;

namespace Portal_aukcyjny.Controllers
{
    public class AuctionsController : ApiController
    {
        private PortalAukcyjnyCZEntities db = new PortalAukcyjnyCZEntities();

        // GET: api/Auctions
        public IQueryable<AspNetAuctions> GetAspNetAuctions()
        {
            return db.AspNetAuctions;
        }

        // GET: api/Auctions/5
        [ResponseType(typeof(AspNetAuctions))]
        public IHttpActionResult GetAspNetAuctions(int id)
        {
            AspNetAuctions aspNetAuctions = db.AspNetAuctions.Find(id);
            if (aspNetAuctions == null)
            {
                return NotFound();
            }

            return Ok(aspNetAuctions);
        }

        // PUT: api/Auctions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAspNetAuctions(int id, AspNetAuctions aspNetAuctions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspNetAuctions.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetAuctions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetAuctionsExists(id))
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

        // POST: api/Auctions
        [ResponseType(typeof(AspNetAuctions))]
        public IHttpActionResult PostAspNetAuctions(AspNetAuctions aspNetAuctions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AspNetAuctions.Add(aspNetAuctions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aspNetAuctions.Id }, aspNetAuctions);
        }

        // DELETE: api/Auctions/5
        [ResponseType(typeof(AspNetAuctions))]
        public IHttpActionResult DeleteAspNetAuctions(int id)
        {
            AspNetAuctions aspNetAuctions = db.AspNetAuctions.Find(id);
            if (aspNetAuctions == null)
            {
                return NotFound();
            }

            db.AspNetAuctions.Remove(aspNetAuctions);
            db.SaveChanges();

            return Ok(aspNetAuctions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetAuctionsExists(int id)
        {
            return db.AspNetAuctions.Count(e => e.Id == id) > 0;
        }
    }
}