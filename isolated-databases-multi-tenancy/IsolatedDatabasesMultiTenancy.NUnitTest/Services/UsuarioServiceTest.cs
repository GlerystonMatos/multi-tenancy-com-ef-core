using AutoMapper;
using Moq;
using NUnit.Framework;
using IsolatedDatabasesMultiTenancy.Domain.Dto;
using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Exception;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services;
using IsolatedDatabasesMultiTenancy.NUnitTest.Common;
using IsolatedDatabasesMultiTenancy.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace IsolatedDatabasesMultiTenancy.NUnitTest.Services
{
    public class UsuarioServiceTest
    {
        private IMapper _mapper;
        private Usuario _usuario;
        private IUsuarioService _usuarioService;
        private Mock<IUsuarioRepository> _mockUsuarioRepository;

        public UsuarioServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioService(_mapper, _mockUsuarioRepository.Object);

            _usuario = new Usuario("Teste", "Teste", "123");
        }

        [Test]
        public void CriarComConstrutorTest()
            => Assert.IsNotNull(new UsuarioDto());

        [Test]
        public void ObterTodosTest()
        {
            IList<Usuario> usuariosList = new List<Usuario>();
            usuariosList.Add(_usuario);

            _mockUsuarioRepository.Setup(r => r.ObterTodos()).Returns(usuariosList.AsQueryable());
            Assert.IsNotNull(_usuarioService.ObterTodos());
        }

        [Test]
        public void ObterUsuarioParaAutenticacaoUsuarioNaoLocalizadoTest()
        {
            LoginDto loginDto = new LoginDto();
            loginDto.Login = "login";
            loginDto.Senha = "senha";

            Assert.IsTrue(Assert.Throws<IsolatedDatabasesMultiTenancyException>(() => _usuarioService.ObterUsuarioParaAutenticacao(loginDto))
                .Message.Equals("Usuário não localizado."));
        }

        [Test]
        public void ObterUsuarioParaAutenticacaoTest()
        {
            Usuario usuario = new Usuario("Teste", "Teste", "123");

            _mockUsuarioRepository.Setup(r => r.PesquisarPorLoginSenha(usuario.Login, usuario.Senha)).Returns(usuario);

            LoginDto loginDto = new LoginDto();
            loginDto.Login = _usuario.Login;
            loginDto.Senha = _usuario.Senha;

            Assert.IsNotNull(_usuarioService.ObterUsuarioParaAutenticacao(loginDto));
        }
    }
}