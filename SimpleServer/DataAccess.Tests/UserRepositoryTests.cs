using Entities;
using Moq;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Entities.Exceptions;

namespace DataAccess.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        // 
        //private DbContext createContext(){
        //    var options = new DbContextOptionsBuilder<SimpleServerContext>().UseInMemoryDatabase(databaseName: "SimpleServerDbTest").Options;
        //    var context = new SimpleServerContext(options);
        //}

        // Mocks DbContext: https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking

        [TestMethod]
        public void TestAddUser()
        {
            // Arrange 
            var user = new User()
            {
                FirstName="test",
                LastName="test",
                Timestamp = DateTime.Now,
            };

            var data = new List<User>
            {
                user
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var simpleServerMock = new Mock<DbContext>();
            simpleServerMock.Setup(x => x.Set<User>()).Returns(mockSet.Object);
            simpleServerMock.Setup(x => x.SaveChanges()).Returns(0);

            var userRepository = new UserRepository(simpleServerMock.Object);

            //Act
            var result = userRepository.AddUser(user);

            // Assert
            simpleServerMock.Verify(simpleServerMock => simpleServerMock.SaveChanges(), Times.Once());
            Assert.AreEqual(user.FirstName, result.FirstName);
        }

        [TestMethod]
        public void TestAddUserWithSqlException()
        {
            // Arrange 
            Exception exception = null;
            var mockSet = new Mock<DbSet<User>>(MockBehavior.Strict);
            mockSet.Setup(x => x.Add(It.IsAny<User>())).Throws(MakeSqlException());

            var simpleServerMock = new Mock<DbContext>(MockBehavior.Strict);
            simpleServerMock.Setup(x => x.Set<User>()).Returns(mockSet.Object);
            try
            {
                var userRepository = new UserRepository(simpleServerMock.Object);
                var user = new User()
                {
                    FirstName = "test",
                    LastName = "test",
                    Timestamp = DateTime.Now,
                };

               
                //Act
                var result = userRepository.AddUser(user);
            } catch (Exception ex) { exception = ex;}

            // Assert
            simpleServerMock.VerifyAll();
            Assert.IsInstanceOfType(exception, typeof(QueryException));
        }

        [TestMethod]
        public void TestGetUser()
        {
            // Arrange 
            var user = new User()
            {
                FirstName = "test",
                LastName = "test",
                Timestamp = DateTime.Now,
            };

            var data = new List<User>
            {
                user
            }.AsQueryable();
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var simpleServerMock = new Mock<DbContext>();
            simpleServerMock.Setup(x => x.Set<User>()).Returns(mockSet.Object);
            var userRepository = new UserRepository(simpleServerMock.Object);

            //Act
            var result = userRepository.Get((User)=>true);

            // Assert
            Assert.AreEqual(user.FirstName, result.FirstName);
        }

        private SqlException MakeSqlException()
        {
            SqlException exception = null;
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=.;Database=GUARANTEED_TO_FAIL;Connection Timeout=1");
                conn.Open();
            }
            catch (SqlException ex)
            {
                exception = ex;
            }
            return (exception);
        }
    }
}