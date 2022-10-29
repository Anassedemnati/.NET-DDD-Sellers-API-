using MongoDB.Bson.Serialization.Attributes;

namespace SalerServiceCore.Infrastructure.SellersRepository.Dtos;

public class RulesDto
{
    [BsonElement("WhiteListedCountries")]
    public IReadOnlyList<string>? WhiteListedCountries { get; set; }
    [BsonElement("BlackListedCountries")]
    public IReadOnlyList<string>? BlackListedCountries { get; set; }
    
}