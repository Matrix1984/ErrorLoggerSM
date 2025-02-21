using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.TargetApps.Commands.CreateTargetApp;
using ErrorLoggerSM.Application.TargetApps.Commands.DeleteTargetApp;
using ErrorLoggerSM.Application.TargetApps.Commands.UpdateTargetApp;
using ErrorLoggerSM.Application.TargetApps.Query;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;

public class TargetApps : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTargetAppsWithPagination)
            .MapPost(CreateErrorComment)
            .MapPut(UpdateTargetApp, "{id}")
            .MapDelete(DeleteTargetApp, "{id}");
    }

    public async Task<Ok<PaginatedList<TargetAppDto>>> GetTargetAppsWithPagination(ISender sender, [AsParameters] GetTargetAppWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateErrorComment(ISender sender, CreateTargetSystemCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(TargetApps)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateTargetApp(ISender sender, int id, UpdateTargetAppCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteTargetApp(ISender sender, int id)
    {
        await sender.Send(new DeleteTargetAppCommand(id));

        return TypedResults.NoContent();
    }
}
