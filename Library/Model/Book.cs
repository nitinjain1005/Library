using System.Collections.Generic;

namespace Library.Model
{
    public class Book : ICommonBase, IBase
    {
        public string Summary;

        public string Title { get ; set ; }
        public List<Author> Authors { get ; set ; }
        public string ISBN { get ; set; }
    }
}
