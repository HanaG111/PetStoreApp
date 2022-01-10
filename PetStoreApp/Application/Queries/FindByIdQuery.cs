using PetStoreApp.Application.Models;
using MediatR;

namespace PetStoreApp.Application.Queries;

public record FindByIdQuery (int PetId) : IRequest<PetModel>;

//public class FindByIdQueryClass : IRequest<PetModel>
//{
//    public int PetId { get; set; }

//    public FindByIdQueryClass(int Petid)
//    {
//        PetId = petId;
//    }
//}
