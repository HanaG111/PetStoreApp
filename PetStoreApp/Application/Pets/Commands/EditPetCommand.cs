using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Commands;

public class EditPetCommand : IRequest<PetModel>
{
    public string PetName { get; set; }
    public string Category { get; set; }
    public string Status { get; set; }
}