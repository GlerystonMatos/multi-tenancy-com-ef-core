using Microsoft.EntityFrameworkCore;
using IsolatedDatabasesMultiTenancy.Data.Context;
using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Common;
using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Data.Common
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