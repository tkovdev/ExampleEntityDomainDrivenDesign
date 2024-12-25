using Data.Access;
using Domain.Access.Abstractions;
using Domain.Access.Interfaces;
using FluentAssertions;
using Logic;
using Moq;

namespace Test.Logic;

[TestClass]
public class CrudLogicTest
{
        private Mock<AppDbContext> _mockCtx { get; set; }
        private ConcreteEntityStub _concreteEntityStub { get; set; }
        private Mock<IEntityFactory> _mockEntityFactory { get; set; }
        
        [TestInitialize]
        public void SetupTests()
        {
                _mockCtx = new Mock<AppDbContext>();
                _concreteEntityStub = new ConcreteEntityStub(_mockCtx.Object);
                _mockEntityFactory = new Mock<IEntityFactory>();   
        }
        
        [TestMethod]
        public void Get_Always_ReturnObject()
        {
                _mockEntityFactory.Setup(x => x.Instantiate<ConcreteEntityStub>())
                        .Returns(_concreteEntityStub);

                var crudLogic = new CrudLogic(_mockEntityFactory.Object);

                var actual = crudLogic.Get<ConcreteEntityStub>();
                actual.Should().BeEquivalentTo(new List<ConcreteEntityStub>());
        }
        
        [TestMethod]
        public void GetById_Always_ReturnObject()
        {
                _mockEntityFactory.Setup(x => x.Instantiate<ConcreteEntityStub>())
                        .Returns(_concreteEntityStub);

                var crudLogic = new CrudLogic(_mockEntityFactory.Object);

                var actual = crudLogic.Get<ConcreteEntityStub>(It.IsAny<int>());
                actual.Should().BeEquivalentTo(_concreteEntityStub);
        }
        
        [TestMethod]
        public void GetAllById_Always_ReturnObject()
        {
                _mockEntityFactory.Setup(x => x.Instantiate<ConcreteEntityStub>())
                        .Returns(_concreteEntityStub);

                var crudLogic = new CrudLogic(_mockEntityFactory.Object);

                var actual = crudLogic.GetAll<ConcreteEntityStub>(It.IsAny<int>());
                actual.Should().BeEquivalentTo(new List<ConcreteEntityStub>());
        }
        
        [TestMethod]
        public void Create_Always_ReturnObject()
        {
                _mockEntityFactory.Setup(x => x.Instantiate<ConcreteEntityStub>())
                        .Returns(_concreteEntityStub);

                var crudLogic = new CrudLogic(_mockEntityFactory.Object);

                var actual = crudLogic.Create(_concreteEntityStub);
                actual.Should().BeEquivalentTo(_concreteEntityStub);
        }
        
        [TestMethod]
        public void Update_Always_ReturnObject()
        {
                _mockEntityFactory.Setup(x => x.Instantiate<ConcreteEntityStub>())
                        .Returns(_concreteEntityStub);

                var crudLogic = new CrudLogic(_mockEntityFactory.Object);

                var actual = crudLogic.Update(_concreteEntityStub);
                actual.Should().BeEquivalentTo(_concreteEntityStub);
        }
        
        [TestMethod]
        public void Delete_Always_ReturnObject()
        {
                _mockEntityFactory.Setup(x => x.Instantiate<ConcreteEntityStub>())
                        .Returns(_concreteEntityStub);

                var crudLogic = new CrudLogic(_mockEntityFactory.Object);

                var actual = crudLogic.Delete<ConcreteEntityStub>(It.IsAny<int>());
                actual.Should().BeEquivalentTo(_concreteEntityStub);
        }
}