using System;

namespace Core
{
  public class Cell
  {
    public bool HasMine { get; private set; }
    public bool IsRevealed { get; private set; }
    public bool HasFlag { get; set; }

    public void AddMine()
    {
      this.HasMine = true;
    }

    public void Reveal()
    {
      this.IsRevealed = true;
    }

    public void Flag()
    {
      if (IsHidden())
      {
        this.HasFlag = true;
      }

    }

    private bool IsHidden()
    {
      return !this.IsRevealed;
    }
  }
}
