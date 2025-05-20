using AutoMapper;
using EMSApp.Domain;

namespace EMSApp.Api;

public class AssignmentFeedbackMappingProfile : Profile
{
    public AssignmentFeedbackMappingProfile()
    {
        CreateMap<AssignmentFeedback, AssignmentFeedbackDto>();
    }
}
