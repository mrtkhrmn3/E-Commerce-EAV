using AutoMapper;
using ECommerceEAV.Domain.Models;
using ECommerceEAV.Application.Features.Categories.Commands;
using ECommerceEAV.Application.DTOs;
using ECommerceEAV.Application.Features.Users.Commands;
using ECommerceEAV.Application.Features.Products.Commands;
using ECommerceEAV.Application.Features.ProductAttributeValues.Commands;
using ECommerceEAV.Application.Features.ProductAttributes.Commands;
using ECommerceEAV.Application.Features.Orders.Commands;
using ECommerceEAV.Application.Features.OrderDetails.Commands;
using ECommerceEAV.Application.Features.AppUserProfiles.Commands;

namespace ECommerceEAV.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<ProductAttribute, ProductAttributeDto>();
            CreateMap<CreateProductAttributeCommand, ProductAttribute>();
            CreateMap<UpdateProductAttributeCommand, ProductAttribute>();

            CreateMap<ProductAttributeValue, ProductAttributeValueDto>();
            CreateMap<CreateProductAttributeValueCommand, ProductAttributeValue>();
            CreateMap<UpdateProductAttributeValueCommand, ProductAttributeValue>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();

            CreateMap<AppUser, UserDto>();
            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();

            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<CreateOrderDetailCommand, OrderDetail>();
            CreateMap<UpdateOrderDetailCommand, OrderDetail>();

            CreateMap<AppUserProfile, AppUserProfileDto>();
            CreateMap<CreateAppUserProfileCommand, AppUserProfile>();
            CreateMap<UpdateAppUserProfileCommand, AppUserProfile>();
        }
    }
}

