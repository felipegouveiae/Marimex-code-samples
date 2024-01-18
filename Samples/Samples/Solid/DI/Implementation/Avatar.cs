namespace Samples.Solid.DI.Implementation;

public class Product
{
    #region ...

    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }

    #endregion
    public int AvatarId { get; set; }
}

public class Category
{
    #region ...
    public int Id { get; set; }
    public string Name { get; set; }
    #endregion
    public int AvatarId { get; set; }
}

public class User
{
    #region ...
    public int Id { get; set; }
    public string Name { get; set; }
    #endregion
    public int AvatarId { get; set; }
}

public class Image
{
    public int Id { get; set; }
    public byte[] Blob { get; set; }
}




