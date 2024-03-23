using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Reposatories
{
    public class GenericReposatory<T> : IGenericReposatory<T> where T : BaseEntity
    {
        private readonly MVCAppDBContext context;

        public GenericReposatory(MVCAppDBContext context)

        {
            this.context = context;

        }
        public int Add(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public int Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
           var all = context.Set<T>().ToList();
            return all;

        }

        public T GetById(int? id)
        {
            var all = context.Set<T>().Find(id);
            return all;
        }

        public int Update(T entity)
        {
            context.Set<T>().Update(entity) ;
            return context.SaveChanges();
        }
    }
}
