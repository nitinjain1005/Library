using System.Collections.Generic;

namespace Library.FileReader
{
    public interface IReader
    {
        IEnumerable<string[]> Read(string path);
    }
}
