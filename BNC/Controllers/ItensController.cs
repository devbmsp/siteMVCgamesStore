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
        return View("Index");
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
    public IActionResult ListarPosts()
    {
        try
        {
            List<ItensModel> Itens = _itens.ListarItems();
            return View(Itens);
        }
        catch (Exception )
        {
            TempData["MessageError"] = "Não conseguimos Listar os posts";
            return View("Index");
        }
    }

    public IActionResult EditarPost(int id)
    {
        try
        {
            TempData["SuccessMessage"] = "Post Atualizado ";
            ItensModel postEdit = _itens.BuscarItem(id);
            return View(postEdit);

        }
        catch (Exception)
        {
            TempData["MessageErro"] = "N�o conseguimos editar seu perfil";
        }

        return null;
    }
}