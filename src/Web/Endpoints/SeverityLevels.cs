using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.SeverityLevels.Commands.CreateSeverityLevel;
using ErrorLoggerSM.Application.SeverityLevels.Commands.DeleteSeverityLevel;
using ErrorLoggerSM.Application.SeverityLevels.Commands.UpdateSeverityLevel;
using ErrorLoggerSM.Application.SeverityLevels.Query;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;
public class SeverityLevels : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetSeverityLevelsWithPagination)
            .MapPost(CreateSeverityLevel)
            .MapPut(UpdateSeverityLevels, "{id}")
            .MapDelete(DeleteSeverityLevels, "{id}");
    }

    public async Task<Ok<PaginatedList<SeverityLevelDto>>> GetSeverityLevelsWithPagination(ISender sender, [AsParameters] GetSeverityWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateSeverityLevel(ISender sender, CreateSeverityLevelCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(SeverityLevels)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateSeverityLevels(ISender sender, int id, UpdateSeverityLevelCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteSeverityLevels(ISender sender, int id)
    {
        await sender.Send(new DeleteSeverityLevelCommand(id));

        return TypedResults.NoContent();
    }
}
