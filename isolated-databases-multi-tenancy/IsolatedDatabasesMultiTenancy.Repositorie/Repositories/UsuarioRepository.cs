using Microsoft.EntityFrameworkCore;
using IsolatedDatabasesMultiTenancy.Data.Common;
using IsolatedDatabasesMultiTenancy.Data.Context;
using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data;
using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IsolatedDatabasesMultiTenancyContext context) : base(context)
        {
        }

        public Usuario PesquisarPorLoginSenha(string login, string senha)
            => _context.Set<Usuario>().Where(u => u.Login.ToUpper().Equals(login.ToUpper()) && u.Senha.ToUpper()
            .Equals(senha.ToUpper())).AsNoTracking().FirstOrDefault();
    }
}