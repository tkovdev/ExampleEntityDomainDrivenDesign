using Data.Access;
using Domain.Access;
using Domain.Access.Interfaces;
using Exception;
using FluentAssertions;
using Moq;
using Test.Logic;

namespace Test.Domain.Access;

[TestClass]
public class EntityFactoryTests
{
    private Mock<AppDbContext> _mockCtx { get; set; }
    
    [TestInitialize]
    public void SetupTests()
    {
        _mockCtx = new Mock<AppDbContext>();
    }
    
    [TestMethod]
    public void Instantiate_WhenValidType_ReturnObject()
    {
        var entityFactory = new EntityFactory(_mockCtx.Object);
        var actual = entityFactory.Instantiate<ConcreteEntityStub>();
        actual.Should().BeOfType<ConcreteEntityStub>();
    }
    
    [TestMethod]
    public void Instantiate_WhenInvalidType_ThrowsFatalException()
    {
        var entityFactory = new EntityFactory(_mockCtx.Object);
        var action = () => entityFactory.Instantiate<AbstractEmptyEntityStub>();
        action.Should().Throw<FatalException>();
    }
    
    [TestMethod]
    public void Instantiate_WhenExistingType_ReturnObject()
    {
        var entityFactory = new EntityFactory(_mockCtx.Object);
        var existing = new ConcreteEntityStub();
        var actual = entityFactory.Instantiate(existing);
        actual.Should().BeOfType<ConcreteEntityStub>();
    }
}