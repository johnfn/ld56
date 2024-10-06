using Godot;
using System;

namespace ld56;

public partial class CreatureScene : Node2D {

  // Create a setter that will set the texture to the creature's icon
  private SpawnedCreature _data;
  public SpawnedCreature Data {
    get => _data;
    set {
      _data = value;
      if (value.Creature.Icon != null) {
        Nodes.HoverArea.Icon = value.Creature.Icon;
      }
    }
  }

  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed) {
      if (
        Nodes.HoverPanelExterior.Visible &&
        !Nodes.HoverArea.GetGlobalRect().HasPoint(GetGlobalMousePosition())
        && !Nodes.HoverPanelExterior.GetGlobalRect().HasPoint(GetGlobalMousePosition())
      ) {
        Nodes.HoverPanelExterior.Visible = false;
      }
    }
  }

  public void Initialize(SpawnedCreature data) {
    Data = data;
    Nodes.NameContainer_MarginContainer_NameLabel.Text = data.Creature.Name;
  }

  public override void _Ready() {
    Nodes.HoverPanelExterior.SpawnedCreature = Data;

    // Show the hover panel on click
    Nodes.HoverArea.Pressed += () => {
      Nodes.HoverPanelExterior.Visible = !Nodes.HoverPanelExterior.Visible;
    };

    Nodes.HoverArea.MouseEntered += () => {
      (Nodes.HoverArea.Material as ShaderMaterial).Set("shader_parameter/width", 10.0);
    };

    Nodes.HoverArea.MouseExited += () => {
      (Nodes.HoverArea.Material as ShaderMaterial).Set("shader_parameter/width", 0.0);
    };
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
  }
}
