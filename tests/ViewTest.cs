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
        public void TestName()
        {
            sut.PresentInstructions();
            consoleMock.Verify(mock => mock.WriteLine());
        }
    }
}