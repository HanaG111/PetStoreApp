using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;
public class FindByStatusQuery : IRequest<Pet>
{
    public string Status { get; set; }
}

