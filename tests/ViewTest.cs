using System;
using Xunit;
using Moq;

namespace SticksGame
{
    public class ViewTest
    {
        View sut;
        Mock<ConsoleWrapper> consoleMock;

        public ViewTest()
        {
            consoleMock = new Mock<ConsoleWrapper>();
            sut = new View(consoleMock.Object);
        }

        [Fact]
        public void ViewShouldPresentInstructions()
        {
            sut.PresentInstructions();
            consoleMock.Verify(mock => mock.WriteLine("Welcome! Enter the number of sticks you want to take (1-3):"));
        }

        [Fact]
        public void ViewShouldOnlyAcceptAnIntegerBetweenOneAndThree()
        {
            consoleMock.SetupSequence(mock => mock.ReadLine())
                .Returns("0")
                .Returns("-10")
                .Returns(">+?")
                .Returns("five")
                .Returns("4")
                .Returns("3");
            int actual = sut.GetInput();
            int expected = 3;
            Assert.Equal(expected, actual);
        }
    }
}