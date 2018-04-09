using System.Collections.Generic;
using System.Web.Http;
using LibraryModel;
using LibraryModel.DB;

namespace Library.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly BookRepository _repository = new BookRepository();

        // GET api/values
        public IEnumerable<Book> GetAll(string value, string type)
        {
            return _repository.GetAll(value, type);
        }

        // GET api/values/5
        public Book GetById(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/values
        public void PostNewBook([FromBody]Book value)
        {
            _repository.Save(value);
        }

        // PUT api/values/5
        public void PutUpdateBook(int id, [FromBody]Book value)
        {
            _repository.Update(id, value);
        }

        // DELETE api/values/5
        public void DeleteBook(int id)
        {
            _repository.DeleteById(id);
        }
    }
}
