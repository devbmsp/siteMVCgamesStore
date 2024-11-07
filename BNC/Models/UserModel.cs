namespace BNC.Models
{
    public class UserModel
    {
        public int Id { get; set; } 
        public  string? Username { get; set; }
        public  string? Email { get; set; }
        public  string? Name { get; set; }
        public  string? Gender { get; set; }
        public  string? Zip { get; set; }
        public  string? Password { get; set; }
        public bool SenhaValida(string senha)
        {
            return Password == senha;
        }
    }
}
