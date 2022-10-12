using NUnit.Framework;
using SingleDatabaseMultiTenancy.Api.Security;
using SingleDatabaseMultiTenancy.Domain.Dto;

namespace SingleDatabaseMultiTenancy.NUnitTest.Security
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
            usuarioDto.Tenant = "Teste";

            Assert.IsNotEmpty(AccessToken.GenerateToken(usuarioDto));
        }
    }
}