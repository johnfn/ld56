using Godot;
using System;

namespace ld56;

public partial class Cow : Sprite2D {
  public SpawnedCreature SpawnedCreature { get; set; }

  public override void _Ready() {
    Nodes.HoverPanelExterior.Initialize(SpawnedCreature);
  }

  public override void _Process(double delta) {
  }
}
