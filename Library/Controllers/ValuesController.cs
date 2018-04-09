using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LibraryModelORM;

namespace Library.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly LibraryBookEntities _repoBookEntities = new LibraryBookEntities();

        // GET api/values
        public IEnumerable<Book> GetAll(string value, string type)
        {
            return _repoBookEntities.Books.ToList().OrderBy(x => x.Title);
        }

        // GET api/values/5
        public Book GetById(int id)
        {
            return _repoBookEntities.Books.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        public void PostNewBook([FromBody]Book value)
        {
            _repoBookEntities.Books.Add(value);
            _repoBookEntities.SaveChanges();
        }

        // PUT api/values/5
        public void PutUpdateBook(int id, [FromBody]Book value)
        {
            var book = _repoBookEntities.Books.FirstOrDefault(x => x.Id == id);
            _repoBookEntities.Books.Remove(book ?? throw new InvalidOperationException());
            _repoBookEntities.Books.Add(value);
            _repoBookEntities.SaveChanges();
        }

        // DELETE api/values/5
        public void DeleteBook(int id)
        {
            var book = _repoBookEntities.Books.FirstOrDefault(x => x.Id == id);
            _repoBookEntities.Books.Remove(book ?? throw new InvalidOperationException());
            _repoBookEntities.SaveChanges();
        }
    }
}
