using ToDoMangament.Application;
using ToDoMangament.Application.Features.Todos.Command.AddTodo;
using ToDoMangament.Application.Features.Todos.Command.ToggleTodo;
using ToDoMangament.Application.Features.Todos.Queries.GetTodo;
using ToDoMangament.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Presentation.Controllers
{
    [Route("api/TodoManagement/[controller]")]
    public sealed class TodoController : ApiController
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddTodo")]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpPut("EditTodo")]
        public async Task<IActionResult> EditTodo([FromBody] EditTodoCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResult(result);
        }

        [HttpGet("GetTodo")]
        public async Task<IActionResult> GetTodo([FromQuery] GetTodoQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }
        [HttpGet("GetTodoById")]
        public async Task<IActionResult> GetTodoById([FromQuery] GetTodoByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return HandleResult(result);
        }

        [HttpPut("ToggleTodo")]
        public async Task<IActionResult> ToggleTodo(ToggleTodoCommand toggle)
        {
            var result = await _mediator.Send(toggle);
            return HandleResult(result);
        }
    }
}
