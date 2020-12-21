using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);

        Task<Usuario> GetUsuarioById(int usuarioId);
        Task<Usuario[]> GetAsyncAll();
    }
}