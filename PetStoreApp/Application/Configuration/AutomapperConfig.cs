using AutoMapper;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Infrastructure.Dtos;
using PetStoreApp.Presentation.Controllers;

namespace PetStoreApp.Application.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Pet, AddPetDto>().ReverseMap();
        CreateMap<Pet, PetModelDto>().ReverseMap();
        CreateMap<Pet, DeletePet>().ReverseMap();
        CreateMap<Pet, PetResult>().ReverseMap();
    }
}