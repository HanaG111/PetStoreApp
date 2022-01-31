using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;
public class FindByStatusQuery : IRequest<Pet>
{
    public PetStatus PetStatus { get; set; }
}


