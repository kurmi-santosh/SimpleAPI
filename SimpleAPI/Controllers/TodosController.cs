using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Config;
using SimpleAPI.DTO;
using SimpleAPI.Entities;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{

    [ApiController]
    [Route(APIRoutes.Base)]
    public class TodosController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodosController(IMapper mapper, ITodoService todoService)
        {
            _mapper = mapper;
            _todoService = todoService;
        }

        [HttpGet]
        [Route(APIRoutes.Todos.GetAllTodos)]
        public IActionResult GetTodos()
        {
            var todoItems = _todoService.GetTodos();
            return Ok(_mapper.Map<List<Todo>>(todoItems));
        }

        [HttpGet]
        [Route(APIRoutes.Todos.GetTodoById)]
        public IActionResult GetTodoById(Guid todoId)
        {
            var todoItem = _todoService.GetTodoById(todoId);
            return Ok(_mapper.Map<Todo>(todoItem));
        }

        [HttpPost]
        [Route(APIRoutes.Todos.CreateNewTodo)]
        public IActionResult CreateNewTodo(TodoRequest request)
        {
            var todoEntity = new TodoEntity(Guid.NewGuid(), request.Title, request.Description, request.IsCompleted);
            var response = _todoService.CreateNewTodo(todoEntity);
            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUrl = baseUrl + "/" + APIRoutes.Todos.GetTodoById.Replace("{todoId}", response.Id.ToString());
                return Created(locationUrl, response);
            }

        }

        [HttpPut]
        [Route(APIRoutes.Todos.UpdateTodo)]
        public IActionResult UpdateTodo([FromBody] TodoRequest request, Guid todoId)
        {
            var todoEntity = new TodoEntity(todoId, request.Title, request.Description, request.IsCompleted);
            bool response = _todoService.UpdateTodo(todoEntity);
            if (response)
            {
                return Ok(_mapper.Map<Todo>(todoEntity));
            }
            else return NotFound();
        }

        [HttpDelete]
        [Route(APIRoutes.Todos.DeleteTodo)]
        public IActionResult DeleteTodo(Guid todoId)
        {
            var response = _todoService.DeleteTodo(todoId);
            if (response) return Ok();
            else return NotFound();
        }

    }
}	

