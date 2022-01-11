using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Queries
{
    public class GetPetListQuery : IRequest<List<PetModel>>
    {
        
    }
    
}
