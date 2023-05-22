using System;
using AutoMapper;
using SimpleAPI.DTO;
using SimpleAPI.Entities;

namespace SimpleAPI.Config
{
	public class TodosProfile : Profile
	{
		public TodosProfile()
		{
			CreateMap<Todo, TodoEntity>();
			CreateMap<TodoEntity, Todo>();
		}
	}
}

