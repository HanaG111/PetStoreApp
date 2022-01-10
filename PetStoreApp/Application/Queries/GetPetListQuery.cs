using PetStoreApp.Application.Models;
using MediatR;

namespace PetStoreApp.Application.Queries
{
public record GetPetListQuery() : IRequest<List<PetModel>>;

//public class GetPetListQueryClass : IRequest<List<PetModel>>
//{
//}
    
}
