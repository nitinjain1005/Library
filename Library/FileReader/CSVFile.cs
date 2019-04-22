using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.FileReader
{
    public class CSVFile: IReader
    {
        /// <summary>
        /// Read Data file 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        ///  earch Enumerable of  data entity in string[]
        /// </returns>
        public IEnumerable<string[]> Read(string path)
        {
           return File.ReadAllLines(path).Select(a => a.Split(';')).Select(x => x).Skip(1);
        }
    }
}
