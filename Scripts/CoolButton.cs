using Godot;
using ld56;
using System;

public partial class CoolButton : Button {
  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    this.Pressed += () => {
      Root.Instance.Nodes.SoundManager.PlayButtonPressSFX();
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
  }
}
