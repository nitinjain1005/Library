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
    public class MagazineRepositoryTest
    {
        private Mock<IReader> _mockIReader;
        private MagazineRepository _magazineRepository;
        private Mock<IDataRepository<Author>> _mockAuthorIDataRepository;
        private Mock<IDataRepository<Magazine>> _mockMagazineIDataRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockIReader = new Mock<IReader>();
            _mockAuthorIDataRepository = new Mock<IDataRepository<Author>>();
            _mockMagazineIDataRepository = new Mock<IDataRepository<Magazine>>();
            _magazineRepository = new MagazineRepository(_mockIReader.Object, _mockAuthorIDataRepository.Object);
        }
        [TestMethod]
        public void Test_GetAllMagazineZero()
        {
            Assert.AreEqual(_magazineRepository.GetAll().Count, 0);
        }

        [TestMethod]
        public void Test_GetAllBookMock()
        {
            var testBookData = new List<string[]>
            {
                new List<string>() { "Magazine1", "524-845-869", "Nitin.Jain@Scania.com", "Times news" }.ToArray(),
                new List<string>() { "Magazine12", "458-852-869", "Monika.Jain@Scania.com", "India Today" }.ToArray()
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
            Assert.AreEqual(_magazineRepository.GetAll().Count, 2);
            Assert.AreEqual(_magazineRepository.GetAll().Select(x => x.Authors).Count(), 2);
        }

    }
}
