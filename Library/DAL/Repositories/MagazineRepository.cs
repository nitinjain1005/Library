using Library.Constant;
using Library.FileReader;
using Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Repositories
{
    public class MagazineRepository : IDataRepository<Magazine>
    {
        private readonly IReader _iReader;
        private readonly IDataRepository<Author> _IAuthorDataRepository;
        private readonly string path = Common.GetApplicationRoot()+CSVConstant.MAGAZINE_CSV;
      

        public MagazineRepository(IReader iReader, IDataRepository<Author> IAuthorDataRepository)
        {
            _iReader = iReader;
            _IAuthorDataRepository = IAuthorDataRepository;
        }
        /// <summary>
        ///  Read magazine data file
        /// </summary>
        /// <returns>  
        /// return magazine list
        /// </returns>
        public List<Magazine> GetAll()
        {
            var authorsData = _IAuthorDataRepository.GetAll();
            return _iReader.Read(path).Select(x=> new Magazine()
            {
                Title = x[0],
                ISBN = x[1],
                Authors = x[2].Split(',').ToList().Select(y => authorsData.FirstOrDefault(a => a.EmailAddress.Equals(y))).ToList() ?? new List<Author>(),
                ReleasedDate = x[3]
            }).ToList();
        }
    }
}
