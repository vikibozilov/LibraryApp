using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryConsoleApp
{
    class Program
    {
        // Тук създаваме списъка с книги
        static List<Book> library = new List<Book>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                // Менюто:
                Console.WriteLine("\n=== Библиотека ===");
                Console.WriteLine("1. Добави книга");
                Console.WriteLine("2. Покажи всички книги");
                Console.WriteLine("3. Редактирай книга");
                Console.WriteLine("4. Изтрий книга");
                Console.WriteLine("5. Търси книга");
                Console.WriteLine("0. Изход");
                Console.Write("Избери опция: ");

                string choice = Console.ReadLine();

                // Проверяваме избора
                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ShowAllBooks();
                        break;
                    case "3":
                        EditBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
                    case "5":
                        SearchBooks();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невалиден избор! Опитай пак.");
                        break;
                }
            }
        }

        // Метод за добавяне на книга
        static void AddBook()
        {
            Console.Write("Заглавие: ");
            string title = Console.ReadLine();
            Console.Write("Автор: ");
            string author = Console.ReadLine();
            Console.Write("Жанр: ");
            string genre = Console.ReadLine();
            Console.Write("Година: ");
            string year = Console.ReadLine();

            library.Add(new Book { Title = title, Author = author, Genre = genre, Year = year });
            Console.WriteLine("Книгата е добавена успешно.");
        }

        // Метод за показване на всички книги
        static void ShowAllBooks()
        {
            if (library.Count == 0)
            {
                Console.WriteLine("Няма книги в библиотеката.");
                return;
            }

            Console.WriteLine("\n--- Списък с книги ---");
            for (int i = 0; i < library.Count; i++)
            {
                var book = library[i];
                Console.WriteLine($"{i + 1}. {book}");
            }
        }

        // Метод за редакция
        static void EditBook()
        {
            ShowAllBooks();
            Console.Write("Въведи номер на книгата за редакция: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= library.Count)
            {
                var book = library[index - 1];
                Console.Write($"Ново заглавие ({book.Title}): ");
                string title = Console.ReadLine();
                if (!string.IsNullOrEmpty(title)) book.Title = title;

                Console.Write($"Нов автор ({book.Author}): ");
                string author = Console.ReadLine();
                if (!string.IsNullOrEmpty(author)) book.Author = author;

                Console.Write($"Нов жанр ({book.Genre}): ");
                string genre = Console.ReadLine();
                if (!string.IsNullOrEmpty(genre)) book.Genre = genre;

                Console.Write($"Нова година ({book.Year}): ");
                string year = Console.ReadLine();
                if (!string.IsNullOrEmpty(year)) book.Year = year;

                Console.WriteLine("Книгата е редактирана.");
            }
            else
            {
                Console.WriteLine("Невалиден номер.");
            }
        }

        // Метод за изтриване
        static void DeleteBook()
        {
            ShowAllBooks();
            Console.Write("Въведи номер на книгата за изтриване: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= library.Count)
            {
                library.RemoveAt(index - 1);
                Console.WriteLine("Книгата е изтрита.");
            }
            else
            {
                Console.WriteLine("Невалиден номер.");
            }
        }

        // Метод за търсене
        static void SearchBooks()
        {
            Console.Write("Въведи ключова дума за търсене (заглавие/автор/жанр): ");
            string keyword = Console.ReadLine().ToLower();

            var results = library.Where(b => b.Title.ToLower().Contains(keyword)
                                           || b.Author.ToLower().Contains(keyword)
                                           || b.Genre.ToLower().Contains(keyword)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("Няма намерени резултати.");
            }
            else
            {
                Console.WriteLine("\n--- Резултати от търсене ---");
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}
