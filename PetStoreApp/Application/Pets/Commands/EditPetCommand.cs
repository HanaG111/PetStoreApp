using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Commands;
public class EditPetCommand : IRequest<PetModel>
{
    public int PetId { get; set; }
    public PetModelDto PetDto { get; set; }
}