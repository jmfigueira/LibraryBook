using System.Collections.Generic;
using System.Web.Configuration;

namespace LibraryModel.DB
{
    public abstract class AbstractRepository<TEntity, TKey> where TEntity : class
    {
        protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["DBLibrary"].ConnectionString;
        public abstract List<TEntity> GetAll(string order = null, string type = null);
        public abstract TEntity GetById(TKey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TKey id, TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void DeleteById(TKey id);
    }
}
