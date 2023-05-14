using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Base
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}