using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Commands;

public class EditPetCommand : IRequest<PetModel>
{
    public int PetId { get; set; }
    public string PetName { get; set; }
    public string Category { get; set; }
    public string Status { get; set; }
}