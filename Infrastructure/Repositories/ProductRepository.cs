using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

internal class ProductRepository(Context context) : BaseRepository<Product>(context);
