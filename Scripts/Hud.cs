using Godot;
using System;

namespace ld56;

public partial class Hud : CanvasLayer {
  public override void _Ready() {
    Nodes.Debug.Visible = false;
    Nodes.Newspaper.Visible = false;
  }

  public override void _Process(double delta) {
    Nodes.Gold.Text = $"Gold: {GameState.Gold}";

    if (Input.IsActionJustPressed("debug")) {
      Nodes.Debug.Visible = !Nodes.Debug.Visible;
    }
  }
}
