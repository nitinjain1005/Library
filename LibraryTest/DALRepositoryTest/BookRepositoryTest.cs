using Library.DAL;
using Library.DAL.Repositories;
using Library.FileReader;
using Library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTest.DALRepositoryTest
{
    [TestClass]
    public class BookRepositoryTest
    {
        private Mock<IReader> _mockIReader;
        private BookRepository _bookRepository;
        private Mock<IDataRepository<Author>> _mockAuthorIDataRepository;
        private Mock<IDataRepository<Book>> _mockBookIDataRepository;


        [TestInitialize]
        public void Setup()
        {
            _mockIReader = new Mock<IReader>();
            _mockAuthorIDataRepository = new Mock<IDataRepository<Author>>();
            _mockBookIDataRepository = new Mock<IDataRepository<Book>>();
            _bookRepository = new BookRepository(_mockIReader.Object, _mockAuthorIDataRepository.Object);
        }
        [TestMethod]
        public void Test_GetAllBookZero()
        {
            Assert.AreEqual(_bookRepository.GetAll().Count, 0);
        }

        [TestMethod]
        public void Test_GetAllBookMock()
        {
            var testBookData = new List<string[]>
            {
                new List<string>() { "Book1", "524-845-869", "Nitin.Jain@Scania.com", "Times news" }.ToArray(),
                new List<string>() { "Book2", "458-852-869", "Monika.Jain@Scania.com", "India Today" }.ToArray()
            };

            var testAuthors = new List<Author>() {
                new Author()
                {

                    FirstName="Nitin",
                    LastName="Jain",
                    EmailAddress="Nitin.Jain@Scania.com",
                },
                new Author()
                {
                   FirstName="Monika",
                    LastName="Jain",
                    EmailAddress="Monika.Jain@Scania.com",
                }
            };

            _mockAuthorIDataRepository.Setup(data => data.GetAll()).Returns(testAuthors);
            _mockIReader.Setup(x => x.Read(It.IsAny<string>())).Returns(testBookData);
            Assert.AreEqual(_bookRepository.GetAll().Count, 2);
            Assert.AreEqual(_bookRepository.GetAll().Select(x => x.Authors).Count(), 2);
        }

    }
}
