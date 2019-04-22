using Library.Model;
using System.Collections.Generic;

namespace Library.BAL
{
    interface IExecute<T>
        where T : IBase
    {
        List<T> GetAll();

        List<T> SearchByISBN(SearchParameter searchParameter);

        List<T> SearchByAuthor(SearchParameter searchParameter);

        List<T> SortByTitle();
    }
}
