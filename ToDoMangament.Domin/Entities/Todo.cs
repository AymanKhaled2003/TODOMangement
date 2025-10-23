using ToDoMangament.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Domain.Entities
{
    public class Todo : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        [Required]
        public TodoPriority Priority { get; set; } = TodoPriority.Medium;

        public DateTime? DueDate { get; set; }




        public void CreateTodo(string title, string? description, TodoPriority priority, DateTime? dueDate)
        {
            Title = title;
            Description = description;
            Status = TodoStatus.Pending;
            Priority = priority;
            DueDate = dueDate;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateTodo(string? title, string? description, TodoStatus? status, TodoPriority? priority, DateTime? dueDate)
        {
            if (!string.IsNullOrWhiteSpace(title))
                Title = title;

            if (description != null)
                Description = description;

            if (status.HasValue)
                Status = status.Value;

            if (priority.HasValue)
                Priority = priority.Value;

            if (dueDate.HasValue)
                DueDate = dueDate;

            LastModifiedDate = DateTime.UtcNow;
        }
        public void ToggleStatus()
        {
            Status = Status switch
            {
                TodoStatus.Pending => TodoStatus.InProgress,
                TodoStatus.InProgress => TodoStatus.Completed,
                TodoStatus.Completed => TodoStatus.Pending,
                _ => TodoStatus.Pending
            };

            LastModifiedDate = DateTime.UtcNow;
        }


    }
}
