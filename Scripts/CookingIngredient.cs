using Godot;
using System;

public partial class CookingIngredient : PanelContainer {
  public event Action<CookingIngredient> OnClick;

  public override void _Ready() {
    MouseEntered += OnMouseEntered;
    MouseExited += OnMouseExited;
    GuiInput += OnGuiInput;
    Modulate = new Color(0.7f, 0.7f, 0.7f);
  }

  private void OnMouseEntered() {
    Modulate = new Color(1, 1, 1);
  }

  private void OnMouseExited() {
    Modulate = new Color(0.7f, 0.7f, 0.7f);
  }

  private void OnGuiInput(InputEvent @event) {
    if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
      GD.Print("2 clicked!");
      OnClick?.Invoke(this);
    }
  }
}
