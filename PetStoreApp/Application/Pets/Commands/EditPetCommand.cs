using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Commands;
public class EditPetCommand : IRequest<Pet>
{
    public string PetName { get; set; }
    
    public string Status { get; set; }
    
    public string Category { get; set; }
}