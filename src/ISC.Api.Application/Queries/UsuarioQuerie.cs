using AutoMapper;
using ISC.Api.Application.Interfaces;
using ISC.Api.Domain.Dtos;
using ISC.Api.Domain.Entitys;
using ISC.Api.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Api.Application.Queries
{
    public class UsuarioQuerie : IUsuarioQuerie
    {
        private readonly IMapper _mapp;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unit;

        public UsuarioQuerie(IUsuarioRepository UsuarioRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = UsuarioRepository;
            _mapp = mapper;
            _unit = unitOfWork;
        }

        public async Task<bool> CadastrarUsuario(UsuarioRegisterDto user)
        {
            var userMap = _mapp.Map<Usuario>(user);

            var userExists = await _usuarioRepository.verificarDuplicidade(user.Login);

            if (!userExists)
            {
                _usuarioRepository.Insert(userMap);
                return await _unit.Commit();
            }
            else {
                return false;
            }
        }

        public async Task<Usuario> GetUsuarioById(long id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<bool> RemoverUsuario(long id)
        {
            _usuarioRepository.Delete(await _usuarioRepository.GetByIdAsync(id));
            return await _unit.Commit();
        }

        public async void Update(UsuarioUpdateDto usr)
        {
            var Usuario = _mapp.Map<Usuario>(usr);

            _usuarioRepository.Update(Usuario);
            await _unit.Commit();
        }

        public Usuario VerificarUsuario(string Login, string senha)
        {
            var login = _usuarioRepository.Get().Where(x => x.Login == Login && x.Senha == senha) != null;
            if (login)
            {
                return _usuarioRepository.Get().Where(x => x.Login == Login && x.Senha == senha).FirstOrDefault();
            }
            else {
                return null;
            }
        }

        public IEnumerable<Usuario> ListarUsuarios() {
            return _usuarioRepository.Get().AsEnumerable();
        }
    }
}
