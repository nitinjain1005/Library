using Library.Constant;
using Library.FileReader;
using Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : IDataRepository<Author>
    {
        private readonly IReader _iReader;
        private readonly string path = Common.GetApplicationRoot() +CSVConstant.AUTHOR_CSV; // Need to refector this as well
      

        public AuthorRepository(IReader iReader)
        {
            _iReader = iReader;
        }
        /// <summary>
        ///  Read Author data file
        /// </summary>
        /// <returns>  
        /// return Author list
        /// </returns>
        public List<Author> GetAll()
        {
            return _iReader.Read(path).Select(x=> new Author()
            {
                EmailAddress = x[0],
                FirstName = x[1],
                LastName = x[2]
            }).ToList();
        }
        
        
    }
}
