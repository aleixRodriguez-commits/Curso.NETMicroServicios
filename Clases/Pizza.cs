namespace webapi.clases
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public List<Ingrediente> Ingredientes { get; set; } = new();
        public decimal Price => 
            Ingredientes.Sum(i => i.Costo) * 1.2m;


        public decimal GetPrecio()
        {
            var costoTot = Ingredientes.Sum(i => i.Costo);
            return Math.Round(costoTotal * 1.2m, 2);
        }

        public void AddIngrediente(Ingrediente ingrediente)
        {
                Ingredientes.Add(ingrediente);
        }

        public bool EliminarIngrediente(int ingredienteId)
        {
                var ingrediente = Ingredientes.FirstOrDefault(i => i.Id == ingredienteId);
                if (ingrediente == null) return false;

                Ingredientes.Remove(ingrediente);
                return true;
        } 

        public bool ActualizarCosteIngrediente(int ingredienteId, decimal nuevoCoste)
        {
            var ingrediente = Ingredientes.FirstOrDefault(i => i.Id == ingredienteId);
            if (ingrediente == null) return false;

            ingrediente.Costo = nuevoCosto;
            return true;
        }



    }
}