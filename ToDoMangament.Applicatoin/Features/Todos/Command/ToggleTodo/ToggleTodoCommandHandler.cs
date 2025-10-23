using Common.Application.Abstractions.Messaging;
using ToDoMangament.Domain.Entities;
using ToDoMangament.Domain.Interfaces;
using ToDoMangament.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application.Features.Todos.Command.ToggleTodo
{
    public class ToggleTodoCommandHandler : ICommandHandler<ToggleTodoCommand>
    {
        private readonly IGenericRepository<Todo> _todoRepo;

        public ToggleTodoCommandHandler(IGenericRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }
        public async Task<ResponseModel> Handle(ToggleTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepo.GetByIdAsync(request.Id);
            todo.ToggleStatus();
            _todoRepo.Update(todo);
            await _todoRepo.SaveChangesAsync(cancellationToken);
            return ResponseModel.Success("Todo status toggled successfully");

        }
    }
}
