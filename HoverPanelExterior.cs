using Godot;
using System;
namespace ld56;

public partial class HoverPanelExterior : PanelContainer {
  public event Action Clicked;

  public override void _Ready() {
    Nodes.MarginContainer_HBoxContainer_Left_LeftLabel.Visible = false;
    Nodes.MarginContainer_HBoxContainer_Right_RightLabel.Visible = false;

    Nodes.MarginContainer_HBoxContainer_Left.MouseEntered += () => {
      Nodes.MarginContainer_HBoxContainer_Left_LeftLabel.Visible = true;
    };

    Nodes.MarginContainer_HBoxContainer_Left.MouseExited += () => {
      Nodes.MarginContainer_HBoxContainer_Left_LeftLabel.Visible = false;
    };

    Nodes.MarginContainer_HBoxContainer_Right.MouseEntered += () => {
      Nodes.MarginContainer_HBoxContainer_Right_RightLabel.Visible = true;
    };

    Nodes.MarginContainer_HBoxContainer_Right.MouseExited += () => {
      Nodes.MarginContainer_HBoxContainer_Right_RightLabel.Visible = false;
    };

    // Connect the GuiInput event
    GuiInput += OnGuiInput;
  }

  private void OnGuiInput(InputEvent @event) {
    if (@event is InputEventMouseButton mouseEvent &&
        mouseEvent.ButtonIndex == MouseButton.Left &&
        mouseEvent.Pressed) {
      Clicked?.Invoke();
    }
  }
}
