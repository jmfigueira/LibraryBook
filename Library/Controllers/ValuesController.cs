using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LibraryModel;

namespace Library.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly LibraryBookEntities _repoBookEntities = new LibraryBookEntities();

        // GET api/values
        public IEnumerable<Book> GetAll(string value, string type)
        {
            if (type == "ASC")
            {
                switch (value)
                {
                    case "Title":
                        return _repoBookEntities.Books.ToList().OrderBy(x => x.Title);
                    case "Description":
                        return _repoBookEntities.Books.ToList().OrderBy(x => x.Description);
                    case "Launch":
                        return _repoBookEntities.Books.ToList().OrderBy(x => x.Launch);
                    case "Author":
                        return _repoBookEntities.Books.ToList().OrderBy(x => x.Author);
                    default:
                        return _repoBookEntities.Books.ToList().OrderBy(x => x.Language);
                }
            }
            else
            {
                switch (value)
                {
                    case "Title":
                        return _repoBookEntities.Books.ToList().OrderByDescending(x => x.Title);
                    case "Description":
                        return _repoBookEntities.Books.ToList().OrderByDescending(x => x.Description);
                    case "Launch":
                        return _repoBookEntities.Books.ToList().OrderByDescending(x => x.Launch);
                    case "Author":
                        return _repoBookEntities.Books.ToList().OrderByDescending(x => x.Author);
                    default:
                        return _repoBookEntities.Books.ToList().OrderByDescending(x => x.Language);
                }
            }
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
