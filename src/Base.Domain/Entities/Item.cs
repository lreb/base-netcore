namespace Base.Domain.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}