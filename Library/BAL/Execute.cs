using Library.DAL;
using Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.BAL
{
    public class Execute<T> : IExecute<T> where T : IBase
    {
        private readonly IDataRepository<T> _iDataRepository;
        public Execute(IDataRepository<T> iDataRepository)
        {
            _iDataRepository = iDataRepository;
        }

        public List<T> GetAll()
        { 
            return _iDataRepository.GetAll(); ;
        }
        /// <summary>
        /// Find Data by Author properties as EmailId,FName,LName
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <returns>
        /// List of Data 
        /// </returns>
        public List<T> SearchByAuthor(SearchParameter searchParameter)
        {
            return GetAll().Where(x =>
            ((ICommonBase)x).Authors.Any(y => string.Equals(y.FirstName.ToLower(), searchParameter.Author.ToLower())
                    || string.Equals(y.LastName.ToLower(), searchParameter.Author.ToLower())
                    || string.Equals(y.EmailAddress.ToLower(), searchParameter.Author.ToLower())))
                    .ToList();
        }
        /// <summary>
        ///  Find Data by ISBN number
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <returns>
        /// List of Data 
        /// </returns>
        public List<T> SearchByISBN(SearchParameter searchParameter)
        {
            return GetAll().Where(x => string.Equals(((ICommonBase)x).ISBN.ToLower(), searchParameter.ISBN.ToLower())).ToList();
           
        }
        /// <summary>
        /// sort T(Object) by Title
        /// </summary>
        /// <returns>
        /// sorted Data
        /// </returns>
        public List<T> SortByTitle()
        {
            return GetAll().OrderBy(x => ((ICommonBase)x).Title).ToList();
         }
    }
}
