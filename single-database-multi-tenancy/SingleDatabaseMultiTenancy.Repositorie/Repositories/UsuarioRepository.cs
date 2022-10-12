using Microsoft.EntityFrameworkCore;
using SingleDatabaseMultiTenancy.Data.Common;
using SingleDatabaseMultiTenancy.Data.Context;
using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Data;
using System.Linq;

namespace SingleDatabaseMultiTenancy.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SingleDatabaseMultiTenancyContext context) : base(context)
        {
        }

        public Usuario PesquisarPorLoginSenha(string login, string senha)
            => _context.Set<Usuario>().Where(u => u.Login.ToUpper().Equals(login.ToUpper()) && u.Senha.ToUpper()
            .Equals(senha.ToUpper())).AsNoTracking().FirstOrDefault();
    }
}