using CatalogoMVC.Models;

namespace CatalogoMVC.Repositorio
{
    public interface Interface
    {
        UsuarioModel ListarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel user);
        bool Deletar(int id);
        UsuarioModel Atualizar (UsuarioModel user);
        UsuarioModel BuscarLogin (string login);

        List<UsuarioModel> BuscarId();
    }
}
