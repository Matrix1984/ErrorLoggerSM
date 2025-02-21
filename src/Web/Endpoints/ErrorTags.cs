using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.ErrorTags.Commands.CreateErrorTag;
using ErrorLoggerSM.Application.ErrorTags.Commands.DeleteErrorTag;
using ErrorLoggerSM.Application.ErrorTags.Commands.UpdateErrorTag;
using ErrorLoggerSM.Application.ErrorTags.Queries;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints; 

public class ErrorTags : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetErrorTagsWithPagination)
            .MapPost(CreateErrorComment)
            .MapPut(UpdateErrorTag, "{id}")
            .MapDelete(DeleteErrorTag, "{id}");
    }

    public async Task<Ok<PaginatedList<ErrorTagVM>>> GetErrorTagsWithPagination(ISender sender, [AsParameters] GetErrorTagsWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateErrorComment(ISender sender, CreateErrorTagCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(ErrorTags)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateErrorTag(ISender sender, int id, UpdateErrorTagCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteErrorTag(ISender sender, int id)
    {
        await sender.Send(new DeleteErrorTagCommand(id));

        return TypedResults.NoContent();
    }
}
