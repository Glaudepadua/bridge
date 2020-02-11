namespace bridge.Models
{
    public class Repositorio
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Stargazers_count { get; set; }
        public bool Favorito { get; set; }
        public Owner Owner { get; set; }
    }

    public class Owner
    {
        public string Login { get; set; }
    }
}