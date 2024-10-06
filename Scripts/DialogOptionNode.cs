using System;
using Godot;
namespace ld56;
using static Utils;

public partial class DialogOptionNode : PanelContainer {
  public event Action OptionClicked;

  public override void _Ready() {
    Nodes.RichTextLabel.Modulate = new Color(0.5f, 0.5f, 0.5f);
  }

  public override void _Process(double delta) {
    if (GetRect().HasPoint(GetLocalMousePosition())) {
      Nodes.RichTextLabel.Modulate = new Color(1, 1, 1);
      if (Input.IsActionJustPressed("click")) {
        OptionClicked?.Invoke();
      }
    } else {
      Nodes.RichTextLabel.Modulate = new Color(0.5f, 0.5f, 0.5f);
    }
  }
}
