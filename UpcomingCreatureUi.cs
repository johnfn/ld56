using Godot;
using System;

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
    Nodes.Popover_MarginContainer_VBoxContainer_Title.Text = creature.Creature.Name;
    Nodes.Popover_MarginContainer_VBoxContainer_Description.Text = creature.Creature.Description;
  }
}
