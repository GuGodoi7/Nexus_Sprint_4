using _Nexus.Models;
using _Nexus.Repository.Interface;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;

namespace Nexus.UseCase
{
    public class UsuarioUseCase
    {
        private readonly IRepository<UsuarioModel> _usuarioRepository;
        private readonly IRepository<UsuarioLike> _userLikeRepository;

        public UsuarioUseCase(IRepository<UsuarioModel> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioModel> GetAllTasks()
        {
            return _usuarioRepository.GetAll();
        }

        public UsuarioModel GetTaskById(string id)
        {
            return _usuarioRepository.GetById(id);
        }

        public void AddTask(UsuarioModel usuario)
        {
            if (string.IsNullOrEmpty(usuario.Id))
            {
                usuario.Id = ObjectId.GenerateNewId().ToString();
            }

            _usuarioRepository.Add(usuario);
        }

        public void UpdateTask(UsuarioModel usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        public void DeleteTask(string id)
        {
            _usuarioRepository.Delete(id);
        }

        public void LikedUser(UsuarioLike userLike)
        {
            _userLikeRepository.Add(userLike);
        }

    }
}