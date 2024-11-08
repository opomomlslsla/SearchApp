using Application.DTO;

namespace Application.Queries;

public class GetProductsQueryResult
{
    public ICollection<ProductDTO> Products { get; set; }
}
