using AutoMapper;
using EMSApp.Domain;

namespace EMSApp.Api;

public class PolicyMappingProfile : Profile
{
    public PolicyMappingProfile()
    {
        CreateMap<Policy, PolicyDto>();
    }
}
