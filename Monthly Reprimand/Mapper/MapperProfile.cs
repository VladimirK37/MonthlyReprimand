using AutoMapper;
using MonthlyReprimand.Data.Entities;
using MonthlyReprimand.Models.Response;
using MonthlyReprimand.Models.Request;

namespace MonthlyReprimand.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Shift, ShiftResponse>();
            CreateMap<Employee, GetEmployeesResponse>();

            CreateMap<Employee, CreateEmployeeResponse>();
            CreateMap<CreateEmployeeRequest, Employee>();

            CreateMap<Employee, UpdateEmployeeResponse>();
        }
    }
}
