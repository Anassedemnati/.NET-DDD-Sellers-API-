using Microsoft.AspNetCore.Mvc;
using SalerServiceCore.Domain.SellerAggregate.Abstractions;
using SalerServiceCore.Domain.SellerAggregate.Models;

namespace SalerServiceCore.Api.SellerFeature;
[Route("[controller]")]
[ApiController]
public class SellersController : ControllerBase
{
    private readonly ISellerHandler _sellerHandler;

    public SellersController(ISellerHandler sellerHandler)
    {
        _sellerHandler = sellerHandler;
    }
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Seller>>> sellersAsync()
    {
        try
        {
            IReadOnlyList<Seller> sellers = await _sellerHandler.GetSellersAsync().ConfigureAwait(false);//ConfigureAwait(false) norme cidscount
            if (sellers is null || sellers?.Count<=0)
            {
                return NotFound();
            }
            
            return Ok(sellers);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}