using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Common
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}