using SalerServiceCore.Domain.SellerAggregate.Abstractions;
using SalerServiceCore.Domain.SellerAggregate.Models;

namespace SalerServiceCore.Domain.SellerAggregate;

public class SellerHandler:ISellerHandler
{
    private readonly  ISellerRepository _sellerRepository;

    public SellerHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<IReadOnlyList<Seller>> GetSellersAsync()
    {
        return await _sellerRepository.GetSellerAsync();
    }
}