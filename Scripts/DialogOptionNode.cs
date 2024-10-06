using System;
using Godot;
namespace ld56;
using static Utils;

public partial class DialogOptionNode : PanelContainer {
  public event Action OptionClicked;

  public override void _Ready() {
    Modulate = new Color(0.8f, 0.8f, 0.8f);
  }

  public override void _Process(double delta) {
    if (GetRect().HasPoint(GetLocalMousePosition())) {
      Modulate = new Color(1, 1, 1);
      if (Input.IsActionJustPressed("click")) {
        OptionClicked?.Invoke();
      }
    } else {
      Modulate = new Color(0.8f, 0.8f, 0.8f);
    }
  }
}
