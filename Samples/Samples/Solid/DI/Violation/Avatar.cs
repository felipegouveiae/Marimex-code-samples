namespace Samples.Solid.DI.Violation;

public class Product
{
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Image
{
    public int Id { get; set; }
    public byte[] Blob { get; set; }
    public int? ProductId { get; set; }
    public int? CategoryId { get; set; }
    public int? UserId { get; set; }
}









