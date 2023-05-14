using IsolatedDatabasesMultiTenancy.Data.Context;
using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Data.Base
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        protected readonly IsolatedDatabasesMultiTenancyContext _context;

        public Repository(IsolatedDatabasesMultiTenancyContext context)
            => _context = context;

        public virtual IQueryable<TModel> ObterTodos()
            => _context.Set<TModel>().AsNoTracking().AsQueryable();
    }
}