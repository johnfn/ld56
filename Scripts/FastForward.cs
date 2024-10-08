using Godot;
using ld56;

public partial class FastForward : TextureButton {
  private bool _isMouseOver = false;

  public override void _Ready() {
    MouseEntered += () => {
      _isMouseOver = true;
    };
    MouseExited += () => {
      _isMouseOver = false;
    };
  }

  public override void _Process(double delta) {
    if (_isMouseOver) {
      Nodes.RecipesTooltip.Visible = true;
    } else {
      Nodes.RecipesTooltip.Visible = false;
    }
    var (timeString, period) = Clock.GetTimeString(GameState.CurrentDayTime);

    var ts = 1;

    if (Input.IsMouseButtonPressed(MouseButton.Left) && _isMouseOver) {
      ts = 10;

      Nodes.RecipesTooltip_MarginContainer_Label.Text = $"{timeString} {period} - Fast-forwarding";
    } else {
      Nodes.RecipesTooltip_MarginContainer_Label.Text = $"{timeString} {period} - Fast-forward (Shift)";
    }

    if (Input.IsKeyPressed(Key.Shift)) {
      ts = 10;
    }

    Engine.TimeScale = ts;

    (Material as ShaderMaterial).Set("shader_parameter/width", Engine.TimeScale > 1 ? 10.0f : 0.0f);
  }
}
