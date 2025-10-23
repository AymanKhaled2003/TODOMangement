using Common.Application.Abstractions.Messaging;
using ToDoMangament.Application.ShareDto.Todos;
using ToDoMangament.Domain.Entities;
using ToDoMangament.Domain.Interfaces;
using ToDoMangament.Domain.Shared;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application.Features.Todos.Queries.GetTodo
{
    public class GetTodoQueryHandler : IQueryHandler<GetTodoQuery, List<TodoDto>>
    {
        private readonly IGenericRepository<Todo> _todoRepo;
        private readonly IMapper _mapper;

        public GetTodoQueryHandler(IGenericRepository<Todo> todoRepo, IMapper mapper)
        {
            _todoRepo = todoRepo;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<TodoDto>>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todos = _todoRepo.GetAllAsIQueryable().ToList();
            var mappedTodos = _mapper.Map<List<TodoDto>>(todos);
            return ResponseModel<List<TodoDto>>.Success(mappedTodos);
        }
    }
}
