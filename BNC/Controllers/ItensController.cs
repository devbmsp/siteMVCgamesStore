using BNC.Models;
using BNC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace BNC.Controllers;

public class ItensController : Controller
{
    private readonly IItens _itens;

    public ItensController(IItens itens) => _itens = itens;

    public IActionResult Index()
    {
        return RedirectToAction("Index", "Users");
    }

    [HttpDelete]
    public IActionResult ApagarItem(int id)
    {
        try
        {

            bool apagado = _itens.DeletarItem(id);

            if (apagado)
            {
                TempData["MensagemSucesso"] = "Perfil apagado com sucesso!";
                return RedirectToAction("Index", "Users");
            }
            else
            {
                TempData["MensagemErro"] = "Ops, n�o conseguimos encontrar o perfil para apagar.";
            }

            return RedirectToAction("Index", "Users");
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] =
                $"Ops, n�o conseguimos apagar seu Cadastro, tente novamante, detalhe do erro: {erro.Message}";
            return RedirectToAction("Index", "Users");
        }
    }

    [HttpPost]

    public IActionResult PostarItem(ItensModel item)
    {
        try
        {
            _itens.AdicionarItem(item);
            TempData["SuccessMessage"] = "Item Criado!";

            return RedirectToAction("Index", "Users");
        }
        catch (Exception)
        {
            TempData["MessageErro"] = "N�o conseguimos criar seu post";

        }

        return null;
    }

    [HttpGet]
    public IActionResult ListarPosts()
    {
        try
        {
            List<ItensModel> Itens = _itens.ListarItems();
            return View(Itens);
        }
        catch (Exception)
        {
            TempData["MessageError"] = "Não conseguimos Listar os posts";
            return RedirectToAction("Index", "Users");
        }
    }
    [HttpPost]
    public IActionResult AlterarPost(ItensModel item)
    {
        ItensModel atualizado = _itens.AtualizarItem(item);

        if (atualizado != null)
        {
            TempData["MensagemSucesso"] = "Post atualizado com sucesso!";
            return RedirectToAction("Index", "Users");
        }
        else
        {
            TempData["MensagemErro"] = "Ops, n�o conseguimos atualizar seu Post.";
            return RedirectToAction("Index", "Users");
        }

        return RedirectToAction("Index", "Users");
    }
}

  