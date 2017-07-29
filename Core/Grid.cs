using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{

  public class Grid
  {
    private readonly int row;
    private readonly int columns;

    public Grid(int rows, int columns)
    {
      this.row = rows;
      this.columns = columns;
      this.CellPositions = new CellPosition[rows * columns];
      InitializeCells(rows, columns);
    }

    private void InitializeCells(int rows, int columns)
    {
      int count = 0;
      for (int row = 0; row < rows; row++)
      {
        for (int column = 0; column < columns; column++)
        {
          this.CellPositions[count] = new CellPosition(new Cell(), new Position(row, column));
          count++;
        }
      }
    }

    public CellPosition[] CellPositions { get; set; }

    public Cell GetCellAtPosition(Position position)
    {
      return this.CellPositions.ToList()
            .Find(cp => position.Equals(cp.Position)).Cell;
    }

    private bool IsPositionExists(Position position)
    {
      return position.Row >= 0 && position.Row <= this.row - 1
      && position.Column >= 0 && position.Column <= this.columns - 1;
    }

    public List<Cell> GetNearbyCells(Position position)
    {
      var nearbyCells = new List<Cell>();
      for (int row = position.Row - 1; row <= position.Row + 1; row++)
      {
        for (int column = position.Column - 1; column <= position.Column + 1; column++)
        {
          Position nearbyPosition = new Position(row, column);
          if (IsPositionExists(nearbyPosition) && !(row == position.Row && column == position.Column))
          {
            nearbyCells.Add(GetCellAtPosition(nearbyPosition));
          }
        }
      }

      return nearbyCells;
    }

  }

}