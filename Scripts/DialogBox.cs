using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
namespace ld56;
using static Utils;

public class DialogReturn {
  public Func<CreatureData, Task>? Next { get; set; }
}

public partial class DialogBox : Control {
  public static DialogBox Instance { get; private set; }

  private bool _isMouseDown = false;

  public override void _Ready() {
    Instance = this;

    Visible = false;
  }

  public override void _Process(double delta) {
    if (Input.IsActionJustPressed("click")) {
      _isMouseDown = true;
    } else if (Input.IsActionJustReleased("click")) {
      _isMouseDown = false;
    }
  }

  public static async Task<DialogReturn> ShowDialog(
    List<IDialogItem> dialog,
    CreatureData creature,
    bool isFirstCall = true) {
    return await Instance.ShowDialogHelper(dialog, creature, isFirstCall);
  }

  private async Task ShowDialogText(string text) {
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText.Text = text;

    for (int i = 0; i < text.Length; i += 3) {
      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText.VisibleCharacters = i;

      for (int j = 0; j < 20; j++) {
        if (_isMouseDown) {
          j += 3;
        }

        if (GameState.HYPERSPEED) {
          break;
        }

        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      }
    }

    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText.VisibleCharacters = text.Length;
  }

  private async Task<DialogReturn> ShowDialogHelper(List<IDialogItem> dialog, CreatureData creature, bool isFirstCall = true) {
    DialogReturn result = new();

    Visible = true;
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName.Text = creature.DisplayName;
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite.Texture = creature.DialogPortraitTexture;
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText.Text = "";
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue.Visible = false;

    while (_isMouseDown) {
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    foreach (var item in dialog) {
      switch (item) {
        case DialogItem dialogItem:
          Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName.Text = dialogItem.OverrideSpeakerName ?? dialogItem.Speaker.DisplayName;
          Nodes.DialogBox_HBoxContainer_DialogTextVBoxContainer.Visible = true;
          Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.Visible = false;
          Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText.Text = dialogItem.Text;

          await ShowDialogText(dialogItem.Text);

          if (dialogItem.OnComplete != null) {
            result = new DialogReturn { Next = dialogItem.OnComplete };

            goto done;
          }

          break;

        case DialogOptions dialogOptions:
          Nodes.DialogBox_HBoxContainer_DialogTextVBoxContainer.Visible = false;
          Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.Visible = true;

          // populate all options

          foreach (var child in Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.GetChildren()) {
            child.QueueFree();
          }

          // show text
          await ShowDialogText(dialogOptions.Text);

          int? selectedOption = null;

          for (int i = 0; i < dialogOptions.Options.Count; i++) {
            var option = dialogOptions.Options[i];

            if (option.IsHidden != null && option.IsHidden()) {
              continue;
            }

            var newOption = DialogOptionNode.New();
            newOption.Nodes.RichTextLabel.Text = option.OptionText;

            Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.AddChild(newOption);


            if (option.IsAvailable != null && !option.IsAvailable()) {
              newOption.SelfModulate = new Color(0.7f, 0.7f, 0.7f);
              newOption.IsDisabled = true;
            } else {
              var index = i;

              newOption.OptionClicked += () => {
                selectedOption = index;
              };
            }
          }

          // wait for selection

          while (selectedOption == null) {
            await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
          }

          var onSelect = dialogOptions.Options[selectedOption.Value].OnSelect;

          if (onSelect != null) {
            result = new DialogReturn { Next = onSelect };

            goto done;
          }

          break;
      }

      if (_isMouseDown) {
        while (_isMouseDown) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }
      }

      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue.Visible = true;

      if (!GameState.HYPERSPEED) {
        while (!_isMouseDown) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }

        while (_isMouseDown) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }

        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      }

      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText.Text = "";
      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_VBoxContainer_PanelContainer_DialogText_ClickToContinue.Visible = false;
    }
  done:

    if (isFirstCall) {
      Visible = false;

      if (result.Next != null) {
        await result.Next(creature);
      }
    }

    return result;
  }
}
