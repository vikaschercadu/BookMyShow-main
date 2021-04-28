using AutoMapper;
using BookMyShow.Enums;

namespace BookMyShow.Models
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<BookingDTO, Booking>().ReverseMap();
            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<HallDTO, TheatreHall>().ReverseMap();
            CreateMap<MovieDTO, Movie>().ReverseMap();
            CreateMap<Seat, SeatDTO>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => (SeatStatus)src.Status));
            CreateMap<SeatDTO, Seat>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));
            CreateMap<ShowDTO, Show>().ReverseMap();
            CreateMap<TheatreDTO, Theatres>().ReverseMap();
            CreateMap<TheatreShowsDetailsView, TheatreShowsDetailsViewModel>().ReverseMap();
        }
    }
}
