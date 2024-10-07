using Godot;
using System;
using ld56;

public partial class CookingIngredient : Container {
  public event Action Pressed;
  public event Action MouseEntered;
  public event Action MouseExited;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    this.PivotOffset = new Vector2(this.Size.X / 2, this.Size.Y / 2);
    Nodes.Button.Pressed += () => {
      Root.Instance.Nodes.SoundManager.PlayButtonPressSFX();
      Pressed?.Invoke();
    };
    Nodes.Button.MouseEntered += () => {
      MouseEntered?.Invoke();
    };
    Nodes.Button.MouseExited += () => {
      MouseExited?.Invoke();
    };

    this.MouseEntered += () => {
      // Scale up
      this.Scale = this.Scale * 1.1f;
      Root.Instance.Nodes.SoundManager.PlayHoverSFX();
    };

    this.MouseExited += () => {
      // Scale down
      this.Scale = this.Scale / 1.1f;
    };

    Nodes.Tooltip.Visible = false;
  }
}
