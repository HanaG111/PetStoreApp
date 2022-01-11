using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Queries;

public class FindByStatusQuery : IRequest<PetModel>
{
    public int Status { get; set; }
}