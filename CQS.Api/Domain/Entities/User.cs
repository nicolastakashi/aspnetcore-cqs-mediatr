using System;
using CQS.Api.Commands;

namespace CQS.Api.Entities
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public bool IsActive { get; protected set; }

        protected User()
        {
        }

        public User(string name, DateTime birthday)
        {
            Id = Guid.NewGuid();
            Name = name;
            Birthday = birthday;
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public static User Create(CreateUserCommand command)
            => new User(command.Name, command.Birthday);
    }
}
