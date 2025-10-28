namespace webapi
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Costo { get; set; }

    public void SetCostoIngrediente(decimal nuevoCoste)
        {
            if (nuevoCoste < 0)
                throw new ArgumentException("El costo no puede ser negativo.");

            Costo = nuevoCoste;
        }        
    }
}