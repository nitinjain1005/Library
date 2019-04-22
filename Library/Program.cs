using Library.BAL;
using Library.DAL;
using Library.DAL.Repositories;
using Library.FileReader;
using Library.Model;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            try
            {
                RegisterServices();
                var book = _serviceProvider.GetService<IExecute<Book>>();
                var magazine = _serviceProvider.GetService<IExecute<Magazine>>();
                Console.WriteLine("Enter your number according below: \n" +
                                   "1: •	Print out all details of all books and magazines\n" +
                                   "2: •	Find and print out the details of a book or magazine by searching with an ISBN \n" +
                                   "3: •	Find and print out the details of a book or magazine for an author \n" +
                                   "4: •	Sort all books and magazine by title and print out the result \n"
                                   );
                
                switch (Console.ReadLine().ToString())
                {
                    case "1":
                        Print.PrintOut(book.GetAll(), magazine.GetAll());
                        break;
                    case "2":
                        Console.WriteLine("Search by ISBN number     \n");
                        SearchParameter inPutISBN = new SearchParameter()
                        {
                            ISBN = Console.ReadLine().ToString()
                        };
                        Print.PrintOut(book.SearchByISBN(inPutISBN), magazine.SearchByISBN(inPutISBN));
                        break;
                    case "3":
                        Console.WriteLine("Search Author by first name /last name /email address \n");
                        SearchParameter inPutAuthor = new SearchParameter()
                        {
                            Author = Console.ReadLine().ToString()
                        };
                        Print.PrintOut(book.SearchByAuthor(inPutAuthor), magazine.SearchByAuthor(inPutAuthor));
                        break;
                    case "4":
                        Console.WriteLine("Sort by Title     \n");
                        Print.PrintOut(book.SortByTitle(), magazine.SortByTitle());
                        break;
                    default:
                        Console.WriteLine("Enter valid number---------------------------------\n");
                      break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }           
           finally
            {
                DisposeServices();
            }
            Console.ReadLine();
        }
        /// <summary>
        ///  Register all dependicies 
        /// </summary>
        private static void RegisterServices()
        {
            ServiceCollection collection = new ServiceCollection();
            collection.AddSingleton(typeof(IExecute<>), typeof(Execute<>));
            collection.AddSingleton(typeof(IReader), typeof(CSVFile));
            collection.AddSingleton(typeof(IDataRepository<Book>), typeof(BookRepository));
            collection.AddSingleton(typeof(IDataRepository<Author>), typeof(AuthorRepository));
            collection.AddSingleton(typeof(IDataRepository<Magazine>), typeof(MagazineRepository));
            _serviceProvider = collection.BuildServiceProvider();
        }
        /// <summary>
        /// Dispose Object
        /// </summary>
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
                return;
            if (_serviceProvider is IDisposable)
                ((IDisposable)_serviceProvider).Dispose();
        }
    }
}
