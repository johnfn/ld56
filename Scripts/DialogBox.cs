using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ld56;
using static Utils;

public class DialogReturn {
  public Func<CreatureId, Task>? Next { get; set; }
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
    CreatureId creatureId,
    bool isFirstCall = true) {
    return await Instance.ShowDialogHelper(dialog, creatureId, isFirstCall);
  }

  private async Task ShowDialogText(string text) {
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_DialogText.Text = text;

    for (int i = 0; i < text.Length; i += 3) {
      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_DialogText.VisibleCharacters = i;

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

    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_DialogText.VisibleCharacters = text.Length;

    if (!_isMouseDown) {
      while (!_isMouseDown) {
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      }
    } else {
      while (_isMouseDown) {
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      }
    }
  }

  private async Task<DialogReturn> ShowDialogHelper(List<IDialogItem> dialog, CreatureId creatureId, bool isFirstCall = true) {
    DialogReturn result = new();

    Visible = true;
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_DialogText.Text = "";
    Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_ClickToContinue.Visible = false;

    GD.Print($"!! {creatureId} {dialog[0]}");

    switch (dialog[0]) {
      case DialogItem dialogItem: {
          var speakerId = dialogItem.Speaker;

          Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName.Text = dialogItem.OverrideSpeakerName ?? AllCreatures.CreatureIdToData[speakerId].DisplayName;
          Nodes.DialogBox_HBoxContainer_CharacterDialogSprite.Texture = AllCreatures.CreatureIdToData[speakerId].DialogPortraitTexture;
          Nodes.DialogBox_HBoxContainer_DialogTextVBoxContainer.Visible = true;
          Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.Visible = false;
          break;
        }

      case DialogOptions dialogOptions: {
          var speakerId = dialogOptions.Speaker;

          Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName.Text = dialogOptions.OverrideSpeakerName ?? AllCreatures.CreatureIdToData[speakerId].DisplayName;
          Nodes.DialogBox_HBoxContainer_CharacterDialogSprite.Texture = AllCreatures.CreatureIdToData[speakerId].DialogPortraitTexture;
          Nodes.DialogBox_HBoxContainer_DialogTextVBoxContainer.Visible = false;
          Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.Visible = true;
          break;
        }
    }

    while (_isMouseDown) {
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    foreach (var item in dialog) {
      switch (item) {
        case DialogItem dialogItem: {
            var speakerId = dialogItem.Speaker;
            Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName.Text = dialogItem.OverrideSpeakerName ?? AllCreatures.CreatureIdToData[speakerId].DisplayName;
            Nodes.DialogBox_HBoxContainer_DialogTextVBoxContainer.Visible = true;
            Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.Visible = false;
            Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_DialogText.Text = dialogItem.Text;
            Nodes.DialogBox_HBoxContainer_CharacterDialogSprite.Texture = AllCreatures.CreatureIdToData[speakerId].DialogPortraitTexture;

            await ShowDialogText(dialogItem.Text);

            if (dialogItem.OnComplete != null) {
              result = new DialogReturn { Next = (CreatureId creatureId) => dialogItem.OnComplete(creatureId) };

              goto done;
            }

            break;
          }

        case DialogOptions dialogOptions: {
            var speakerId = dialogOptions.Speaker;

            Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_CharacterName.Text = dialogOptions.OverrideSpeakerName ?? AllCreatures.CreatureIdToData[speakerId].DisplayName;
            Nodes.DialogBox_HBoxContainer_DialogTextVBoxContainer.Visible = false;
            Nodes.DialogBox_HBoxContainer_OptionsVBoxContainer.Visible = true;
            Nodes.DialogBox_HBoxContainer_CharacterDialogSprite.Texture = AllCreatures.CreatureIdToData[speakerId].DialogPortraitTexture;

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
      }

      if (_isMouseDown) {
        while (_isMouseDown) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }
      }

      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_ClickToContinue.Visible = true;

      if (!GameState.HYPERSPEED) {
        while (!_isMouseDown) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }

        while (_isMouseDown) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }

        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      }

      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_DialogText.Text = "";
      Nodes.DialogBox_HBoxContainer_CharacterDialogSprite_PanelContainer_VBoxContainer_ClickToContinue.Visible = false;
    }
  done:

    if (isFirstCall) {
      Visible = false;

      if (result.Next != null) {
        await result.Next(creatureId);
      }
    }

    return result;
  }
}
