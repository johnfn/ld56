using Godot;
using System;

namespace ld56;


public partial class Hud : CanvasLayer {
  public override void _Ready() {
    if (GameState.IS_DEBUG) {
      Nodes.DebugEndDay.Visible = true;
    } else {
      Nodes.DebugEndDay.Visible = false;
    }
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
  }
}
