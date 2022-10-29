using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SalerServiceCore.Infrastructure.SellersRepository.Dtos;

public class SellerDto
{
    [BsonElement("_id")]
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement("name")]
    public string? Name { get; set; }
    [BsonElement("type")]
    public string? Type { get; set; }
    [BsonElement("isActive")]
    public bool? IsActive { get; set; }
    [BsonElement("logoUrl")]
    public string? LogoUrl { get; set; }
    
    public IReadOnlyList<string>? ProductsIds { get; set; }

    public RulesDto Rules { get; set; } 


}