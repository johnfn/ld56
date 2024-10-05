using Godot;
using System;

public partial class Interior : Sprite2D {
  public override void _Ready() {
    Nodes.Chairs.Visible = false;
  }

  public override void _Process(double delta) {
  }
}
