using NUnit.Framework;
using IsolatedDatabasesMultiTenancy.Api.Security;
using IsolatedDatabasesMultiTenancy.Domain.Dto;

namespace IsolatedDatabasesMultiTenancy.NUnitTest.Security
{
    public class AccessTokenTest
    {
        [Test]
        public void GenerateToken()
        {
            UsuarioDto usuarioDto = new UsuarioDto();
            usuarioDto.Senha = "123";
            usuarioDto.Nome = "Teste";
            usuarioDto.Login = "Teste";

            Assert.IsNotEmpty(AccessToken.GenerateToken(usuarioDto, "Teste"));
        }
    }
}