using SalerServiceCore.Domain.SellerAggregate.Models;

namespace SalerServiceCore.Domain.SellerAggregate.Abstractions;

public interface ISellerRepository
{
    Task<IReadOnlyList<Seller>> GetSellerAsync();
}