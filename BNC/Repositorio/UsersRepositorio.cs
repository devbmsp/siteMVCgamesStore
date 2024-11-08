using Microsoft.EntityFrameworkCore;
using System.Linq;
using BNC.Data;
using BNC.Models;

namespace BNC.Repositorio
{
    public class UsersRepositorio : IUser
    {
        private readonly BancoContext _bancoContext;
        public UsersRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public UserModel Adicionar(UserModel user)
        {
            _bancoContext.Users.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }

        public UserModel Atualizar(UserModel user)
        {
            UserModel userBD = ListarPorId(user.Id);

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
        public UserModel BuscarLogin(string email)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());

        }
        public bool Deletar(int Id)
        {       
                UserModel userDB = ListarPorId(Id);
                
                if (userDB == null)
                {
                    return false;
                }             
                _bancoContext.Users.Remove(userDB);
                _bancoContext.SaveChanges();

                return true;
        }
        public UserModel ListarPorId(int Id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Id == Id);
        }

        public List<UserModel> BuscarId()
        {
            return _bancoContext.Users.ToList();
        }
    }
}

