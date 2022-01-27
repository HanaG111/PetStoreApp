using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Pets.Commands;
public class AddPetCommand : IRequest<Pet>
{
    public int PetId { get; set; }
    public PetDto PetDto { get; set; }
}