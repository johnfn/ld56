using Godot;
using System;

public partial class SoundManager : Node {

  // Page turn SFX
  [Export]
  public AudioStream[] PageTurnSFX = [];

  [Export]
  public AudioStream ButtonPressSFX;

  [Export]
  public AudioStream HoverSFX;



  [Export]
  public AudioStream[] CookingSFX = [];


  public void PlayPageTurnSFX() {
    GD.Randomize();
    if (PageTurnSFX.Length == 0) {
      GD.PushWarning("No page turn SFX set for Rolodex.");
      return;
    }
    var randomIndex = GD.Randi() % PageTurnSFX.Length;
    var randomPageTurnSFX = PageTurnSFX[randomIndex];
    Nodes.AudioStreamPlayer2D.Stream = randomPageTurnSFX;
    Nodes.AudioStreamPlayer2D.Play();
  }

  public void PlayButtonPressSFX() {
    Nodes.AudioStreamPlayer2D.Stream = ButtonPressSFX;
    Nodes.AudioStreamPlayer2D.Play();
  }

  public void PlayHoverSFX() {
    Nodes.AudioStreamPlayer2D.Stream = HoverSFX;
    Nodes.AudioStreamPlayer2D.Play();
  }


  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
  }
}
