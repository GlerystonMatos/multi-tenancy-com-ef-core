using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SingleDatabaseMultiTenancy.Api.Security;
using SingleDatabaseMultiTenancy.Domain.Dto;
using SingleDatabaseMultiTenancy.Domain.Exception;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Services;

namespace SingleDatabaseMultiTenancy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ITenantService tenantService, IUsuarioService usuarioService, ILogger<LoginController> logger)
        {
            _logger = logger;
            _tenantService = tenantService;
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Autenticar usuário da naja
        /// </summary>
        /// <param name="login"></param>
        /// <response code="200">Usuário autenticado.</response>
        /// <response code="400">Usuário não autenticado.</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Authenticate([FromBody] LoginDto login)
        {
            _tenantService.Set(login.Tenant);
            _logger.LogInformation("Tenant: " + _tenantService.Get());

            UsuarioDto usuario = _usuarioService.ObterUsuarioParaAutenticacao(login);
            _logger.LogInformation("Login realizado: " + usuario.Nome);

            return Ok(new TokenDto(AccessToken.GenerateToken(usuario)));
        }

        /// <summary>
        /// Verificar o usuário autenticado.
        /// </summary>
        /// <response code="200">Usuário autenticado.</response>
        /// <response code="400">Usuário não autenticado.</response>
        /// <response code="401">Acesso não autorizado.</response>
        [HttpGet]
        [Authorize]
        [Route("Authenticated")]
        [ProducesResponseType(typeof(ExceptionMessage), 200)]
        [ProducesResponseType(typeof(ExceptionMessage), 400)]
        public IActionResult Authenticated()
        {
            _logger.LogInformation("Tenant: " + _tenantService.Get());
            return Ok(new ExceptionMessage(string.Format("Usuário autenticado - {0}", User.Identity.Name)));
        }
    }
}