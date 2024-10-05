using Godot;
using System;
using static Utils;

namespace ld56;

public partial class Camera : Camera2D {
  private Rect2 _bounds = new(0, 0, 0, 0);
  private float _speed = 500;
  private float _margin = 100;

  public override void _Ready() {
  }

  public override void _Process(double delta) {
    var mousePosition = GetViewport().GetMousePosition();
    var newPosition = Position;

    if (mousePosition.X < GetViewport().GetVisibleRect().Position.X + _margin) {
      newPosition.X -= _speed * (float)delta;
    } else if (mousePosition.X > GetViewport().GetVisibleRect().Position.X + GetViewport().GetVisibleRect().Size.X - _margin) {
      newPosition.X += _speed * (float)delta;
    }

    if (mousePosition.Y < GetViewport().GetVisibleRect().Position.Y + _margin) {
      newPosition.Y -= _speed * (float)delta;
    } else if (mousePosition.Y > GetViewport().GetVisibleRect().Position.Y + GetViewport().GetVisibleRect().Size.Y - _margin) {
      newPosition.Y += _speed * (float)delta;
    }

    // Clamp the camera position to the bounds
    newPosition.X = Mathf.Clamp(newPosition.X, _bounds.Position.X, _bounds.Position.X + _bounds.Size.X);
    newPosition.Y = Mathf.Clamp(newPosition.Y, _bounds.Position.Y, _bounds.Position.Y + _bounds.Size.Y);

    Position = newPosition;
  }

  public void SetBounds(Rect2 bounds) {
    _bounds = bounds;
  }
}
