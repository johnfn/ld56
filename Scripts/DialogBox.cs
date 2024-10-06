using Godot;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ld56;
using static Utils;

public enum DialogReturn {
  None,
  BeginCooking,
}

public partial class DialogBox : PanelContainer {
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

  public async Task<DialogReturn> ShowDialog(List<IDialogItem> dialog) {
    Visible = true;
    Nodes.HBoxContainer_VBoxContainer_Label.Text = "";
    Nodes.HBoxContainer_DialogTextVBoxContainer_DialogText.Text = "";
    Nodes.HBoxContainer_DialogTextVBoxContainer_ClickToContinue.Visible = false;

    while (_isMouseDown) {
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    foreach (var item in dialog) {
      switch (item) {
        case DialogBeginCooking dialogBeginCooking:
          return DialogReturn.BeginCooking;
        case DialogItem dialogItem:
          Nodes.HBoxContainer_DialogTextVBoxContainer.Visible = true;
          Nodes.HBoxContainer_OptionsVBoxContainer.Visible = false;
          Nodes.HBoxContainer_VBoxContainer_Label.Text = dialogItem.Speaker;

          Nodes.HBoxContainer_DialogTextVBoxContainer_DialogText.Text = dialogItem.Text;

          for (int i = 0; i < dialogItem.Text.Length; i++) {
            Nodes.HBoxContainer_DialogTextVBoxContainer_DialogText.VisibleCharacters = i;

            for (int j = 0; j < 20; j++) {
              if (_isMouseDown) {
                j += 3;
              }

              // if (Root.Instance.HYPER) {
              //   break;
              // }

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

          int? selectedOption = null;

          for (int i = 0; i < dialogOptions.Options.Count; i++) {
            var option = dialogOptions.Options[i];
            var newOption = DialogOptionNode.New();
            newOption.Text = option.OptionText;

            Nodes.HBoxContainer_OptionsVBoxContainer.AddChild(newOption);

            var index = i;

            newOption.OptionClicked += () => {
              selectedOption = index;
            };
          }

          while (selectedOption == null) {
            await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
          }

          var onSelect = dialogOptions.Options[selectedOption.Value].OnSelect;

          if (onSelect != null) {
            return await ShowDialog(onSelect());
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

    Visible = false;

    return DialogReturn.None;
  }
}
