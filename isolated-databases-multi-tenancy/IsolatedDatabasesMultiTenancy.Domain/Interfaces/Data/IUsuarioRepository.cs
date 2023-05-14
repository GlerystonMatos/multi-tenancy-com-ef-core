using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Base;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario PesquisarPorLoginSenha(string login, string senha);
    }
}