using Godot;

public partial class DayIndicator : Control {
  public override void _Ready() {
    Nodes.Checkmark.Visible = false;
  }

  public override void _Process(double delta) {
  }
}
