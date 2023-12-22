using AutoMapper;
using virtualPetCare.Application.ActivityOperations.Commands.CreateActivity;
using virtualPetCare.Application.ActivityOperations.Queries.GetActivitiesById;
using virtualPetCare.Application.FoodOperations.Queries.GetFoods;
using virtualPetCare.Application.HealthStatus.Commands.PatchHealthStatus;
using virtualPetCare.Application.HealthStatusOperations.Queries.GetHealthStatusByIdQuery;
using virtualPetCare.Application.PetOperations.Commands.CreatePet;
using virtualPetCare.Application.PetOperations.Commands.UpdatePet;
using virtualPetCare.Application.PetOperations.Queries.GetPetById;
using virtualPetCare.Application.PetOperations.Queries.GetPets;
using virtualPetCare.Application.PetOperations.Queries.GetPetStatisticsById;
using virtualPetCare.Application.TrainingOperations.Queries.GetTrainingsForPetById;
using virtualPetCare.Application.UserOperations.Commands.CreateUser;
using virtualPetCare.Application.UserOperations.Queries.GetUserById;
using virtualPetCare.Entities;

namespace virtualPetCare.Common
{

    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateUserModelDto,User>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserCreateViewModel>();
            CreateMap<CreatePetModelDto,Pet>();
            CreateMap<Pet,PetCreateViewModel>();
            CreateMap<Pet, PetViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src=>src.User.Name));
            CreateMap<Pet, PetsViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));
            CreateMap<UpdatePetModelDto, Pet>();
            CreateMap<HealthStatus,HealthStatusViewModel>();
            CreateMap<Pet, PatchHealthStatusModelDto>().ReverseMap();
            CreateMap<CreateActivityModelDto,Activity>();
            CreateMap<Activity, ActivityCreateViewModel>();
            CreateMap<Activity, ActivitiesViewModel>();
            CreateMap<Food,FoodViewModel>();
            CreateMap<Pet, PetStatisticViewModel>().ForMember(dest=> dest.HealthStatusName,opt=>opt.MapFrom(src=> src.HealthStatus.Name))
                                                   .ForMember(dest => dest.Foods,opt => opt.MapFrom(src=>src.Foods.Select(f=>f.Name)))
                                                   .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity.Select(a => a.Name)));
            
            CreateMap<Training, TrainingsForPetViewModel>();

        }
    }
}
