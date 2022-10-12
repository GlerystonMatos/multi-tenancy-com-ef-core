using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Common
{
    public interface IService<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}