using System.Linq;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Common
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}