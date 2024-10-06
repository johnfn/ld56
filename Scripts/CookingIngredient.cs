using Godot;
using System;

public partial class CookingIngredient : Control {
  public event Action<CookingIngredient> OnClick;
  public event Action<CookingIngredient> OnMouseEnter;
  public event Action<CookingIngredient> OnMouseExit;

  public override void _Ready() {
    Nodes.Container.MouseEntered += OnMouseEntered;
    Nodes.Container.MouseExited += OnMouseExited;
    Nodes.Container.GuiInput += OnGuiInput;
    Modulate = new Color(0.7f, 0.7f, 0.7f);

    Nodes.BuyTooltip.Visible = false;
  }

  private void OnMouseEntered() {
    OnMouseEnter?.Invoke(this);
    Modulate = new Color(1, 1, 1);
  }

  private void OnMouseExited() {
    OnMouseExit?.Invoke(this);
    Modulate = new Color(0.7f, 0.7f, 0.7f);
  }

  private void OnGuiInput(InputEvent @event) {
    if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed) {
      OnClick?.Invoke(this);
    }
  }
}
