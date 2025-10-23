using Common.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application.Features.Todos.Command.ToggleTodo
{
    public class ToggleTodoCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
