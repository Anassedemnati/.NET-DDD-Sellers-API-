using SalerServiceCore.Domain.SellerAggregate.Models;

namespace SalerServiceCore.Domain.SellerAggregate.Abstractions;

public interface ISellerHandler
{
    Task<IReadOnlyList<Seller>> GetSellersAsync();
}