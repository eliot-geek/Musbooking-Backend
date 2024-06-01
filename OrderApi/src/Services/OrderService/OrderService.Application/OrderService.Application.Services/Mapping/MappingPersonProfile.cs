using AutoMapper;
using OrderService.Application.Services.Dto;
using OrderService.Domain.Entities;

namespace OrderService.Application.Services.Mapping;

public class MappingOrderProfile : Profile
{
    public MappingOrderProfile()
    {
        CreateMap<Equipment, EquipmentResponse>();

        CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedDate.CreatedAt));
    }
}