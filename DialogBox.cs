using Godot;

using System.Threading.Tasks;
namespace ld56;

public partial class DialogBox : PanelContainer {
  public Dialog Dialog { get; set; }
  private bool _isMouseDown = false;

  public override void _Ready() {
    Visible = false;
  }

  public override void _Process(double delta) {
    if (Input.IsActionJustPressed("click")) {
      _isMouseDown = true;
    } else if (Input.IsActionJustReleased("click")) {
      _isMouseDown = false;
    }
  }

  public async Task ShowDialog(Dialog dialog) {
    Dialog = dialog;
    Visible = true;
    Nodes.HBoxContainer_VBoxContainer_Label.Text = "";
    Nodes.HBoxContainer_DialogTextVBoxContainer_DialogText.Text = "";
    Nodes.HBoxContainer_DialogTextVBoxContainer_ClickToContinue.Visible = false;

    while (_isMouseDown) {
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    foreach (var item in dialog.Items) {
      switch (item) {
        case DialogItem dialogItem:
          Nodes.HBoxContainer_DialogTextVBoxContainer.Visible = true;
          Nodes.HBoxContainer_OptionsVBoxContainer.Visible = false;
          Nodes.HBoxContainer_VBoxContainer_Label.Text = dialogItem.Speaker;

          for (int i = 0; i < dialogItem.Text.Length; i++) {
            Nodes.HBoxContainer_DialogTextVBoxContainer_DialogText.Text += dialogItem.Text[i];

            for (int j = 0; j < 20; j++) {
              if (_isMouseDown) {
                j += 3;
              }

              await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
            }
          }

          break;

        case DialogOptions dialogOptions:
          Nodes.HBoxContainer_DialogTextVBoxContainer.Visible = false;
          Nodes.HBoxContainer_OptionsVBoxContainer.Visible = true;

          foreach (var child in Nodes.HBoxContainer_OptionsVBoxContainer.GetChildren()) {
            child.QueueFree();
          }

          foreach (var option in dialogOptions.Options) {
            var newOption = DialogOptionNode.New();
            newOption.Text = option.OptionText;

            Nodes.HBoxContainer_OptionsVBoxContainer.AddChild(newOption);
          }

          break;

        case DialogReward dialogReward:
          // Display the dialog reward text
          GD.Print($"Reward: {dialogReward.Text}");
          break;
      }

      if (_isMouseDown) {
        while (_isMouseDown) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }
      }

      Nodes.HBoxContainer_DialogTextVBoxContainer_ClickToContinue.Visible = true;

      while (!_isMouseDown) {
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      }

      while (_isMouseDown) {
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      }

      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

      Nodes.HBoxContainer_DialogTextVBoxContainer_DialogText.Text = "";
      Nodes.HBoxContainer_DialogTextVBoxContainer_ClickToContinue.Visible = false;
    }
  }
}
