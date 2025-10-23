using Common.Application.Abstractions.Messaging;
using ToDoMangament.Domain.Entities;
using ToDoMangament.Domain.Interfaces;
using ToDoMangament.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application.Features.Todos.Command.AddTodo
{
    public class AddTodoCommandHandler : ICommandHandler<AddTodoCommand>
    {
        private readonly IGenericRepository<Todo> _todoRepo;
        public AddTodoCommandHandler(IGenericRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<ResponseModel> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo();
            todo.CreateTodo(request.Title, request.Description, request.Priority, request.DueDate);
            await _todoRepo.AddAsync(todo);
            var result = await _todoRepo.SaveChangesAsync(cancellationToken);

            if (result)

                return ResponseModel.Success("Todo added successfully.");
            else

                return ResponseModel.Failure("Failed to add Todo. No changes were saved.");

        }
    }
}
