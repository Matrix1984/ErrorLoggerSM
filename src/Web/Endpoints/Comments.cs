using ErrorLoggerSM.Application.Comments.Commands.CreateComment;
using ErrorLoggerSM.Application.Comments.Commands.DeleteComment;
using ErrorLoggerSM.Application.Comments.Commands.UpdateComment;
using ErrorLoggerSM.Application.Comments.Queries;
using ErrorLoggerSM.Application.Common.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;

public class Comments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCommentsWithPagination)
            .MapPost(CreateErrorComment)
            .MapPut(UpdateTodoItem, "{id}") 
            .MapDelete(DeleteTodoItem, "{id}");
    }

    public async Task<Ok<PaginatedList<CommentDto>>> GetCommentsWithPagination(ISender sender, [AsParameters] GetCommentQueryWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateErrorComment(ISender sender, CreateCommentCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Comments)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateTodoItem(ISender sender, int id, UpdateCommentCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    } 

    public async Task<NoContent> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteCommentCommand(id));

        return TypedResults.NoContent();
    }
}
