using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.LogSmEvents.Commands;
using ErrorLoggerSM.Application.LogSmEvents.Queries;
using ErrorLoggerSM.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;

public class LogSmEvents : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetSysEventWithPagination)
            .MapPost(CreateSysEvent);
    }

    public async Task<Ok<PaginatedList<LogSMEventDto>>> GetSysEventWithPagination(ISender sender, [AsParameters] GetLogSmEventWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateSysEvent(ISender sender, CreateLogSmEventCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(SysEvent)}/{id}", id);
    }

}
