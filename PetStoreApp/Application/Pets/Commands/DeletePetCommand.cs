using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Commands;
public class DeletePetCommand : IRequest<PetModel>
{
    public int PetId { get; set; }
}