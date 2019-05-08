namespace E_Library.Migrations
{
    using E_Library.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_Library.Models.E_LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E_Library.Models.E_LibraryContext context)
        {
            context.Books.AddOrUpdate(x => x.BookId,
           new Book() { BookId = 1, BookName = "Jane Austen" },
           new Book() { BookId = 2, BookName = "Charles Dickens" },
           new Book() { BookId = 3, BookName = "Miguel de Cervantes" }
           );

            context.Students.AddOrUpdate(x => x.StudentId,
                new Student()
                {
                    StudentId = 1,
                    StudentName = "Morgan",
                    Email = "Morgan@",
                    ContactNumber = "5427859",
                    Address = "London"
                },
                new Student()
                {
                    StudentId = 2,
                    StudentName = "Tom Riddle",
                    Email = "Tom@",
                    ContactNumber = "9851246",
                    Address = "Paris"
                },
                new Student()
                {
                    StudentId = 4,
                    StudentName = "Richard",
                    Email = "Richard@",
                    ContactNumber = "84321645",
                    Address = "New York"
                },
                new Student()
                {
                    StudentId = 4,
                    StudentName = "Lena",
                    Email = "Lena@",
                    ContactNumber = "7592346",
                    Address = "Chicago"
                }
                );

            context.IssuedBooks.AddOrUpdate(x => x.Id,
                new IssuedBook() {Id = 1, StudentId = 4, BookId = 1 },
                new IssuedBook() { Id = 2, StudentId = 2, BookId = 1 },
                new IssuedBook() { Id = 3, StudentId = 1, BookId = 3 },
                new IssuedBook() { Id = 4, StudentId = 3, BookId = 2 },
                new IssuedBook() { Id = 5, StudentId = 4, BookId = 2 }
                );

        }
    }
}
