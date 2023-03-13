namespace APP.Domain;

public class Basket : Entity
{
    public virtual List<BasketItem> Items { get; set; } = null!;
}