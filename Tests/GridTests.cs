using System.Collections.Generic;
using Core;
using FluentAssertions;
using Xunit;

namespace Tests
{
  public class GridTests
  {
    private Grid grid;
    private readonly int rows;
    private readonly int columns;

    public GridTests()
    {
      rows = 3;
      columns = 5;
      grid = new Grid(rows, columns);
    }

    [Fact]
    public void ShouldHavePositionsAsPerRowsColumns()
    {
      CellPosition[] positions = grid.CellPositions;

      positions.Length.Should().Be(rows * columns);
    }

    [Fact]
    public void ShouldGenerateCellsWithDefaultState()
    {
      CellPosition[] cellPositions = grid.CellPositions;

      cellPositions[0].Cell.Should().NotBeNull();
    }

    [Fact]
    public void ShouldGenerateCellPositionsWithPositionInformation()
    {
      CellPosition[] cellPositions = grid.CellPositions;

      cellPositions[7].Position.Row.Should().Be(1);
      cellPositions[7].Position.Column.Should().Be(2);
    }


    [Fact]
    public void ShouldGiveNearbyCells()
    {
      var position = new Position(1, 1);
      List<Cell> cells = grid.GetNearbyCells(position);

      cells.Count.Should().Be(8);

      cells.Should().Contain(grid.GetCellAtPosition(new Position(0, 0)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(0, 1)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(0, 2)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(1, 0)));

      cells.Should().Contain(grid.GetCellAtPosition(new Position(1, 2)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(2, 0)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(2, 1)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(2, 2)));

    }

    [Fact]
    public void ShouldGiveNearbyCellsOfCornerCell()
    {
      var position = new Position(0, 0);

      List<Cell> cells = grid.GetNearbyCells(position);

      cells.Count.Should().Be(3);

      cells.Should().Contain(grid.GetCellAtPosition(new Position(0, 1)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(1, 1)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(1, 0)));
    }

    [Fact]
    public void ShouldGiveNearbyCellsOfLastCell()
    {
      var position = new Position(2, 4);

      List<Cell> cells = grid.GetNearbyCells(position);

      cells.Count.Should().Be(3);

      cells.Should().Contain(grid.GetCellAtPosition(new Position(1, 4)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(1, 3)));
      cells.Should().Contain(grid.GetCellAtPosition(new Position(2, 3)));
    }
  }
}