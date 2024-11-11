using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BNC.Helper;
using BNC.Models;
using BNC.Repositorio;
using BNC.Migration;

namespace BNC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _userRepositorio;
        private readonly ISessao _sessao;
        private readonly IItens _itensRepositorio;

        public UsersController(IUser usuarioRepositorio, ISessao sessao, IItens itens)
        {
            _userRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _itensRepositorio = itens;
        }

        [HttpPost]
        public IActionResult Entrar(UserModel login)
        {
            try
            {
                UserModel usuario = _userRepositorio.BuscarLogin(login.Email);

                if (usuario != null && usuario.SenhaValida(login.Password))
                {
                    HttpContext.Session.SetString("UserId", usuario.Id.ToString());
                    _sessao.CriarSessaoDoUsuario(usuario);
                    return RedirectToAction("Index");
                }

                TempData["MessageError"] = "Usu�rio ou senha inv�lido";
                return View("Login");
            }
            catch (Exception)
            {
                TempData["MessageError"] = "N�o conseguimos realizar seu login";
                return View("Login");
            }
        }
        public IActionResult Sair()
        {
            try
            {
                _sessao.RemoverSessaoUsuario();
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                TempData["MessageError"] = "N�o conseguimos realizar seu logout";
                return View("Login");
            }
        }

        public IActionResult Index()
        {
            var usuario = _sessao.BuscarSessaoDoUsuario();

            if (usuario == null)
            {
                return RedirectToAction("Login");
            }

            var item = _itensRepositorio.ListarItems();

            var viewModel = new ItensModel();


            return View(viewModel);


        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            try
            {
                List<UserModel> Users = _userRepositorio.BuscarId();
                return View(Users);
            }
            catch (Exception e)
            {
                TempData["MessageError"] = "Não conseguimos vizualizar seu perfil";
                return View("Login");
            }
            
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            try
            {
                TempData["SuccessMessage"] = "N�o conseguimos vizualizar seu perfil";
                UserModel userEdit = _userRepositorio.ListarPorId(id);
                return View(userEdit);
                
            }
            catch (Exception)
            {
                TempData["MessageErro"] = "N�o conseguimos editar seu perfil";
            }

            return null;
        }
        [HttpPost]
        public IActionResult Criar(UserModel user)
        {
            _userRepositorio.Adicionar(user);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Alterar(UserModel user)
        {
            UserModel atualizado = _userRepositorio.Atualizar(user);

            if (atualizado != null)
            {
                TempData["MensagemSucesso"] = "Perfil atualizado com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Ops, n�o conseguimos atualizar seu perfil.";
            }

            return RedirectToAction("Perfil");
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                
                bool apagado = _userRepositorio.Deletar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Perfil apagado com sucesso!";
                    _sessao.RemoverSessaoUsuario();
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, n�o conseguimos encontrar o perfil para apagar.";
                }

                return RedirectToAction("Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, n�o conseguimos apagar seu Cadastro, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}