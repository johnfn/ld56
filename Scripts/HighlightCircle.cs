using Godot;

namespace ld56;
using static Utils;

public enum ChairFacing {
  Left,
  Right,
}

[Tool]
public partial class HighlightCircle : Sprite2D {
  private ChairFacing _chairFacing = ChairFacing.Left;

  [Export]
  public ChairFacing ChairFacing {
    get {
      return _chairFacing;
    }
    set {
      _chairFacing = value;
      if (value == ChairFacing.Left) {
        Texture = GD.Load<Texture2D>("res://Assets/Backgrounds/Interior_Chair_Left.png");
      } else if (value == ChairFacing.Right) {
        Texture = GD.Load<Texture2D>("res://Assets/Backgrounds/Interior_Chair_Right.png");
      }
    }
  }

  public override void _Ready() {
    ChairFacing = _chairFacing;
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
    if (GameState.Mode != GameMode.ChooseTable) {
      Modulate = new Color(1, 1, 1); // Normal (white)
    }

    if (GameState.Mode == GameMode.ChooseTable) {
      Nodes.Button.MouseDefaultCursorShape = Control.CursorShape.PointingHand;
    } else {
      Nodes.Button.MouseDefaultCursorShape = Control.CursorShape.Arrow;
    }
  }

  private void OnMouseEntered() {
    Modulate = new Color(0.5f, 0.5f, 0.5f); // Dark red
  }

  private void OnMouseExited() {
    Modulate = new Color(1, 1, 1); // Normal (white)
  }
}
