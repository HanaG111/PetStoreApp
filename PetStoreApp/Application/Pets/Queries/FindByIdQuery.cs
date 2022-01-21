using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;
public class FindByIdQuery : IRequest<PetModel>
{
    public int PetId { get; set; }
}


