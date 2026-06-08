namespace StorageApi.API.Models;

public class Product    
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    public required string Category { get; set; }
    public required string Shelf { get; set; }
    public int Count { get; set; }
    public required string Description { get; set; }

    public Product() {}

    public Product(int id, string name, int price, string category, string shelf, int count, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
        Shelf = shelf;
        Count = count;
        Description = description;
    }
    
}