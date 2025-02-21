using ErrorLoggerSM.Application.Comments.Commands.CreateComment;
using ErrorLoggerSM.Application.Comments.Commands.DeleteComment;
using ErrorLoggerSM.Application.Comments.Commands.UpdateComment;
using ErrorLoggerSM.Application.Comments.Queries;
using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.ErrorEntities.Commands.CreateErrorEntity;
using ErrorLoggerSM.Application.ErrorEntities.Commands.DeleteErrorEntity;
using ErrorLoggerSM.Application.ErrorEntities.Commands.UpdateErrorEntity;
using ErrorLoggerSM.Application.ErrorEntities.Queries;
using ErrorLoggerSM.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints; 

public class ErrorEntities : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetErrorEntitiesWithPagination)
            .MapPost(CreateErrorEntity)
            .MapPut(UpdateErrorEntity, "{id}")
            .MapDelete(DeleteErrorEntity, "{id}");
    }

    public async Task<Ok<PaginatedList<ErrorEntityDto>>> GetErrorEntitiesWithPagination(ISender sender, [AsParameters] GetErrorEntitiesWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateErrorEntity(ISender sender, CreateErrorEntityCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(ErrorEntity)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateErrorEntity(ISender sender, int id, UpdateErrorEntityCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteErrorEntity(ISender sender, int id)
    {
        await sender.Send(new DeleteErrorEntityCommand(id));

        return TypedResults.NoContent();
    }
}
