using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Print
    {
        /// <summary>
        /// Print Data
        /// </summary>
        /// <param name="books"></param>
        /// <param name="magazines"></param>
        public static void PrintOut(List<Book> books, List<Magazine> magazines)
        {

            #region Books
            if (books != null && books.Count > 0)
            {
                Console.WriteLine("\n Books Information-:");
                foreach (var book in books)
                {
                    Console.WriteLine(string.Format("Title={0} ISBN-Number={1} Author={2} Summary={3}", book.Title, book.ISBN, string.Join(", ", book.Authors.Select(x => x.DisplayName)), book.Summary));
                }
            }
            else
                Console.WriteLine("\n Not Found-Book");

            Console.WriteLine("----------------------------------------------------------");


            #endregion

            #region Magazines
            if (magazines != null && books.Count > 0)
            {

                Console.WriteLine("\n Magazines Information:");

                foreach (var magazine in magazines)
                {
                    Console.WriteLine(string.Format("Title={0} ISBN={1} Author={2} RDate={3}", magazine.Title, magazine.ISBN, string.Join(", ", magazine.Authors.Select(x => x.DisplayName)), magazine.ReleasedDate));
                }
            }
            else
                Console.WriteLine("\n  Not Found-Magazines");

            #endregion

            Console.WriteLine("----------------------------------------------------------");

        }
    }
}
