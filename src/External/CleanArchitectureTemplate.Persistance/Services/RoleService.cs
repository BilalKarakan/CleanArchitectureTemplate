using AutoMapper;
using CleanArchitectureTemplate.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitectureTemplate.Application.IServices;
using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureTemplate.Persistance.Services;

public class RoleService(RoleManager<Role> _roleManager, IMapper _mapper) : IRoleService
{
    public async Task CreateAsync(CreateRoleCommand request)
    {
        await _roleManager.CreateAsync(_mapper.Map<Role>(request));
    }
}
