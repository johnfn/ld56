using Godot;

namespace ld56;
using static Utils;

public partial class HighlightCircle : Sprite2D {
  public override void _Ready() {
  }

  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouseMotion) {
      var pos = GetGlobalMousePosition();
      var localPos = ToLocal(pos);

      if (GetRect().HasPoint(localPos)) {
        OnMouseEntered();
      } else {
        OnMouseExited();
      }
    }

    if (@event is InputEventMouseButton) {
      if (GetRect().HasPoint(ToLocal(GetGlobalMousePosition()))) {
        Root.Instance.Nodes.AnimalManager.SelectChair(this);
      }
    }
  }

  public override void _Process(double delta) {
  }

  private void OnMouseEntered() {
    Modulate = new Color(0.5f, 0, 0); // Dark red
  }

  private void OnMouseExited() {
    Modulate = new Color(1, 1, 1); // Normal (white)
  }
}
