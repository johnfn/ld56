using Godot;
using System;

namespace ld56;

public partial class CreatureScene : Node2D {

  private SpawnedCreature _data;
  public SpawnedCreature Data;

  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed) {
      if (
        Nodes.HoverPanelExterior.Visible &&
        !Nodes.TextureRect.GetGlobalRect().HasPoint(GetGlobalMousePosition())
        && !Nodes.HoverPanelExterior.GetGlobalRect().HasPoint(GetGlobalMousePosition())
      ) {
        Nodes.HoverPanelExterior.Visible = false;
      }
    }
  }

  public void Initialize(SpawnedCreature data) {
    Data = data;
    if (data.Creature.FullBodyTexture != null) {
      Nodes.TextureRect.Texture = data.Creature.FullBodyTexture;
    }
    Nodes.NameLabel.Text = data.Creature.Name;
    // Move the name's X coordinate over so it's centered
    Nodes.NameLabel.Position = new Vector2(-Nodes.NameLabel.Size.X / 2, Nodes.NameLabel.Position.Y);
  }

  public override void _Ready() {
    Nodes.HoverPanelExterior.SpawnedCreature = Data;

    // Show the hover panel on click
    Nodes.TextureRect_HoverArea.Pressed += () => {
      Nodes.HoverPanelExterior.Visible = !Nodes.HoverPanelExterior.Visible;
    };

    Nodes.TextureRect.MouseEntered += () => {
      (Nodes.TextureRect.Material as ShaderMaterial).Set("shader_parameter/width", 10.0);
    };

    Nodes.TextureRect.MouseExited += () => {
      (Nodes.TextureRect.Material as ShaderMaterial).Set("shader_parameter/width", 0.0);
    };
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
  }
}
