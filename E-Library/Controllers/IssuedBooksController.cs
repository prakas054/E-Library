using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E_Library.Models;

namespace E_Library.Controllers
{
    public class IssuedBooksController : ApiController
    {
        private E_LibraryContext db = new E_LibraryContext();

        // GET: api/IssuedBooks
        public IQueryable<IssuedBook> GetIssuedBooks()
        {
            return db.IssuedBooks.Include(b => b.Book).Include(b => b.Student);
        }

        // GET: api/IssuedBooks/5
        [ResponseType(typeof(IssuedBook))]
        public async Task<IHttpActionResult> GetIssuedBook(int id)
        {
            IssuedBook issuedBook = await db.IssuedBooks.FindAsync(id);
            if (issuedBook == null)
            {
                return NotFound();
            }

            return Ok(issuedBook);
        }

        // PUT: api/IssuedBooks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIssuedBook(int id, IssuedBook issuedBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != issuedBook.Id)
            {
                return BadRequest();
            }

            db.Entry(issuedBook).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuedBookExists(id))
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

        // POST: api/IssuedBooks
        [ResponseType(typeof(IssuedBook))]
        public async Task<IHttpActionResult> PostIssuedBook(IssuedBook issuedBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IssuedBooks.Add(issuedBook);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = issuedBook.Id }, issuedBook);
        }

        // DELETE: api/IssuedBooks/5
        [ResponseType(typeof(IssuedBook))]
        public async Task<IHttpActionResult> DeleteIssuedBook(int id)
        {
            IssuedBook issuedBook = await db.IssuedBooks.FindAsync(id);
            if (issuedBook == null)
            {
                return NotFound();
            }

            db.IssuedBooks.Remove(issuedBook);
            await db.SaveChangesAsync();

            return Ok(issuedBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IssuedBookExists(int id)
        {
            return db.IssuedBooks.Count(e => e.Id == id) > 0;
        }
    }
}