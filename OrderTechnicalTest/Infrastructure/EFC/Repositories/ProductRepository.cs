using OrderTechnicalTest.Domain.Model.Entities;
using OrderTechnicalTest.Domain.Repositories;
using OrderTechnicalTest.Infrastructure.EFC.Context;

namespace OrderTechnicalTest.Infrastructure.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository;