using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.SysErrors.Commands.CreateSysError;
using ErrorLoggerSM.Application.SysErrors.Querries;
using ErrorLoggerSM.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;
 
public class SysErrors : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetSysErrorsWithPagination)
            .MapPost(CreateSysError);
    }

    public async Task<Ok<PaginatedList<SysErrorBriefDto>>> GetSysErrorsWithPagination(ISender sender, [AsParameters] GetSysErrorsWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateSysError(ISender sender, CreateSysErrorCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(SysError)}/{id}", id);
    }



}
