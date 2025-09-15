using AutoMapper;
using CleanArchitectureTemplate.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitectureTemplate.Application.IServices;
using CleanArchitectureTemplate.Domain.Entitie;
using CleanArchitectureTemplate.Domain.IRepositories;

namespace CleanArchitectureTemplate.Persistance.Services;

public class UserRoleService(IUserRoleRepository _userRoleRepository, IMapper _mapper) : IUserRoleService
{
    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRoleRepository.CreateAsync(_mapper.Map<UserRole>(request), cancellationToken);
    }
}
