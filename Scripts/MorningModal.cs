using Godot;
using System;

namespace ld56;

public partial class MorningModal : Panel {
  public event Action? OnClose;
  public override void _Ready() {
    Nodes.DoneButton.Pressed += () => OnClose?.Invoke();
  }

  public override void _Process(double delta) {
  }

  public void ClearAction() {
    OnClose = null;
  }
}
