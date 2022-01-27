using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Queries;
public class GetUserListQuery : IRequest<List<User>>
{
}