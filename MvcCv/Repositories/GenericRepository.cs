using MvcCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCv.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            db.SaveChanges();
        }

        public List<TEntity> GetList()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }
    }
}