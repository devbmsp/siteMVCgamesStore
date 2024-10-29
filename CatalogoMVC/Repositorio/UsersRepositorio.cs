using CatalogoMVC.Data;
using CatalogoMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CatalogoMVC.Repositorio
{
    public class UsersRepositorio : Interface
    {
        private readonly BancoContext _bancoContext;
        public UsersRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel Adicionar(UsuarioModel user)
        {
            _bancoContext.Users.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }

        public UsuarioModel Atualizar(UsuarioModel user)
        {
            UsuarioModel userBD = ListarPorId(user.Id);

            if (userBD == null) throw new System.Exception("Houve um erro na atualização do contato!");

            userBD.Name = user.Name;
            userBD.Email = user.Email;
            userBD.Gender = user.Gender;
            userBD.Username = user.Username;
            userBD.Zip = user.Zip;
            userBD.Password = user.Password;

            _bancoContext.Users.Update(userBD);
            _bancoContext.SaveChanges();

            return userBD;

        }

        public UsuarioModel BuscarLogin(string email)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

        }
       



        public bool Deletar(int Id)
        {       
                
                UsuarioModel userDB = ListarPorId(Id);
                
                if (userDB == null)
                {
                    return false;
                }             
                _bancoContext.Users.Remove(userDB);
                _bancoContext.SaveChanges();

                return true;
            


        }



        public UsuarioModel ListarPorId(int Id)
        {
          
            return _bancoContext.Users.FirstOrDefault(x => x.Id == Id);
        }

        public List<UsuarioModel> BuscarId()
        {
            return _bancoContext.Users.ToList();
        }
    }
}

