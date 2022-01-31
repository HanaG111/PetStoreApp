using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Commands;
public class EditPetCommand : IRequest<Pet>
{
    public string PetName { get; set; }
    
    public PetStatus PetStatus { get; set; }

    public Category Category { get; set; }
}
