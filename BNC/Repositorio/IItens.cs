using BNC.Models;

namespace BNC.Repositorio;

public interface IItens
{
    ItensModel BuscarItem(int id);
    ItensModel AdicionarItem(ItensModel item);
    bool DeletarItem(int id);
    ItensModel AtualizarItem (ItensModel item);
    List<ItensModel> ListarItemId();
}