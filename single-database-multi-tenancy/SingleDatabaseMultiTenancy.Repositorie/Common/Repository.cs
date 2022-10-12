﻿using Microsoft.EntityFrameworkCore;
using SingleDatabaseMultiTenancy.Data.Context;
using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Common;
using System.Linq;

namespace SingleDatabaseMultiTenancy.Data.Common
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        protected readonly SingleDatabaseMultiTenancyContext _context;

        public Repository(SingleDatabaseMultiTenancyContext context)
            => _context = context;

        public virtual IQueryable<TModel> ObterTodos()
            => _context.Set<TModel>().AsNoTracking().AsQueryable();
    }
}