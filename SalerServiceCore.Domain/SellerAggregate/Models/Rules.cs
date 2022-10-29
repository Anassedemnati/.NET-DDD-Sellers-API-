namespace SalerServiceCore.Domain.SellerAggregate.Models;

public class Rules
{
    public IReadOnlyList<string>? WhiteListedCountries { get; set; }
    public IReadOnlyList<string>? BlackListedCountries { get; set; }
}