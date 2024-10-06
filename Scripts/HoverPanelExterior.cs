using Godot;
using System;
namespace ld56;

public partial class HoverPanelExterior : PanelContainer {
  public event Action Clicked;
  public SpawnedCreature SpawnedCreature { get; set; }

  public override void _Ready() {
    Nodes.MarginContainer_HBoxContainer_Left_LeftLabel.Visible = false;
    Nodes.MarginContainer_HBoxContainer_Right_RightLabel.Visible = false;

    Nodes.MarginContainer_HBoxContainer_Left.MouseEntered += () => {
      Nodes.MarginContainer_HBoxContainer_Left_LeftLabel.Visible = true;
    };

    Nodes.MarginContainer_HBoxContainer_Left.MouseExited += () => {
      Nodes.MarginContainer_HBoxContainer_Left_LeftLabel.Visible = false;
    };

    Nodes.MarginContainer_HBoxContainer_Right.MouseEntered += () => {
      Nodes.MarginContainer_HBoxContainer_Right_RightLabel.Visible = true;
    };

    Nodes.MarginContainer_HBoxContainer_Right.MouseExited += () => {
      Nodes.MarginContainer_HBoxContainer_Right_RightLabel.Visible = false;
    };

    // Connect the GuiInput event
    GuiInput += OnGuiInput;
  }

  public void Initialize(SpawnedCreature spawnedCreature) {
    SpawnedCreature = spawnedCreature;
  }

  public override void _Process(double delta) {
    if (SpawnedCreature == null) {
      return;
    }

    Nodes.MarginContainer_HBoxContainer_Right_RightLabel.Text = SpawnedCreature.State switch {
      CreatureState.WaitToBeAdmitted => "Admit",
      CreatureState.NotSpawnedYet => "",
      CreatureState.WalkToEntrance => "",
      CreatureState.WaitForTable => "Sit",
      CreatureState.WalkInside => "",
      CreatureState.WalkToTable => "",
      CreatureState.WaitForTalk => "Talk",
      CreatureState.WalkToExit => "",
      CreatureState.Done => "",
    };

    Nodes.MarginContainer_HBoxContainer_Left_LeftLabel.Text = "";
  }

  private void OnGuiInput(InputEvent @event) {
    if (@event is InputEventMouseButton mouseEvent &&
        mouseEvent.ButtonIndex == MouseButton.Left &&
        mouseEvent.Pressed) {
      OnClick();
    }
  }

  private void OnClick() {
    if (SpawnedCreature.State == CreatureState.WaitToBeAdmitted) {
      Root.Instance.Nodes.AnimalManager.Admit(SpawnedCreature);
    } else if (SpawnedCreature.State == CreatureState.WaitForTable) {
      Root.Instance.Nodes.AnimalManager.Sit(SpawnedCreature);
    } else if (SpawnedCreature.State == CreatureState.WaitForTalk) {
      Root.Instance.Nodes.AnimalManager.StartDialog(SpawnedCreature);
    }
  }
}
