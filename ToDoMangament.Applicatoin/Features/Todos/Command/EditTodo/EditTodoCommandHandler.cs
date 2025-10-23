using Common.Application.Abstractions.Messaging;
using ToDoMangament.Domain.Entities;
using ToDoMangament.Domain.Interfaces;
using ToDoMangament.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application
{
    public class EditTodoCommandHandler : ICommandHandler<EditTodoCommand>
    {
        private readonly IGenericRepository<Todo> _todoRepo;

        public EditTodoCommandHandler(IGenericRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }
        public async Task<ResponseModel> Handle(EditTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepo.GetByIdAsync(request.Id);

            todo.UpdateTodo(
                request.Title,
                request.Description,
                request.Status,
                request.Priority,
                request.DueDate
            );
            _todoRepo.Update(todo);
            await _todoRepo.SaveChangesAsync();

            return ResponseModel.Success("Todo updated successfully");
        }

    }
}
