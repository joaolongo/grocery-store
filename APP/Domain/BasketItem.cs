namespace APP.Domain;

public class BasketItem : Entity
{
    public virtual Item Item { get; set; } = null!;
    public virtual Basket Basket { get; set; } = null!;
    public int Quantity { get; set; }
}