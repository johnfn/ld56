using Godot;
using System;

public partial class CookingResultModal : PanelContainer {
  public event Action OnClose;

  public override void _Ready() {
    Nodes.HBoxContainer_Confirm.Pressed += () => OnClose?.Invoke();
  }
}
