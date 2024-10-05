using Godot;
using System;

namespace ld56;

public partial class Test : VBoxContainer {
  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    GrowVertical = GrowDirection.End;
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
  }
}
