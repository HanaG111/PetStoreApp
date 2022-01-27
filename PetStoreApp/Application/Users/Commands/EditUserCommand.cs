using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Commands;
public class EditUserCommand : IRequest<User>
{
    public int UserId { get; set; }
    public UserDto UserDto { get; set; }
}