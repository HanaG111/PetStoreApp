using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;
public class FindByIdQuery : IRequest<Pet>
{
    public int PetId { get; set; }
}


