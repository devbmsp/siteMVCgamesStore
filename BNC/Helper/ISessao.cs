using BNC.Models;

namespace BNC.Helper
{
    public interface ISessao
    {
        void RemoverSessaoUsuario();
        void CriarSessaoDoUsuario(HomeModel usuario);
        
        HomeModel BuscarSessaoDoUsuario();
    }
}
