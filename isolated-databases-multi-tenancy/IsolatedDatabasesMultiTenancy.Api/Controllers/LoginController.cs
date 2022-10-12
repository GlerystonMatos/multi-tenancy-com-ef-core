using IsolatedDatabasesMultiTenancy.Api.Security;
using IsolatedDatabasesMultiTenancy.Domain.Dto;
using IsolatedDatabasesMultiTenancy.Domain.Exception;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services;
using IsolatedDatabasesMultiTenancy.Domain.Tenant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<LoginController> _logger;
        private readonly IOptions<TenantConfigurationSection> _options;

        public LoginController(ITenantService tenantService, IUsuarioService usuarioService, ILogger<LoginController> logger,
            IOptions<TenantConfigurationSection> options)
        {
            _logger = logger;
            _options = options;
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
            TenantConfiguration tenant = _options.Value.Tenants.Where(t => t.Name.Equals(login.Tenant)).SingleOrDefault();
            if (tenant == null)
            {
                tenant = _options.Value.Tenants.Where(t => t.Name.Equals("Tenant00")).SingleOrDefault();
            }

            _tenantService.Set(tenant);
            _logger.LogInformation("Tenant: " + _tenantService.Get().Name);

            UsuarioDto usuarioDto = _usuarioService.ObterUsuarioParaAutenticacao(login);
            _logger.LogInformation("Login realizado: " + usuarioDto.Nome);

            return Ok(new TokenDto(AccessToken.GenerateToken(usuarioDto, tenant.Name)));
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
            _logger.LogInformation("Tenant: " + _tenantService.Get().Name);
            return Ok(new ExceptionMessage(string.Format("Usuário autenticado - {0}", User.Identity.Name)));
        }
    }
}