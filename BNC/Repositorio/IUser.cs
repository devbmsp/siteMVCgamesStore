using BNC.Models;

namespace BNC.Repositorio
{
    public interface IUser
    {
        UserModel ListarPorId(int id);
        UserModel Adicionar(UserModel user);
        bool Deletar(int id);
        UserModel Atualizar (UserModel user);
        UserModel BuscarLogin (string login);

        List<UserModel> BuscarId();
    }
}
