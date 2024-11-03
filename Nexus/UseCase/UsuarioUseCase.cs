using _Nexus.Models;
using _Nexus.Repository.Interface;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace Nexus.UseCase
{
    public class UsuarioUseCase
    {
        private readonly IRepository<UsuarioModel> _userRepository;
        private readonly IRepository<UsuarioLike> _userLikeRepository;

        public UsuarioUseCase(IRepository<UsuarioModel> userRepository, IRepository<UsuarioLike> userLikeRepository)
        {
            _userRepository = userRepository;
            _userLikeRepository = userLikeRepository;
        }

        public void CreateUser(UsuarioRequest userRequest)
        {
            var user = new UsuarioModel(userRequest.Email, userRequest.Password)
            {
                NomeUsuario = userRequest.NomeUsuario,
                CPF = userRequest.CPF,
                Email = userRequest.Email,
                Telefone = userRequest.Telefone
            };
            user.SetPassword(userRequest.Password);
            
            _userRepository.Add(user);
        }

        public void LikedUser(UsuarioLike userLike)
        {
            _userLikeRepository.Add(userLike);
        }

        public List<UsuarioModel> GetUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public UsuarioModel GetUserById(string id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(string id, UsuarioRequest userRequest)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                user.NomeUsuario = userRequest.NomeUsuario;
                user.CPF = userRequest.CPF;
                user.Email = userRequest.Email;
                user.Telefone = userRequest.Telefone;
                user.SetPassword(userRequest.Password); 

                _userRepository.Update(user);
            }
        }
        public void DeleteUser(string id)
        {
            try
            {
                _userRepository.Delete(id); 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir usuário: " + ex.Message);
            }
        }


    }
}
