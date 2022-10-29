using SalerServiceCore.Domain.SellerAggregate.Models;
using SalerServiceCore.Infrastructure.SellersRepository.Dtos;

namespace SalerServiceCore.Infrastructure.SellersRepository.Assemblers;

public static class SellerAssembler
{
    public static IReadOnlyList<Seller> ToSellers(this IReadOnlyList<SellerDto> sellerDtos)
    {
        var result = new List<Seller>();
        if (sellerDtos ?.Count>0)
        {
            result.AddRange(
                from sellerDto in sellerDtos 
                where sellerDto != null 
                select sellerDto.ToSeller()
                );
        }

        return result;
    }
    public static Seller ToSeller(this SellerDto sellerDto)
    {
        if (sellerDto != null)
        {
            return new Seller()
            {
                Id = sellerDto.Id.ToString(),
                IsActive = sellerDto.IsActive,
                Name = sellerDto.Name,
                Type = sellerDto.Type,
                LogoUrl = sellerDto.LogoUrl,
                ProductsIds = sellerDto.ProductsIds,
                Rules = sellerDto.Rules?.toRules(),
            };
        }

        return new Seller();
    }

    public static Rules toRules(this RulesDto rulesDto)
    {
        if (rulesDto!=null)
        {
            return new Rules()
            {
                BlackListedCountries = rulesDto.BlackListedCountries,
                WhiteListedCountries = rulesDto.WhiteListedCountries
            };
        }

        return new Rules();
    }
}