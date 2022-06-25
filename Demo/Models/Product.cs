namespace Demo.Models;

public class Product {
    public int id { get; set; }
    public string name { get; set; }
    public int categoryId { get; set; }
    public Category category { get; set; }
}
