namespace webapi.features.pizza.domain;

using webapi.common.domain;

public class Pizza : Entity
{
    private const decimal PROFIT = 1.20m;
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string Url { get; protected set; }

    public decimal Price => _ingredients.Sum(i => i.Cost) * PROFIT;

    public IReadOnlyCollection<Ingredient> Ingredients => _ingredients.ToList().AsReadOnly();

    protected HashSet<Ingredient> _ingredients = [];

    protected Pizza(Guid id, string name, string description, string url) : base(id)
    {
        PizzaValidator.ValidatePizzaData(name, description, url);
        
        Name = name;
        Description = description;
        Url = url;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        PizzaValidator.ValidateIngredient(ingredient);
        _ingredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        PizzaValidator.ValidateIngredient(ingredient);
        
        if (!_ingredients.Contains(ingredient))
        {
            throw new InvalidOperationException("El ingrediente no existe en la pizza.");
        }

        _ingredients.Remove(ingredient);
    }

    public void Update(string name, string description, string url)
    {
        PizzaValidator.ValidatePizzaData(name, description, url);
        //pizza:update
        Name = name;
        Description = description;
        Url = url;
    }

    public static Pizza Create(Guid id, string name, string description, string url)
    {
        var pizza = new Pizza(id, name, description, url);
        //create pizza:create
        return pizza;
    }
}

public static class PizzaValidator
{
    public static void ValidatePizzaData(string name, string description, string url)
    {
        ValidateName(name);
        ValidateDescription(description);
        ValidateUrl(url);
    }

    public static void ValidateIngredient(Ingredient ingredient)
    {
        if (ingredient == null)
        {
            throw new ArgumentNullException(nameof(ingredient), "El ingrediente no puede ser nulo.");
        }
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El nombre de la pizza es requerido.", nameof(name));
        }

        if (name.Length < 3)
        {
            throw new ArgumentException("El nombre debe tener al menos 3 caracteres.", nameof(name));
        }

        if (name.Length > 100)
        {
            throw new ArgumentException("El nombre no puede exceder los 100 caracteres.", nameof(name));
        }
    }

    private static void ValidateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("La descripción de la pizza es requerida.", nameof(description));
        }

        if (description.Length < 10)
        {
            throw new ArgumentException("La descripción debe tener al menos 10 caracteres.", nameof(description));
        }

        if (description.Length > 500)
        {
            throw new ArgumentException("La descripción no puede exceder los 500 caracteres.", nameof(description));
        }
    }

    private static void ValidateUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("La URL de la imagen es requerida.", nameof(url));
        }

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uriResult) ||
            (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
        {
            throw new ArgumentException("La URL no tiene un formato válido. Debe ser una URL HTTP o HTTPS.", nameof(url));
        }
    }
}