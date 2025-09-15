using CleanArchitectureTemplate.Domain.Entitie;
using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Persistance.Contexts;

namespace CleanArchitectureTemplate.Persistance.Repositories;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(ApplicationDbContext _context, IUnitOfWork _unitOfWork) : base(_context, _unitOfWork)
    {
        
    }
}
