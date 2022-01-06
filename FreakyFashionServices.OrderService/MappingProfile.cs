using AutoMapper;
using FreakyFashionServices.OrderService.Models.Domain;
using FreakyFashionServices.OrderService.Models.DTO;

namespace FreakyFashionServices.OrderService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDto, Orders>().ForMember(x => x.OrderLines, z => z.MapFrom(source => source.Items));
            CreateMap<OrderLineDto, OrderLine>();
        }
    }
}
