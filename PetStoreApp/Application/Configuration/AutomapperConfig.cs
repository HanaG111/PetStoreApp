using AutoMapper;
using PetStoreApp.Infrastructure.Dtos;
using PetStoreApp.Infrastructure.Dtos;
using PetStoreApp.Domain.Models;
using PetStoreApp.Presentation.Controllers;

namespace PetStoreApp.Application.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Pet, AddPetDto>().ReverseMap();
        CreateMap<Pet, EditPet>().ReverseMap();
        CreateMap<Pet, DeletePet>().ReverseMap();
        CreateMap<Pet, PetResult>().ReverseMap();
    }
}