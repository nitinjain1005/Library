using Library.DAL;
using Library.DAL.Repositories;
using Library.FileReader;
using Library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace LibraryTest.DALRepositoryTest
{
    [TestClass]
    public class AuthorRepositoryTest
    {
        private AuthorRepository _authorRepository;
        private Mock<IReader> _mockIReader;
        private Mock<IDataRepository<Author>> _mockAuthorIDataRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockIReader = new Mock<IReader>();
            _mockAuthorIDataRepository = new Mock<IDataRepository<Author>>();
            _authorRepository = new AuthorRepository(_mockIReader.Object);
        }
        [TestMethod]
        public void Test_GetAllAuthorZero()
        {
            Assert.AreEqual(_authorRepository.GetAll().Count , 0);   
        }
        [TestMethod]
        public void Test_GetAllAuthorMock()
        {
            var testAuthorDate = new List<string[]>
            {
                new List<string>() { "nitin.jain@Scania.com", "Nitin", "Jain" }.ToArray(),
                new List<string>() { "Monika.jain@Infi.com", "Monika", "Jain" }.ToArray()
            };
            _mockIReader.Setup(x => x.Read(It.IsAny<string>())).Returns(testAuthorDate);
            Assert.AreEqual(_authorRepository.GetAll().Count, 2);
           
        }

    }
}
