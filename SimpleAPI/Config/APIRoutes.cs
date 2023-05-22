using System;
namespace SimpleAPI.Config
{
    public static class APIRoutes
    {

        public const string Base = "api";

        public static class Todos
        {
            public const string GetAllTodos = Base + "/todos";

            public const string GetTodoById = Base + "/todos/{todoId}";

            public const string CreateNewTodo = Base + "/todos/CreateNewTodo";

            public const string UpdateTodo = Base + "/todos/{todoId}";

            public const string DeleteTodo = Base + "/todos/{todoId}";

        }
    }
}

