using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

internal class GetProductsQueryHandler(IRepository<Product> productRepository) : IRequestHandler<GetProductsQuery, GetProductsQueryResult>
{
    public async Task<GetProductsQueryResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetByAsync(x => EF.Functions.Like(x.Name, $"%{query.Name}%"));

        return new GetProductsQueryResult {Products = products.Adapt<ICollection<ProductDTO>>()};
    }
}
