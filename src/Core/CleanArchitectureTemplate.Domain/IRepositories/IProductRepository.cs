using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Domain.IRepositories;

public interface IProductRepository : IGenericCommandRepository<Product>, IGenericQueryRepository<Product>
{

}
