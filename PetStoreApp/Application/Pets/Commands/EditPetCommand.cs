using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Commands;
public class EditPetCommand : IRequest<Pet>
{
    public int PetId { get; set; }
    public PetDto PetDto { get; set; }
}