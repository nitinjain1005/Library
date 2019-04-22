using Library.Model;
using System.Collections.Generic;

namespace Library.DAL
{
    public  interface IDataRepository<T> where T : IBase
    {
        List<T> GetAll();
    }
}
