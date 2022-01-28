using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Pets.Commands;

public class AddPetCommand : IRequest<Pet>
{
    public string PetName { get; set; }

    public string Status { get; set; }

    public string Category { get; set; }
}