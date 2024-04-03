using System.Linq;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Base
{
    public interface IService<TModel>
    {
        IQueryable<TModel> ObterTodos();
    }
}