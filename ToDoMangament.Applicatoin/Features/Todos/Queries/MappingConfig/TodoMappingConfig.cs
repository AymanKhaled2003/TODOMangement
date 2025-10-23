using ToDoMangament.Application.Features.Todos.Queries.GetTodo;
using ToDoMangament.Application.ShareDto.Todos;
using ToDoMangament.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMangament.Application.Features.Todos.Queries.MappingConfig
{
    internal class TodoMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Todo, TodoDto>()
                            .Map(dest => dest.Id, src => src.Id)
                            .Map(dest => dest.Status, src => src.Status)
                            .Map(dest => dest.Title, src => src.Title)
                            .Map(dest => dest.Description, src => src.Description)
                            .Map(dest => dest.DueDate, src => src.DueDate)
                            .Map(dest => dest.CreateAt, src => src.CreatedAt);

        }

    }
}
