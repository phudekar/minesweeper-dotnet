using Core;
using FluentAssertions;
using Xunit;

namespace Tests
{
  public class GameTests
  {
    private Game game;
    private readonly int rows;
    private readonly int columns;
    private Grid grid;

    public GameTests()
    {
      rows = 3;
      columns = 5;
      grid = new Grid(rows, columns);
      game = new Game(grid);
    }

    [Fact]
    public void ShouldRevealCellAtGivenPosition()
    {
      var position = new Position(0, 3);
      game.Reveal(position);

      var cell = grid.GetCellAtPosition(position);
      cell.IsRevealed.Should().BeTrue();
    }


    [Fact]
    public void ShouldPlatMineAtGivenPosition()
    {
      var position = new Position(0, 3);
      game.PlantMine(position);

      var cell = grid.GetCellAtPosition(position);
      cell.HasMine.Should().BeTrue();
    }

    [Fact]
    public void ShouldFlagCellAtGivenPosition()
    {
      var position = new Position(0, 3);

      game.Flag(position);

      var cell = grid.GetCellAtPosition(position);
      cell.HasFlag.Should().BeTrue();
    }

    [Fact]
    public void ShouldBeRunningByDefault()
    {
      game.IsRunning.Should().BeTrue();
    }

    [Fact]
    public void ShouldEndGameIfRevealedCellHasMine()
    {
      var position = new Position(0, 3);

      game.PlantMine(position);
      game.Reveal(position);

      game.IsRunning.Should().BeFalse();
    }

    [Fact]
    public void ShouldTellNumberOfMinesNearGivenCell()
    {
      var position1 = new Position(0, 4);
      var position2 = new Position(1, 3);

      game.PlantMine(position1);
      game.PlantMine(position2);

      var noOfMinesNearby = game.Reveal(new Position(0, 3));

      noOfMinesNearby.Should().Be(2);
    }

  }
}