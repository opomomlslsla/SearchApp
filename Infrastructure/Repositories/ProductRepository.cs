using Domain.Entities;
using Infrastructure.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal class ProductRepository(Context context) : BaseRepository<Product>(context)
{
}
