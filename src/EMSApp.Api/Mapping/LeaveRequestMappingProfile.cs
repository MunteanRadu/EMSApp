using AutoMapper;
using EMSApp.Domain;

namespace EMSApp.Api;

public class LeaveRequestMappingProfile : Profile
{
    public LeaveRequestMappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestDto>();
    }
}
