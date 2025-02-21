using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.TargetApps.Commands.CreateTargetApp;
using ErrorLoggerSM.Application.TargetSystems.Commands.DeleteTargetSystem;
using ErrorLoggerSM.Application.TargetSystems.Commands.UpdateTargetSystem;
using ErrorLoggerSM.Application.TargetSystems.Queries;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;

public class TargetSystems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTargetSystemsWithPagination)
            .MapPost(CreateTargetSystems)
            .MapPut(UpdateTargetSystem, "{id}")
            .MapDelete(DeleteTargetSystem, "{id}");
    }

    public async Task<Ok<PaginatedList<TargetSystemDto>>> GetTargetSystemsWithPagination(ISender sender, [AsParameters] GetTargetSystemWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateTargetSystems(ISender sender, CreateTargetSystemCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(TargetSystems)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateTargetSystem(ISender sender, int id, UpdateTargetSystemCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteTargetSystem(ISender sender, int id)
    {
        await sender.Send(new DeleteTargetSystemCommand(id));

        return TypedResults.NoContent();
    }
}
