using AutoMapper;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
using CleanArchitectureTemplate.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitectureTemplate.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitectureTemplate.Domain.Entitie;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Persistance.Mapping;

public class Mapper : Profile
{
    public Mapper()
    {
        #region Product
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        #endregion

        #region User
        CreateMap<RegisterCommand, User>().ReverseMap();
        #endregion

        #region Role
        CreateMap<CreateRoleCommand, Role>().ReverseMap();
        #endregion

        #region UserRole
        CreateMap<CreateUserRoleCommand, UserRole>().ReverseMap();
        #endregion
    }
}
