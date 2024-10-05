using Godot;
using System;

namespace ld56;

public partial class UpcomingCreatureUi : ColorRect {
  public override void _Ready() {
    Nodes.Popover.Visible = false;

    MouseEntered += () => {
      Nodes.Popover.Visible = true;
    };

    MouseExited += () => {
      Nodes.Popover.Visible = false;
    };
  }

  public override void _Process(double delta) {
  }
}
