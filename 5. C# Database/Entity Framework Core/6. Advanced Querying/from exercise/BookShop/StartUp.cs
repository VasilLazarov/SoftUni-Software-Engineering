namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            // test my functions
            //string? inputString = Console.ReadLine();
            //int inputInt = int.Parse(Console.ReadLine());
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //string? result = GetMostRecentBooks(context);
            //stopwatch.Stop();
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //Console.WriteLine(CountBooks(context, inputInt));
            //Console.WriteLine(result);
            //Console.WriteLine("--------------------------------------");
            //Console.WriteLine($"Result string length: {result.Length}");
            //Console.WriteLine(inputString.Contains("asi", StringComparison.OrdinalIgnoreCase));

            //IncreasePrices(context);

        }

        // Exercise 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //First way
            #region First way
            //bool hasParsed = Enum.TryParse(typeof(AgeRestriction), command, true, out object? restrictionObj);
            //AgeRestriction restriction;
            //if (hasParsed)
            //{
            //    restriction = (AgeRestriction)restrictionObj;

            //    var books = context.Books
            //    .Where(b => b.AgeRestriction == restriction)
            //    .OrderBy(b => b.Title)
            //    .Select(b => b.Title)
            //    .ToList();

            //    return string.Join(Environment.NewLine, books);
            //}

            //return "";
            #endregion


            //Second way
            #region Second way

            try
            {
                AgeRestriction restriction = Enum.Parse<AgeRestriction>(command, true);

                var books = context.Books
                .Where(b => b.AgeRestriction == restriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

                return string.Join(Environment.NewLine, books);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            #endregion

        }


        // Exercise 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold
                            && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }


        // Exercise 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder result = new();
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                })
                .ToList();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - ${b.Price:f2}");
            }
            return result.ToString().TrimEnd();
        }


        // Exercise 5 
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }


        // Exercise 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();
            
            var books = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }


        // Exercise 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder result = new();
            int[] input = date.Split('-').Select(int.Parse).ToArray();
            DateTime inputDate = new(input[2], input[1], input[0]);
            var books = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();
            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return result.ToString().TrimEnd();
        }


        // Exercise 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder result = new();
            //my query
            #region myQuery
            //var authors = context.Authors
            //    //.Where(a => a.FirstName.Substring(a.FirstName.Length - input.Length) == input) // this worked perfect
            //    .Where(a => a.FirstName.EndsWith(input)) // also works perfect and is easier and simple
            //    .Select(a => new
            //    {
            //        AuthorFullName = a.FirstName + " " + a.LastName,
            //    })
            //    .OrderBy(a => a.AuthorFullName)
            //    .Select(a => a.AuthorFullName)
            //    .ToList();
            ////foreach (var a in authors)
            ////{
            ////    result.AppendLine(a.AuthorFullName);
            ////}
            ////return result.ToString().TrimEnd();

            //return string.Join(Environment.NewLine, authors);

            #endregion

            //Kriskata's query
            #region Kriskata's query
            //var authorsNames = context.Authors
            //    .Where(a => a.FirstName.EndsWith(input)) // also works perfect and is easier and simple
            //    .OrderBy(a => a.FirstName)
            //    .ThenBy(a => a.LastName)
            //    .Select(a => a.FirstName + " " + a.LastName)
            //    .ToList();

            //return string.Join(Environment.NewLine, authorsNames);
            #endregion

            //other way
            #region Other way - best way - shortest and optimized for run all in DB
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, authors);

            #endregion
        }


        // Exercise 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Exercise 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder result = new();
            var books = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName,
                })
                .ToList();

            foreach (var b in books)
            {
                result.AppendLine($"{b.BookTitle} ({b.AuthorFullName})");
            }
            return result.ToString().TrimEnd();
        }

        // Exercise 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var numberOfBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList()
                .Count;
            return numberOfBooks;
        }


        // Exercise 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder result = new();
            //my first solution
            #region my first
            //var authorBookCopies = context.Books
            //    .Include(b => b.Author)
            //    .GroupBy(b => new
            //    {
            //        b.AuthorId,
            //        b.Author.FirstName,
            //        b.Author.LastName,
            //    })
            //    .Select(gr => new
            //    {
            //        AuthorFullName = gr.Key.FirstName + " " + gr.Key.LastName,
            //        AllCopies = gr.Sum(b => b.Copies)
            //    })
            //    .OrderByDescending(gr => gr.AllCopies)
            //    .ToList();
            //foreach (var abc in authorBookCopies)
            //{
            //    result.AppendLine($"{abc.AuthorFullName} - {abc.AllCopies}");
            //}
            //return result.ToString().TrimEnd();
            #endregion

            //With Kriskata
            #region solution with Kriskata
            var authorBookCopies = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();
            foreach (var abc in authorBookCopies)
            {
                result.AppendLine($"{abc.FullName} - {abc.TotalCopies}");
            }
            return result.ToString().TrimEnd();
            #endregion

        }


        // Exercise 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder result = new();

            var profitForEveryCategory = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            foreach(var category in profitForEveryCategory)
            {
                result.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }

            return result.ToString().TrimEnd();
        }


        // Exercise 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder result = new();
            var top3RecentBooksForEveryCategory = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Top3Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            BookYear = cb.Book.ReleaseDate.Value.Year,
                        })
                        .Take(3)
                        .ToArray()
                })
                .ToList();

            foreach (var cb in top3RecentBooksForEveryCategory)
            {
                result.AppendLine($"--{cb.CategoryName}");
                foreach (var b in cb.Top3Books)
                {
                    result.AppendLine($"{b.BookTitle} ({b.BookYear})");
                }
            }

            return result.ToString().TrimEnd();
        }


        // Exercise 15
        public static void IncreasePrices(BookShopContext context)
        {
            #region normal
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010)
                .ToList();
            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
            #endregion

            #region with Bulk operations
            //var books = context.Books
            //    .Where(b => b.ReleaseDate.HasValue &&
            //                b.ReleaseDate.Value.Year < 2010)
            //    .ToList();

            //foreach (var book in books)
            //{
            //    book.Price += 5;
            //}
            ////context.BulkUpdate(books);
            #endregion
        }


        // Exercise 16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();
            int numberOfDeletedBooks = books.Count;
            foreach (var book in books)
            {
                context.Books.Remove(book);
            }
            context.SaveChanges();

            return numberOfDeletedBooks;
        }

    }
}


