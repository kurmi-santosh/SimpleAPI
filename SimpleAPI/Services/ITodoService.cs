using System;
using SimpleAPI.Entities;

namespace SimpleAPI.Services
{
    public interface ITodoService
    {
        List<TodoEntity> GetTodos();

        TodoEntity? GetTodoById(Guid id);

        TodoEntity? CreateNewTodo(TodoEntity todoItem);

        bool UpdateTodo(TodoEntity todoItem);

        bool DeleteTodo(Guid id);
    }
}

