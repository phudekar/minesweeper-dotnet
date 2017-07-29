namespace Core
{

  public class CellPosition
  {
    public CellPosition(Cell cell, Position position)
    {
      this.Position = position;
      this.Cell = cell;
    }

    public Cell Cell { get; private set; }
    public Position Position { get; private set; }
  }

}