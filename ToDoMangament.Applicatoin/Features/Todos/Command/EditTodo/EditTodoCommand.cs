using Common.Application.Abstractions.Messaging;
using ToDoMangament.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application
{
    public class EditTodoCommand : ICommand
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }
        public TodoStatus Status { get; set; }


        public TodoPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
