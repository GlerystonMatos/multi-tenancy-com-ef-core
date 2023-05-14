using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Base
{
    public interface IService<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}