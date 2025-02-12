//using ErrorLoggerSM.Application.Common.Interfaces;
//using ErrorLoggerSM.Application.Common.Mappings;
//using ErrorLoggerSM.Application.Common.Models;
//using ErrorLoggerSM.Application.TodoItems.Queries.GetTodoItemsWithPagination;
//using ErrorLoggerSM.Application.TodoLists.Queries.GetTodos;

//namespace ErrorLoggerSM.Application.ErrorTags.Queries;

//public record GetErrorTagsWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
//{ 
//    public int PageNumber { get; init; } = 1;
//    public int PageSize { get; init; } = 10;
//}

//public class GetErrorTagsWithPaginationQueryHandler : IRequestHandler<GetErrorTagsWithPaginationQuery, PaginatedList<ErrorTagVM>>
//{
//    private readonly IApplicationDbContext _context;
//    private readonly IMapper _mapper;

//    public GetErrorTagsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
//    {
//        _context = context;
//        _mapper = mapper;
//    }

//    public async Task<PaginatedList<ErrorTagVM>> Handle(GetErrorTagsWithPaginationQuery request, CancellationToken cancellationToken)
//    {
//        return await _context.ErrorTags
//               .OrderBy(x => x.Id)
//               .ProjectTo<ErrorTagVM>(_mapper.ConfigurationProvider)
//               .PaginatedListAsync(request.PageNumber, request.PageSize);
//    }
//}
