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
    public class GetTodoByIdQueryHandler : IQueryHandler<GetTodoByIdQuery, TodoDto>
    {
        private readonly IGenericRepository<Todo> _todoRepo;
        private readonly IMapper _mapper;

        public GetTodoByIdQueryHandler(IGenericRepository<Todo> todoRepo, IMapper mapper)
        {
            _todoRepo = todoRepo;
            _mapper = mapper;
        }
        public async Task<ResponseModel<TodoDto>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoRepo.GetByIdAsync(request.Id);
            var mappedTodos = _mapper.Map<TodoDto>(todos);
            return ResponseModel<TodoDto>.Success(mappedTodos);
        }
    }
}
