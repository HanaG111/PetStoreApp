using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Queries;

public class FindByIdQuery : IRequest<PetModel>
{
    public int PetId { get; set; }
}


