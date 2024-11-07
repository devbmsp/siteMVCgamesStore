using BNC.Models;
using BNC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace BNC.Controllers;

public class ItensController : Controller
{
    private readonly IItens _itens;

    public ItensController(IItens itens) => _itens = itens;

    public IActionResult IndexPosts()
    {
        return View();
    }

    public IActionResult ApagarItem(int id)
    {
        try
        {

            bool apagado = _itens.DeletarItem(id);

            if (apagado)
            {
                TempData["MensagemSucesso"] = "Perfil apagado com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Ops, n�o conseguimos encontrar o perfil para apagar.";
            }

            return RedirectToAction("Index", "Itens");
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] =
                $"Ops, n�o conseguimos apagar seu Cadastro, tente novamante, detalhe do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]

    public IActionResult PostarItem(ItensModel item)
    {
        try
        {
            _itens.AdicionarItem(item);
            TempData["SuccessMessage"] = "Item Criado!";

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            TempData["MessageErro"] = "N�o conseguimos criar seu post";

        }

        return null;
    }

    [HttpGet]
    public List<ItensModel> ListarPosts()
    {
        return _itens.ListarItemId();
    }
}