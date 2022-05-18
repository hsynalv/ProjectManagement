using AutoMapper;
using ProjectManagement.Entities.Models;
using ProjectManagement.Shared.DataTransferObject;

namespace ProjectManagement.API.Utilities.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}