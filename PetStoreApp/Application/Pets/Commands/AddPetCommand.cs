using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Commands;

public class AddPetCommand : IRequest<Pet>
{
    public string PetName { get; set; }
    public PetStatus PetStatus { get; set; }
    public Category Category { get; set; }
}