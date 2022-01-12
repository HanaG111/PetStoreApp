using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Commands;
public class AddPetCommand : IRequest<PetModel>
{
    public string PetName { get; set; }
    public string Category { get; set; }
    public string Status { get; set; }
}