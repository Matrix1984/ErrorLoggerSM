using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.ErrorLogTypes.Commands.CreateErrorLogTypeCommand;
using ErrorLoggerSM.Application.ErrorLogTypes.Commands.DeleteErrorLogType;
using ErrorLoggerSM.Application.ErrorLogTypes.Queries;
using ErrorLoggerSM.Application.TargetSystems.Commands.UpdateTargetSystem;
using ErrorLoggerSM.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;

public class ErrorLogTypes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetErrorLogsWithPagination)
            .MapPost(CreateErrorLog)
            .MapPut(UpdateLogType, "{id}")
            .MapDelete(DeleteLogType, "{id}");
    }

    public async Task<Ok<PaginatedList<ErrorLogTypeDto>>> GetErrorLogsWithPagination(ISender sender, [AsParameters] GetLogTypeWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateErrorLog(ISender sender, CreateErrorLogTypeCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(ErrorLogType)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateLogType(ISender sender, int id, UpdateTargetSystemCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteLogType(ISender sender, int id)
    {
        await sender.Send(new DeleteErrorLogTypeCommand(id));

        return TypedResults.NoContent();
    }
}
