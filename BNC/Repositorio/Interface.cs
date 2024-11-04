using BNC.Models;

namespace BNC.Repositorio
{
    public interface Interface
    {
        HomeModel ListarPorId(int id);
        HomeModel Adicionar(HomeModel user);
        bool Deletar(int id);
        HomeModel Atualizar (HomeModel user);
        HomeModel BuscarLogin (string login);

        List<HomeModel> BuscarId();
    }
}
