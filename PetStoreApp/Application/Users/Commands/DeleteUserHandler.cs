using MediatR;
using PetStoreApp.Application.Users.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Commands;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User>
{
    private readonly IUserService _userService;
    public DeleteUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user= _userService.GetUsers().FirstOrDefault(x => x.UserId == request.UserId);

        if (user == null)
        {
            throw new ApplicationException("No User with this Id");
        }

        return await Task.FromResult(_userService.DeleteUser(user));
    }
}
