using Godot;
using System;
using System.Diagnostics;

namespace ld56;

public partial class UpcomingCreatureUi : ColorRect {
  private SpawnedCreature _spawnedCreature;

  public void Initialize(SpawnedCreature spawnedCreature) {
    _spawnedCreature = spawnedCreature;
  }

  public override void _Ready() {
    Nodes.Popover.Visible = false;

    MouseEntered += () => {
      Nodes.Popover.Visible = true;
    };

    MouseExited += () => {
      Nodes.Popover.Visible = false;
    };

    // Connect the GuiInput event
    GuiInput += OnGuiInput;
  }

  private void OnGuiInput(InputEvent @event) {
    if (@event is InputEventMouseButton mouseEvent &&
        mouseEvent.ButtonIndex == MouseButton.Left &&
        mouseEvent.Pressed) {

      if (_spawnedCreature.CurrentScreen == CurrentScreen.Nowhere) {
        return;
      }

      Root.Instance.UpdateCurrentScreen(
        _spawnedCreature.CurrentScreen switch {
          CurrentScreen.Exterior => GameScreen.Exterior,
          CurrentScreen.Interior => GameScreen.Restaurant,
          CurrentScreen.Nowhere => GameScreen.Rolodex,
        }
      );
    }
  }

  public override void _Process(double delta) {
  }

  public void Update(SpawnedCreature creature) {
    var title = Nodes.Popover_MarginContainer_VBoxContainer_Title;
    var status = Nodes.Popover_MarginContainer_VBoxContainer_Status;
    var description = Nodes.Popover_MarginContainer_VBoxContainer_Description;
    var location = Nodes.Popover_MarginContainer_VBoxContainer_Location;

    title.Text = creature.Creature.Name;
    description.Text = creature.Creature.Description;
    status.Text = creature.State switch {
      CreatureState.NotSpawnedYet => "Coming to Dinernb",
      CreatureState.WalkToEntrance => "Exterior of Dinernb",
      CreatureState.WaitToBeAdmitted => "Waiting to be admitted",
      CreatureState.WalkInside => "Walking inside",
      CreatureState.WaitForTable => "Waiting for table",
      CreatureState.WalkToTable => "Walking to table",
      CreatureState.SittingAtTable => "Sitting at table",
    };

    Color = creature.State switch {
      CreatureState.NotSpawnedYet => Colors.Red,
      CreatureState.WalkToEntrance => Colors.Orange,
      CreatureState.WaitToBeAdmitted => Colors.Yellow,
      CreatureState.WalkInside => Colors.Green,
      CreatureState.WaitForTable => Colors.Green,
      CreatureState.WalkToTable => Colors.Green,
      CreatureState.SittingAtTable => Colors.Green,
    };

    location.Text = creature.CurrentScreen switch {
      CurrentScreen.Exterior => "Outside",
      CurrentScreen.Interior => "Inside",
      CurrentScreen.Nowhere => "Nowhere",
    };
  }
}
