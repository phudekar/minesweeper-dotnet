namespace Core
{
  public class Position
  {
    public Position(int row, int column)
    {
      this.Row = row;
      this.Column = column;
    }

    public int Row { get; private set; }
    public int Column { get; private set; }

    public override bool Equals(object obj)
    {
      if (obj != null && obj is Position)
      {
        var other = obj as Position;
        return other.Column == this.Column && other.Row == this.Row;
      }
      return false;
    }

    public override int GetHashCode()
    {
      return this.Row.GetHashCode() >> this.Column.GetHashCode();
    }
  }
}