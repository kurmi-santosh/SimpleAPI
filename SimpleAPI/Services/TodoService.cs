using System;
using SimpleAPI.Entities;

namespace SimpleAPI.Services
{
    public class TodoService : ITodoService
    {
        private List<TodoEntity> _todoItems;

        public TodoService()
        {
            _todoItems = new List<TodoEntity>();
        }

        public List<TodoEntity> GetTodos()
        {
            return _todoItems;
        }

        public TodoEntity? GetTodoById(Guid id)
        {
            var item = _todoItems.Find(item => item.Id.ToString() == id.ToString());
            return item;
        }

        public TodoEntity? CreateNewTodo(TodoEntity todoItem)
        {
            _todoItems.Add(todoItem);
            return todoItem;
        }

        public bool UpdateTodo(TodoEntity todoItem)
        {
            var requiredIndex = _todoItems.FindIndex(item => item.Id.ToString() == todoItem.Id.ToString());
            if (requiredIndex >= 0)
            {
                _todoItems[requiredIndex] = todoItem;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTodo(Guid id)
        {
            var requiredIndex = _todoItems.FindIndex(item => item.Id.ToString() == id.ToString());
            if (requiredIndex >= 0)
            {
                _todoItems.RemoveAt(requiredIndex);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

