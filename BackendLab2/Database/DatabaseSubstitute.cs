using BackendLab2.Models;

namespace BackendLab2.Database
{
    public class DatabaseSubstitute
    {
        public static List<User> Users { get; } =
        [
            new User { Id = 1, Name = "Alice" },
            new User { Id = 2, Name = "Bob" },
            new User { Id = 3, Name = "Charlie" }
        ];

        public static List<Category> Categories { get; } =
        [
            new Category { Id = 1, Name = "Food" },
            new Category { Id = 2, Name = "Transport" },
            new Category { Id = 3, Name = "Entertainment" }
        ];

        public static List<Record> Records { get; } =
        [
            new Record
            {
                Id = 1,
                UserId = Users[0].Id,
                User = Users[0],
                CategoryId = Categories[0].Id,
                Category = Categories[0],
                CreatedAt = new DateTime(2025, 1, 10),
                Expenses = 12.50m
            },

            new Record
            {
                Id = 2,
                UserId = Users[1].Id,
                User = Users[1],
                CategoryId = Categories[1].Id,
                Category = Categories[1],
                CreatedAt = new DateTime(2025, 2, 5),
                Expenses = 45.00m
            },

            new Record
            {
                Id = 3,
                UserId = Users[2].Id,
                User = Users[2],
                CategoryId = Categories[2].Id,
                Category = Categories[2],
                CreatedAt = new DateTime(2025, 3, 20),
                Expenses = 99.99m
            },
            
            new Record
            {
                Id = 4,
                UserId = Users[0].Id,
                User = Users[0],
                CategoryId = Categories[1].Id,
                Category = Categories[1],
                CreatedAt = new DateTime(2025, 10, 15),
                Expenses = 199.99m
            }
        ];
    }
}