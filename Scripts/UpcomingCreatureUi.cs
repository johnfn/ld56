using Godot;
using System;
using System.Diagnostics;

namespace ld56;

public partial class UpcomingCreatureUi : TextureRect {
  private SpawnedCreature _spawnedCreature;

  public void Initialize(SpawnedCreature spawnedCreature) {
    _spawnedCreature = spawnedCreature;
    this.Texture = spawnedCreature.Data.Icon;
  }

  public override void _Ready() {
    Nodes.Popover.Visible = false;
    Nodes.Checkmark.Visible = false;

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

      if (_spawnedCreature.CurrentScreen == CurrentScreen.Interior) {
        Root.Instance.UpdateCurrentScreen(GameScreen.Restaurant);
      } else if (_spawnedCreature.CurrentScreen == CurrentScreen.Exterior) {
        Root.Instance.UpdateCurrentScreen(GameScreen.Exterior);
      } else {
        Root.Instance.ToggleRolodex();
      }
    }

  }

  public override void _Process(double delta) {
  }

  public void Update(SpawnedCreature creature) {
    var title = Nodes.Popover_MarginContainer_VBoxContainer_Title;
    var status = Nodes.Popover_MarginContainer_VBoxContainer_Status;
    var description = Nodes.Popover_MarginContainer_VBoxContainer_Description;
    var location = Nodes.Popover_MarginContainer_VBoxContainer_Location;

    title.Text = creature.Data.DisplayName;
    description.Text = creature.Data.Description;

    var (timeString, period) = Clock.GetTimeString(creature.ReservationTime);

    status.Text = creature.State switch {
      CreatureState.NotSpawnedYet => $"Arriving at {timeString} {period}",
      CreatureState.WalkToEntrance => "Exterior of Dinernb",
      CreatureState.WaitToBeAdmitted => "Waiting to be admitted",
      CreatureState.WalkInside => "Walking inside",
      CreatureState.WaitForTable => "Waiting for table",
      CreatureState.WalkToTable => "Walking to table",
      CreatureState.WaitForTalk => "Sitting at table",
      CreatureState.WalkToExit => "Walking to exit",
      CreatureState.WaitForEveryoneToFinish => "Politely waiting for everyone to finish",
      CreatureState.Done => "Leaving",
    };

    location.Text = creature.CurrentScreen switch {
      CurrentScreen.Exterior => "Outside",
      CurrentScreen.Interior => "Inside",
      CurrentScreen.Nowhere => "Nowhere",
    };

    if (creature.State == CreatureState.NotSpawnedYet) {
      SelfModulate = new Color(0.5f, 0.5f, 0.5f, 1);
    } else {
      SelfModulate = new Color(1, 1, 1, 1);
    }

    if (creature.State == CreatureState.WaitForEveryoneToFinish) {
      Nodes.Checkmark.Visible = true;
    }
  }
}
