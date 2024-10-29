using CatalogoMVC.Helper;
using CatalogoMVC.Models;
using CatalogoMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatalogoMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Interface _userRepositorio;
        private readonly ISessao _sessao;

        
        public UsuarioController(Interface usuarioRepositorio, ISessao sessao)
        {
            _userRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        [HttpPost]
        public IActionResult Entrar(UsuarioModel login)
        {
            try
            {
                UsuarioModel usuario = _userRepositorio.BuscarLogin(login.Email);

                if (usuario != null && usuario.SenhaValida(login.Password))
                {
                    HttpContext.Session.SetString("UserId", usuario.Id.ToString());
                    _sessao.CriarSessaoDoUsuario(usuario);
                    return RedirectToAction("Index");
                }

                TempData["MensagemErro"] = "Usuário ou senha inválido";
                return View("Login");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Não conseguimos realizar seu login";
                return View("Login");
            }
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Login");   
        }

        public IActionResult Index()
        {
          

            return View();
        }

        public IActionResult Login()
        {
            
            return View();
        }

        public IActionResult Perfil()
        {
            List<UsuarioModel> Users = _userRepositorio.BuscarId();
            return View(Users);
        }


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel userEdit = _userRepositorio.ListarPorId(id);
            return View(userEdit);


        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel user)
        {
            _userRepositorio.Adicionar(user);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel user)
        {
            UsuarioModel atualizado = _userRepositorio.Atualizar(user);

            if (atualizado != null)
            {
                TempData["MensagemSucesso"] = "Perfil atualizado com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Ops, não conseguimos atualizar seu perfil.";
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
                    TempData["MensagemErro"] = "Ops, não conseguimos encontrar o perfil para apagar.";
                }

                return RedirectToAction("Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu Cadastro, tente novamante, detalhe do erro: {erro.Message}";
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
