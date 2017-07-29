using Core;
using FluentAssertions;
using Xunit;

namespace Tests
{

  public class PositionTests
  {

    [Fact]
    public void ShouldReturnTrueForSamePositions()
    {
      var position = new Position(5, 3);

      position.Equals(position).Should().BeTrue();
    }

    [Fact]
    public void ShouldReturnFalseForNullPosition()
    {
      var position = new Position(5, 3);

      position.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void ShouldReturnFalseForOtherPosition()
    {
      var position1 = new Position(3, 2);
      var position2 = new Position(5, 5);

      position1.Equals(position2).Should().BeFalse();
    }

  }

}