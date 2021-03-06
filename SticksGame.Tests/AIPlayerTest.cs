using System;
using Xunit;
using Moq;

namespace SticksGame.Tests
{
    public class AIPlayerTest
    {
        AIPlayer sut;
        Mock<Sticks> sticksMock;
        public AIPlayerTest()
        {
            sut = new AIPlayer();
            sticksMock = new Mock<Sticks>();
        }
        
        [Fact]
        public void AIPlayerShouldRemoveThreeSticks()
        {
            sut.Play(sticksMock.Object);
            sticksMock.Verify(mock => mock.RemoveSticks(3));
        }

        [Fact]
        public void AIPlayerShouldRemoveTwoSticksIfThreeLeft()
        {
            sticksMock.SetupGet(mock => mock.Amount).Returns(3);
            sut.Play(sticksMock.Object);
            sticksMock.Verify(mock => mock.RemoveSticks(2));
        }

        [Fact]
        public void AIPlayerShouldRemoveOneStickIfTwoLeft()
        {
            sticksMock.SetupGet(mock => mock.Amount).Returns(2);
            sut.Play(sticksMock.Object);
            sticksMock.Verify(mock => mock.RemoveSticks(1));
        }
    }
}