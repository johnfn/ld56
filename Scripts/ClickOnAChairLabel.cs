using Godot;
namespace ld56;

public partial class ClickOnAChairLabel : PanelContainer {
  private float alpha = 1.0f;
  private bool decreasing = true;

  public override void _Ready() {
  }

  public override void _Process(double delta) {
    if (GameState.Mode == GameMode.ChooseTable) {
      Visible = true;

      if (decreasing) {
        alpha -= (float)delta * 0.5f;
        if (alpha <= 0.5f) {
          alpha = 0.5f;
          decreasing = false;
        }
      } else {
        alpha += (float)delta * 0.5f;
        if (alpha >= 1.0f) {
          alpha = 1.0f;
          decreasing = true;
        }
      }
      Modulate = new Color(Modulate.R, Modulate.G, Modulate.B, alpha);
    } else {
      Visible = false;
    }
  }
}
