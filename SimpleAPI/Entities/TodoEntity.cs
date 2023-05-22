using System;
namespace SimpleAPI.Entities
{
    public class TodoEntity
    {
        public TodoEntity() { }

        public TodoEntity(Guid id, string title, string description, bool isDone)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isDone;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}

