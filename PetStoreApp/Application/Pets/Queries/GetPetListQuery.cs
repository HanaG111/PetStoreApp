using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;
public class GetPetListQuery : IRequest<List<PetModel>>
    {
    }

