using System;
namespace SimpleAPI.DTO
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }

    public class TodoRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}

