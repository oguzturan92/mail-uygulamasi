using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EfCore
{
    public class GenericDal<T> : IGenericDal<T> where T : class
    {
        public void Create(T entity)
        {
            using var context = new ProjeContext();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var context = new ProjeContext();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void DeleteAll(List<T> entities)
        {
            using var context = new ProjeContext();
            context.Set<T>().RemoveRange(entities);
            context.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            using var context = new ProjeContext();
            return filter == null
                            ? context.Set<T>().ToList()
                            : context.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            using var context = new ProjeContext();
            return context.Set<T>().Find(id);
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using var context = new ProjeContext();
            return context.Set<T>().Where(filter).SingleOrDefault();
        }

        public void Update(T entity)
        {
            using var context = new ProjeContext();
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}