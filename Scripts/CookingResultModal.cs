using Godot;
using System;
using ld56;

public partial class CookingResultModal : Control {
  public event Action OnClose;

  public override void _Ready() {
    PrepSfx();
  }

  private async void PrepSfx() {
    await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

    // Spawn 5 random cooking SFX
    for (int i = 0; i < 5; i++) {
      var randomIndex = GD.Randi() % Root.Instance.Nodes.SoundManager.CookingSFX.Length;
      var randomCookingSFX = Root.Instance.Nodes.SoundManager.CookingSFX[randomIndex];
      var audioStreamPlayer2D = new AudioStreamPlayer2D {
        Stream = randomCookingSFX
      };
      // audioStreamPlayer2D.Play();
    }
  }

  public override void _Process(double delta) {
    // Spin the glow
    Nodes.Glow.Rotation += (float)delta;
  }

  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouseButton) {
      OnClose?.Invoke();
    }
  }
}
