using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Common;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Data
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario PesquisarPorLoginSenha(string login, string senha);
    }
}