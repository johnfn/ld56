using Godot;
using System;
using ld56;

public partial class RolodexIngredientEntry : PanelContainer {
  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    this.Nodes.Button.Pressed += () => {
      Root.Instance.Nodes.SoundManager.PlayButtonPressSFX();
    };

    this.Nodes.Button.MouseEntered += () => {
      this.Scale = this.Scale * 1.1f;
      Root.Instance.Nodes.SoundManager.PlayHoverSFX();
    };

    this.Nodes.Button.MouseExited += () => {
      this.Scale = this.Scale / 1.1f;
    };
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
  }
}
