using BNC.Models;

namespace BNC.Helper
{
    public interface ISessao
    {
        void RemoverSessaoUsuario();
        void CriarSessaoDoUsuario(UserModel usuario);
        
        UserModel BuscarSessaoDoUsuario();
    }
}
