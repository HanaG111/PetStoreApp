using MediatR;
using PetStoreApp.Application.Users.UserService;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Commands;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserModel>
{
    private readonly IUserService _userService;
    public DeleteUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<UserModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user= _userService.GetUsers().FirstOrDefault(x => x.UserId == request.UserId);

        if (user == null)
        {
            throw new ApplicationException("No User with this Id");
        }

        return await Task.FromResult(_userService.DeleteUser(user));
    }
}
