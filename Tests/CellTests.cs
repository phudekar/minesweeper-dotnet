using System;
using Core;
using FluentAssertions;
using Xunit;

namespace Tests
{
  public class CellTests
  {
    [Fact]
    public void CellShouldNotHaveMineByDefault()
    {
      var cell = new Cell();

      cell.HasMine.Should().BeFalse();
    }

    [Fact]
    public void ShouldBeAbleToAddMine()
    {
      var cell = new Cell();

      cell.AddMine();

      cell.HasMine.Should().BeTrue();
    }

    [Fact]
    public void CellShouldNotBeRevealedByDefault()
    {
      var cell = new Cell();

      cell.IsRevealed.Should().BeFalse();
    }


    [Fact]
    public void ShouldBeAbleRevealCell()
    {
      var cell = new Cell();

      cell.Reveal();

      cell.IsRevealed.Should().BeTrue();
    }

    [Fact]
    public void CellShouldNotBeFlaggedByDefault()
    {
      var cell = new Cell();

      cell.HasFlag.Should().BeFalse();
    }

    [Fact]
    public void ShouldBeAbleFlagCell()
    {
      var cell = new Cell();

      cell.Flag();

      cell.HasFlag.Should().BeTrue();
    }

    [Fact]
    public void ShouldNotBeAbleFlagCellIfItIsRevealed()
    {
      var cell = new Cell();

      cell.Reveal();
      cell.Flag();

      cell.HasFlag.Should().BeFalse();
    }

  }
}
