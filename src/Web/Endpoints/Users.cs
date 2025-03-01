using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.Users;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;

public class Users : EndpointGroupBase
{

    private readonly IIdentityService _identityService;
    public Users(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetUser)
            .MapPost(CreateUser)
            .MapDelete(DeleteUser, "{id}");
    }

    public async Task<IResult> GetUser([AsParameters] string id)
    {
        var result = await _identityService.GetUserNameAsync(id);

        if (String.IsNullOrEmpty(result))
            return TypedResults.NotFound(result ?? String.Empty);

        return TypedResults.Ok(result);
    }

    public async Task<Created<string>> CreateUser(CreateUserDto req)
    {
        (Result result, string UserId)= await _identityService.CreateUserAsync(req.Name, req.Password); 

        return TypedResults.Created($"/{nameof(Users)}/{UserId}", UserId);
    }

    public async Task<NoContent> DeleteUser(ISender sender, string id)
    { 
        var result = await _identityService.DeleteUserAsync(id); 
       
        return TypedResults.NoContent();
    }
}
