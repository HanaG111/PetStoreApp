using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Pets.Commands;

public class AddPetCommand : IRequest<Pet>
{
    public string PetName { get; set; }

    public PetStatus PetStatus { get; set; }

    public Category Category { get; set; }
}
