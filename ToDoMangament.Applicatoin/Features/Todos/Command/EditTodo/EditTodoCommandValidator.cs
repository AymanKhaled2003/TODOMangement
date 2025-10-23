using ToDoMangament.Domain.Entities;
using ToDoMangament.Domain.Interfaces;
using FluentValidation;
using System;

namespace ToDoMangament.Application
{
    public class EditTodoCommandValidator : AbstractValidator<EditTodoCommand>
    {
        private readonly IGenericRepository<Todo> _todoRepo;

        public EditTodoCommandValidator(IGenericRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id Is Required")
                .MustAsync(IsExist).WithMessage("Todo item not found.");

            RuleFor(x => x.Title)
                .MaximumLength(100).WithMessage("العنوان لا يمكن أن يتجاوز 100 حرف.");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("قيمة الحالة غير صحيحة.");

            RuleFor(x => x.Priority)
                .IsInEnum()
                .WithMessage("قيمة الأولوية غير صحيحة.");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.DueDate.HasValue)
                .WithMessage("تاريخ الاستحقاق يجب أن يكون في المستقبل.");
        }
        private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
        {
            var todo = await _todoRepo.GetByIdAsync(id);
            return todo != null;
        }
    }
}
