using System.Collections.Generic;

namespace Testing.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int categoryID { get; set; }
    public int OnSale { get; set; }
    public int StockLevel { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}