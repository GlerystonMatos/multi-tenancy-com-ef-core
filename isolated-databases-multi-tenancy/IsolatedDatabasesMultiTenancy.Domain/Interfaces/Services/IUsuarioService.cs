using IsolatedDatabasesMultiTenancy.Domain.Dto;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Common;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<UsuarioDto>
    {
        UsuarioDto ObterUsuarioParaAutenticacao(LoginDto loginDto);
    }
}