namespace BNC.Models
{
    public class UserItensViewModel
    {
        public UserModel Usuario { get; set; }
        public List<ItensModel> Itenss { get; set; } // Certifique-se de que `Itens` é uma lista de `ItensModel`
    }
}
