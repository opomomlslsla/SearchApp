using MediatR;

namespace Application.Queries;

public class GetProductsQuery : IRequest<GetProductsQueryResult>
{
    public GetProductsQuery(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}