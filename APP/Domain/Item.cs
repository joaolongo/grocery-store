namespace APP.Domain;

public class Item : Entity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public virtual SpecialOffer? SpecialOffer { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            throw new Exception("No obj provided for Equality comparer");
        
        return Equals((Item)obj);
    }

    private bool Equals(Item other)
    {
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}