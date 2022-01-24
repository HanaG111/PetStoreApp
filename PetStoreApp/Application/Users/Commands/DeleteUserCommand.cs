using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Commands;
public class DeleteUserCommand : IRequest<UserModel>
{
    public int UserId { get; set; }
    public UserModelDto UserDto { get; set; }
}