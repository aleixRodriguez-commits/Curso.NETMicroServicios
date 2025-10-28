namespace webapi
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public List<Ingrediente> Ingredientes { get; set; } = new();

    }
}