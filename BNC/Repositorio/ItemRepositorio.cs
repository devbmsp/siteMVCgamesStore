using BNC.Data;
using BNC.Models;
using Microsoft.EntityFrameworkCore;

namespace BNC.Repositorio;

public class ItemRepositorio : IItens
{
    private readonly BancoContext _bancoContext;
    public ItemRepositorio(BancoContext bancoContext) 
    {
        _bancoContext = bancoContext;
    }
    public ItensModel BuscarItem(int id)
    {
        return _bancoContext.Itens.FirstOrDefault(x => x.Id == id);
    }

    public ItensModel AdicionarItem(ItensModel item)
    {
        _bancoContext.Itens.Add(item);
        _bancoContext.SaveChanges();
        return item;
    }

    public bool DeletarItem(int id)
    {
        throw new NotImplementedException();
    }

    public ItensModel AtualizarItem(ItensModel item)
    {
        ItensModel itemDB = BuscarItem(item.Id);

        if (itemDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

        itemDB.Name = itemDB.Name;
        itemDB.Description = itemDB.Description;
        itemDB.Image = itemDB.Image;
        
        _bancoContext.Itens.Update(itemDB);
        _bancoContext.SaveChanges();

        return itemDB;
        
    }

    public List<ItensModel> ListarItemId()
    {
        throw new NotImplementedException();
    }

    public List<ItensModel> ListarItem()
    {
        return _bancoContext.Itens.ToList();
    }
}