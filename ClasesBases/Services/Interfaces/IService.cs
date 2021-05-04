using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBases.Commons;
using System.Collections.ObjectModel;

namespace ClasesBases.Services.Interfaces
{
    public interface IService<TEntity> where TEntity: class
    {
        Response Add(TEntity entity);
        Response Update(TEntity entity);
        Response Delete(TEntity entity);
        Response GetAll();
    }
}
