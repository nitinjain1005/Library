using Library.Constant;
using Library.FileReader;
using Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Repositories
{
    public class BookRepository : IDataRepository<Book>
    {
        private readonly IReader _iReader;
        private readonly IDataRepository<Author> _IAuthorDataRepository;
        private readonly string path = Common.GetApplicationRoot() + CSVConstant.BOOK_CSV;

        public BookRepository(IReader iReader, IDataRepository<Author> IAuthorDataRepository)
        {

            _iReader = iReader;
            _IAuthorDataRepository = IAuthorDataRepository;
        }
        /// <summary>
        ///  Read book data file
        /// </summary>
        /// <returns>  
        /// return book list
        /// </returns>
        public List<Book> GetAll()
        {
            var authorData = _IAuthorDataRepository.GetAll();        
                return _iReader.Read(path).Select(x => new Book()
                {
                    Title = x[0],
                    ISBN = x[1],
                    Authors = x[2].Split(',').ToList().Select(y => authorData.FirstOrDefault(a => a.EmailAddress.Equals(y))).ToList() ?? new List<Author>(),
                    Summary = x[3],
                }).ToList();            
            

        }

    }
}
