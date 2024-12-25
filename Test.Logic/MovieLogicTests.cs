using Data.Access;
using Domain.Access.Interfaces;
using Domain.Entities.Movie;
using Logic;
using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;

namespace Test.Logic;

[TestClass]
public class MovieLogicTests
{
    [TestMethod]
    public void CheckTicket_WhenValidTicket_ReturnTrue()
    {
        var mockCtx = new Mock<AppDbContext>();
        var mockMovieTicket = new Mock<MovieTicket>(mockCtx.Object);
        var mockMovie = new Mock<Movie>(mockCtx.Object);
        var mockEntityFactory = new Mock<IEntityFactory>();
        
        mockMovieTicket.Object.ShowingTime = DateTime.Now.AddMinutes(100);
        mockMovie.Object.RunTime = 100;

        mockMovieTicket.Setup(x => x.Get(It.IsAny<int>()))
            .Returns(mockMovieTicket.Object);
        
        mockMovie.Setup(x => x.Get(It.IsAny<int>()))
            .Returns(mockMovie.Object);
        
        mockEntityFactory.Setup(x => x.Instantiate<MovieTicket>())
            .Returns(mockMovieTicket.Object);
        mockEntityFactory.Setup(x => x.Instantiate<Movie>())
            .Returns(mockMovie.Object);

        mockMovieTicket.Setup(x => x.Update()).Returns(mockMovieTicket.Object);
        
        var movieLogic = new MovieLogic(mockEntityFactory.Object);

        var actual = movieLogic.CheckTicket(1);

        actual.Should().BeTrue();
    }
}