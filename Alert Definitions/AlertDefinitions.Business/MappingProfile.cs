using AutoMapper;
using AlertDefinitions.Models;

namespace AlertDefinitions.Business;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LogLevels, LogLevelExpression>();
    }
}