using System.Collections.Generic;

namespace Library.Model
{
    public class Magazine: ICommonBase, IBase
    {
        public string ReleasedDate;
        public string Title { get ; set ; }
        public List<Author> Authors { get ; set ; }
        public string ISBN { get ; set ; }
    }
}
