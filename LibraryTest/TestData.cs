using Library.Model;
using System.Collections.Generic;

namespace LibraryTest
{
    public class TestData
    {
        public static List<Book> GetBooksData()
        {
            return new List<Book>()
             {
                
                 new Book()
                 {
                     Title ="Darwin Theory",
                    ISBN="2215-0012-5487",
                    Summary="Science",
                    Authors=  new List<Author>()
                    {
                         new Author()
                         {
                             FirstName ="Nitin",
                             LastName ="Jain",
                             EmailAddress ="Nitin.Jain@Scania.com"
                         }
                    }
                 },
                 new Book()
                 {
                     Title ="Quantom Physics",
                    ISBN="2215-0012-54817",
                    Summary="Physics",
                    Authors=  new List<Author>()
                    {
                         new Author()
                         {
                             FirstName ="Robert",
                             LastName ="Yunus",
                             EmailAddress ="Robert.Yunus@Scania.com"
                         }
                    }
                 },
                 new Book()
                 {
                     Title ="Champak",
                    ISBN="2221-5548-8585",
                    Authors=  new List<Author>()
                    {
                         new Author()
                         {
                             FirstName ="Monika",
                             LastName ="Jain",
                             EmailAddress ="Monika.Jain@Scania.com"
                         }
                    },
                    Summary="kids Stories"
                 }
             };
        }
        public static List<Magazine> GetMagazineData()
        {
            return new List<Magazine>()
             {
                 new Magazine()
                 {
                     Title ="Forbs",
                    ISBN="2221-5548-8585",
                    Authors=  new List<Author>()
                    {
                         new Author()
                         {
                             FirstName ="Nitin",
                             LastName ="Jain",
                             EmailAddress ="Nitin.Jain@Scania.com"
                         }
                    },
                    ReleasedDate="31-01-2019"
                 },
                  new Magazine()
                 {
                     Title ="Zee Media",
                    ISBN="2215-0012-5487",
                    ReleasedDate="13-01-2019",
                    Authors=  new List<Author>()
                    {
                         new Author()
                         {
                             FirstName ="Monika",
                             LastName ="Jain",
                             EmailAddress ="Monika.Jain@Scania.com"
                         }
                    }
                 },
                 new Magazine()
                 {
                     Title ="Times",
                    ISBN="2215-0012-54187",
                    ReleasedDate="13-01-2019",
                    Authors=  new List<Author>()
                    {
                         new Author()
                         {
                             FirstName ="Sohan",
                             LastName ="Kharbanda",
                             EmailAddress ="Sohan.Kharbanda@Scania.com"
                         }
                    }
                 }
             };
        }
    }
}
