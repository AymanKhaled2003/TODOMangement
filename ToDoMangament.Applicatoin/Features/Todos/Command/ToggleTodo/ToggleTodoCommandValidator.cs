using ToDoMangament.Domain.Entities;
using ToDoMangament.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application.Features.Todos.Command.ToggleTodo
{
    public class ToggleTodoCommandValidator : AbstractValidator<ToggleTodoCommand>
    {
        private readonly IGenericRepository<Todo> _todoRepo;

        public ToggleTodoCommandValidator(IGenericRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Is Required")
                .MustAsync(IsExist).WithMessage("Todo item not found.");

        }
        private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
        {
            var todo = await _todoRepo.GetByIdAsync(id);
            return todo != null;
        }
    }
}
