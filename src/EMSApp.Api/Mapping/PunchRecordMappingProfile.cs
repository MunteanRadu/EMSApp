using AutoMapper;
using EMSApp.Domain;

namespace EMSApp.Api;

public class PunchRecordMappingProfile : Profile
{
    public PunchRecordMappingProfile()
    {
        CreateMap<PunchRecord, PunchRecordDto>();
    }
}
