using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Commands;
public class EditPetCommand : IRequest<PetModel>
{
    public int PetId { get; set; }
    public PetModel Pet { get; set;  }
}