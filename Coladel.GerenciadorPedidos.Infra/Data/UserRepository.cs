using Coladel.Core;
using Coladel.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Coladel.Infra.Data
{
    public class UserRepository<TEntidade> : IRepository<TEntidade> where TEntidade : Entity
    {
        protected DbSet<TEntidade> Set { get; private set; }
        protected ApplicationDbContext context;

        public UserRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
            Type tipo = typeof(TEntidade);
            MappingProperties(dbContext, tipo);
        }

        public Guid Alterar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public TEntidade BuscarPorGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public TEntidade Criar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public bool Remover(TEntidade entidade)
        {
            throw new NotImplementedException();
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

        public TEntidade BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }
    }
}
