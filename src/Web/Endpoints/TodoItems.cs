﻿using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.TodoItems.Commands.CreateTodoItem;
using ErrorLoggerSM.Application.TodoItems.Commands.DeleteTodoItem;
using ErrorLoggerSM.Application.TodoItems.Commands.UpdateTodoItem;
using ErrorLoggerSM.Application.TodoItems.Commands.UpdateTodoItemDetail;
using ErrorLoggerSM.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorLoggerSM.Web.Endpoints;

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoItemsWithPagination)
            .MapPost(CreateTodoItem)
            .MapPut(UpdateTodoItem, "{id}")
            .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteTodoItem, "{id}");
    }

    public async Task<Ok<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination(ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(TodoItems)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateTodoItem(ISender sender, int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<Results<NoContent, BadRequest>> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();
        
        await sender.Send(command);
        
        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));

        return TypedResults.NoContent();
    }
}
