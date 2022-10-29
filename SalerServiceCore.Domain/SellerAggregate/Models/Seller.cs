namespace SalerServiceCore.Domain.SellerAggregate.Models;

public class Seller
{
    public string Id { get; set; }
   
    public string? Name { get; set; }
    
    public string? Type { get; set; }
    
    public bool? IsActive { get; set; }
    
    public string? LogoUrl { get; set; }
    
    public IReadOnlyList<string>? ProductsIds { get; set; }

    public Rules Rules { get; set; } 
}