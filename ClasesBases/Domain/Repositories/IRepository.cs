using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClasesBases.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        DataTable GetAll();
        int Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
