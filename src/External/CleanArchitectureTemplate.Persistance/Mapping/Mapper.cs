using AutoMapper;
using CleanArchitectureTemplate.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureTemplate.Application.Features.ProductFeatures.Commands.CreateProduct;
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
    }
}
