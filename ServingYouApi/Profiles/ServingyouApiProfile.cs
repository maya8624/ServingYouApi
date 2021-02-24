using AutoMapper;
using ServingyouApi.Models;
using ServingyouApi.Dtos;

namespace ServingyouApi.Profiles
{
    public class ServingyouApiProfile : Profile
    {
        public ServingyouApiProfile()
        {
            // Source -> target
            CreateMap<Booking, BookingReadDto>();
            CreateMap<BookingCreateDto, Booking>();
            CreateMap<Member, MemberReadDto>();
            CreateMap<MemberCreateDto, Member>();
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
        }
    }
}
