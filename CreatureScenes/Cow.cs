using Godot;
using System;

namespace ld56;

public partial class Cow : Sprite2D {
  public SpawnedCreature SpawnedCreature { get; set; }

  public override void _Ready() {
    Nodes.HoverPanelExterior.Clicked += () => {
      Root.Instance.Nodes.AnimalManager.Admit(SpawnedCreature);
    };
  }

  public override void _Process(double delta) {
  }
}
