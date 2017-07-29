using System.Linq;

namespace Core
{
  public class Game
  {
    private Grid grid;

    public bool IsRunning { get; private set; }

    public Game(Grid grid)
    {
      this.grid = grid;
      this.IsRunning = true;
    }

    public int Reveal(Position position)
    {
      var cell = grid.GetCellAtPosition(position);
      cell.Reveal();

      if (cell.HasMine)
      {
        this.IsRunning = false;
        return -1;
      }

      var nearbyCells = grid.GetNearbyCells(position);
      return nearbyCells.Count(c => c.HasMine);

    }

    public void PlantMine(Position position)
    {
      var cell = grid.GetCellAtPosition(position);
      cell.AddMine();
    }

    public void Flag(Position position)
    {
      var cell = grid.GetCellAtPosition(position);
      cell.Flag();
    }
  }
}