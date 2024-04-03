using System.Linq;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Base
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}