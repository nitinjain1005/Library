using System.Collections.Generic;

namespace Library.Model
{
    public interface ICommonBase
    {
        string Title { get; set; }
         List<Author> Authors { get; set; }
         string ISBN { get; set; }
    }
}
