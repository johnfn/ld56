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
  }

  public override void _Process(double delta) {
  }

  public void Update(SpawnedCreature creature) {
    var title = Nodes.Popover_MarginContainer_VBoxContainer_Title;
    var status = Nodes.Popover_MarginContainer_VBoxContainer_Status;
    var description = Nodes.Popover_MarginContainer_VBoxContainer_Description;

    title.Text = creature.Creature.Name;
    description.Text = creature.Creature.Description;
    status.Text = creature.State switch {
      CreatureState.NotSpawnedYet => "Coming to Dinernb",
      CreatureState.WalkToEntrance => "Exterior of Dinernb",
      CreatureState.WaitToBeAdmitted => "Waiting to be admitted",
      CreatureState.WalkToTable => "Walking to their table",
    };
  }
}
