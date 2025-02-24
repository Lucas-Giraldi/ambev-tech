using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModifiedSale;

public class ModifySaleRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string CartId { get; set; }
    public string CustomerName { get; set; }
    public string Branch { get; set; }
    public bool IsCanceled { get; set; }
}
