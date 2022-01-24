using MediatR;
using PetStoreApp.Application.Users.UserService;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Queries;

public class FindByUsernameHandler : IRequestHandler<FindByUsernameQuery, UserModel>
{
    private readonly IUserService _userService;
    
    public FindByUsernameHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<UserModel> Handle(FindByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = _userService.GetUsers().FirstOrDefault(x => x.Username == request.Username);

        if (user.Username is not ("hanag"))
        {
            throw new ApplicationException("This user does not exist");
        }
        return await Task.FromResult(user);
    }
}