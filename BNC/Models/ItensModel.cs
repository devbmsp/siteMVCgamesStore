namespace BNC.Models
{

    public class ItensModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public IEnumerable<ItensModel> Item { get; set; }
        public UserModel Usuario { get; set; } 
        

    }
}