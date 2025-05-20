using AutoMapper;
using EMSApp.Domain.Entities;

namespace EMSApp.Api;

public class UserProfileMappingProfile : Profile
{
    public UserProfileMappingProfile()
    {
        CreateMap<UserProfile, UserProfileDto>();
    }
}
