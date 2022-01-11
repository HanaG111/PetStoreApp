using PetStoreApp.Domain.Models;
using MediatR;


namespace PetStoreApp.Application.Commands;

public class DeletePetCommand : IRequest<PetModel>
{
    public int PetId { get; set; }

}