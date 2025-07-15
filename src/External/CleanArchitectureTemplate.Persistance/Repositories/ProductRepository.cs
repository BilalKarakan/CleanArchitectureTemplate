using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;

namespace CleanArchitectureTemplate.Persistance.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext _context, IUnitOfWork _unitOfWork) : base(_context, _unitOfWork)
    {
    }
}
