using AutoMapper;
using FormulaOne.Dtos.Requests;
using FormulaOne.Models;

namespace FormulaOne.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateDriverAchievementRequest, Achievement>()
        .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
        .ForMember(dest => dest.status, opt => opt.MapFrom(src => 1))
        .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
        .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateDriverAchievementRequest, Achievement>()
        .ForMember(dest => dest.RaceWins, opt => opt.MapFrom(src => src.Wins))
        .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CreateDriverRequest, Driver>()
        .ForMember(dest => dest.status, opt => opt.MapFrom(src => 1))
        .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
        .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateDriverRequest, Driver>()
        .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

    }
}