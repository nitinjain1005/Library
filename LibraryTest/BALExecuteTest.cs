using Library.BAL;
using Library.DAL;
using Library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTest
{
    [TestClass]
    public class BALExecuteTest
    {
        private Execute<Book> _bookExecute;
        private Mock<IDataRepository<Book>> _mockBookIDataRepository;
        private Execute<Magazine> _magazineExecute;
        private Mock<IDataRepository<Magazine>> _mockMagazineIDataRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockBookIDataRepository = new Mock<IDataRepository<Book>>();
            _bookExecute = new Execute<Book>(_mockBookIDataRepository.Object);
            _mockMagazineIDataRepository = new Mock<IDataRepository<Magazine>>();
            _magazineExecute = new Execute<Magazine>(_mockMagazineIDataRepository.Object);

        }

        #region  Book       
        [TestMethod]
        public void TestSearchByISBNBooksResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                ISBN = "2215-0012-5487"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());
            Assert.AreEqual(_bookExecute.SearchByISBN(searchParameter).Count, 1);
        }

        [TestMethod]
        public void TestSearchByISBNBooksNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                ISBN = "2215-0012-54871"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());
            var books = _bookExecute.SearchByISBN(searchParameter);
            Assert.AreEqual(books.Count, 0);
        }

        [TestMethod]
        public void TestSearchByAutherEmailIdBooksResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika.jain@scania.com"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());           
            Assert.AreEqual(_bookExecute.SearchByAuthor(searchParameter).Count, 1);
        }

        [TestMethod]
        public void TestSearchByAutherEmailIdBooksNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika.jain@infi.com"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());           
            Assert.AreEqual(_bookExecute.SearchByAuthor(searchParameter).Count,0);
        }

        [TestMethod]
        public void TestSearchByAutherFNameBooksNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika1"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());
            Assert.AreEqual(_bookExecute.SearchByAuthor(searchParameter).Count, 0);
        }

        [TestMethod]
        public void TestSearchByAutherFNameBooksResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());
            Assert.AreEqual(_bookExecute.SearchByAuthor(searchParameter).Count, 1);
        }

        [TestMethod]
        public void TestSearchByAutherLNameBooksNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Jain1"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());
            Assert.AreEqual(_bookExecute.SearchByAuthor(searchParameter).Count, 0);
        }

        [TestMethod]
        public void TestSearchByAutherLNameBooksResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Jain"
            };
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetBooksData());
            Assert.AreEqual(_bookExecute.SearchByAuthor(searchParameter).Count, 2);
        }

        [TestMethod]
        public void TestSortBookByTitleResultFound()
        {
            List<Book> testBookData = new List<Book>()
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
            _mockBookIDataRepository.Setup(x => x.GetAll()).Returns(testBookData);
            Assert.IsTrue(testBookData.OrderBy(x => x.Title).ToList().SequenceEqual(_bookExecute.SortByTitle()));
            
        }
        #endregion Book
        
        #region  Magazine       
        [TestMethod]
        public void TestSearchByISBNMagazineResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                ISBN = "2215-0012-5487"
            };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());            
            Assert.AreEqual(_magazineExecute.SearchByISBN(searchParameter).Count, 1);
        }

        [TestMethod]
        public void TestSearchByISBNMagazineNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                ISBN = "2215-0012-54871"
            };           
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());
            Assert.AreEqual(_magazineExecute.SearchByISBN(searchParameter).Count, 0);
        }

        [TestMethod]
        public void TestSearchByAutherEmailIdMagazineResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika.jain@scania.com"
            };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());           
            Assert.AreEqual(_magazineExecute.SearchByAuthor(searchParameter).Count, 1);
        }

        [TestMethod]
        public void TestSearchByAutherEmailIdMagazineNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika.jain@infi.com"
            };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());
            Assert.AreEqual(_magazineExecute.SearchByAuthor(searchParameter).Count, 0);
        }

        [TestMethod]
        public void TestSearchByAutherFNameMagazineNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika1"
            };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());
            Assert.AreEqual(_magazineExecute.SearchByAuthor(searchParameter).Count, 0);
        }

        [TestMethod]
        public void TestSearchByAutherFNameMagazineResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Monika"
            };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());
            Assert.AreEqual(_magazineExecute.SearchByAuthor(searchParameter).Count,1);
        }

        [TestMethod]
        public void TestSearchByAutherLNameMagazineNotFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Jain1"
            };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());
            Assert.AreEqual(_magazineExecute.SearchByAuthor(searchParameter).Count, 0);
           
        }

        [TestMethod]
        public void TestSearchByAutherLNameMagazineResultFound()
        {
            SearchParameter searchParameter = new SearchParameter()
            {
                Author = "Jain"
            };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(TestData.GetMagazineData());
            Assert.AreEqual(_magazineExecute.SearchByAuthor(searchParameter).Count, 2);
        }

        [TestMethod]
        public void TestSortMagazineByTitleResultFound()
        {
            List<Magazine> testMagazineData = new List<Magazine>()
             {
                 new Magazine()
                 {
                     Title ="Fobs",
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
                     Title ="India Today",
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
                     Title ="Fashion  Week",
                    ISBN="2215-0012-5487",
                    ReleasedDate="14-01-2019",
                    Authors=  new List<Author>()
                    {
                         new Author()
                         {
                             FirstName ="Monika",
                             LastName ="Jain",
                             EmailAddress ="Monika.Jain@Scania.com"
                         }
                    }
                 }
             };
            _mockMagazineIDataRepository.Setup(x => x.GetAll()).Returns(testMagazineData);
            Assert.IsTrue(testMagazineData.OrderBy(x => x.Title).ToList().SequenceEqual(_magazineExecute.SortByTitle()));
        }
        #endregion Magazine

    }
}
