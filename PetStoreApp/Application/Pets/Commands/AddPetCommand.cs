using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Pets.Commands;
public class AddPetCommand : IRequest<PetModel>
{
    public int PetId { get; set; }
    public PetModelDto PetDto { get; set; }
}