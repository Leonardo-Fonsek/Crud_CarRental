namespace API_Aluguel_de_carros.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }
        public string cor { get; set; }
        public Boolean alugado { get; set; }
        
    }
}
