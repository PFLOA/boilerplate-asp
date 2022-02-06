using Colade.Infra.Data;
using Coladel.Core;
using Coladel.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Coladel.Infra.Data
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entity
    {
        protected DbSet<TEntidade> Set { get; private set; }
        protected UserDbContext context;
        public Repository(UserDbContext dbContext)
        {
            context = dbContext;
            Type tipo = typeof(TEntidade);
            MappingProperties(dbContext, tipo);
        }

        public TEntidade BuscarPorId(long id)
        {
            var result = Set.Find(id);
            return result;
        }

        public TEntidade BuscarPorGuid(Guid guid)
        {
            var result = Set.FirstOrDefault(p => p.Guid == guid);
            return result;
        }
        public TEntidade Criar(TEntidade entidade)
        {
            var result = Set.Add(entidade);
            context.SaveChanges();
            return result.Entity;
        }
        public Guid Alterar(TEntidade entidade)
        {
            var result = Set.Update(entidade);
            context.SaveChanges();
            return result.Entity.Guid;
        }
        public bool Remover(TEntidade entidade)
        {
            var result = Set.Remove(entidade);

            if (result is null) return false;
            context.SaveChanges();

            return true;
        }

        private void Comparator(Object fromObjeto, PropertyInfo propertyInfo, Type toObjeto)
        {
            var toObjetoName = toObjeto.Name;
            var found = toObjetoName == propertyInfo.Name ? propertyInfo : null;

            if (found != null)
                Set = propertyInfo.GetValue(fromObjeto) as DbSet<TEntidade>;
        }

        private void MappingProperties(Object fromObjeto, Type toObjeto)
        {
            foreach (var properties in fromObjeto.GetType().GetProperties())
            {
                Comparator(fromObjeto, properties, toObjeto);
            }
        }
    }
}
