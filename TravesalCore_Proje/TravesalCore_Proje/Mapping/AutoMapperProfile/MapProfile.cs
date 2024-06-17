using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TravesalCore_Proje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announement>();
            CreateMap<Announement, AnnouncementAddDto>();

            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();

            CreateMap<AppUserLoginDTOs, AppUser>();
            CreateMap<AppUser, AppUserLoginDTOs>();

            //CreateMap<AnnouncementViewListModelDTO, Announement>();
            //CreateMap<Announement, AnnouncementViewListModelDTO>();

            CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
            //reversemap tersini aldırır



        }
    }
}
