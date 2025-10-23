using Common.Application.Abstractions.Messaging;
using ToDoMangament.Application.ShareDto.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application.Features.Todos.Queries.GetTodo
{
    public class GetTodoQuery : IQuery<List<TodoDto>>
    {
    }
}
