using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;

public class FindByStatusQuery : IRequest<PetModel>
{
    public string Status { get; set; }
}

