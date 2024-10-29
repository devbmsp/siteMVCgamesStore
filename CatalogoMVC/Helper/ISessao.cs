using CatalogoMVC.Models;

namespace CatalogoMVC.Helper
{
    public interface ISessao
    {
        void RemoverSessaoUsuario();
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
