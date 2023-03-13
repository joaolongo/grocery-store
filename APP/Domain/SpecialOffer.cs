namespace APP.Domain;

public class SpecialOffer : Entity
{
    public string Description { get; set; } = null!;
    public virtual Item Item { get; set; } = null!;
    public Guid ItemId { get; set; }
    public decimal Percentage { get; set; }
    public int RequiredAmount { get; set; } = 1;
    public virtual Item? DiscountItem { get; set; }
    public Guid? DiscountItemId { get; set; }
}