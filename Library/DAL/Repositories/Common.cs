using System.IO;
using System.Text.RegularExpressions;

namespace Library.DAL.Repositories
{
    public class Common
    {        
        /// <summary>
        ///  Find application root directory path and remove netcore2.2 additional folder path
        /// </summary>
        /// <returns>
        /// Return appropiate folder path in application root directory
        /// </returns>
        public static string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                              .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot + @"\Data\CSV\" ;
        }
    }
}
