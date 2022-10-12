using System.Linq;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Common
{
    public interface IService<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}