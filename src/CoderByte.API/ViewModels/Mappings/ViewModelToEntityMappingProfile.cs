using AutoMapper;
using CoderByte.API.Model.Entities;

namespace CoderByte.API.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.EmployeeNumber));
        }
    }
}