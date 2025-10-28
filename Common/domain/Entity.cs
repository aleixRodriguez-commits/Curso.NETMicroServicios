namespace webapi.common.domain;
public abstract class Entity(Guid id) //No se puede instanciar directamente. Sirve como clase base para las entidades del dominio
{
    public Guid Id { get; init; } = id; //Solo lectura despues de inicializar
    public override bool Equals(object? obj) //Sobreescribe el método equals para que dos entidades se consideren igaules si tienen el mismo Id
    {
        if (obj is not Entity other || GetType() != obj.GetType()) //Si el objeto con la misma id no utiliza Entity o no son del mismo tipo exacto retorna false
            return false;
            
        return Id == other.Id; //Si no cumple lo anterior y tiene el mismo id retorna true
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity? left, Entity? right) //Permite utilizar == para comparar dos entidades
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Entity? left, Entity? right) //Permite utilizar =! para comparar dos entidades
    {
        return !(left == right);
    }
}