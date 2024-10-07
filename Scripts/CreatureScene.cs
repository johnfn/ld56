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
        !Nodes.VBoxContainer_TextureRect.GetGlobalRect().HasPoint(GetGlobalMousePosition())
        && !Nodes.HoverPanelExterior.GetGlobalRect().HasPoint(GetGlobalMousePosition())
      ) {
        Nodes.HoverPanelExterior.Visible = false;
      }
    }
  }

  public void Initialize(SpawnedCreature data) {
    Data = data;
    if (data.Data.FullBodyTexture != null) {
      Nodes.VBoxContainer_TextureRect.Icon = data.Data.FullBodyTexture;
    }
    Nodes.VBoxContainer_NameLabel.Text = data.Data.DisplayName;
    // Move the name's X coordinate over so it's centered
    Nodes.VBoxContainer_NameLabel.Position = new Vector2(-Nodes.VBoxContainer_NameLabel.Size.X / 2, Nodes.VBoxContainer_NameLabel.Position.Y);
  }

  public override void _Ready() {
    Nodes.HoverPanelExterior.SpawnedCreature = Data;

    // Show the hover panel on click
    // Nodes.TextureRect_HoverArea.Pressed += () => {
    //   Nodes.HoverPanelExterior.Visible = !Nodes.HoverPanelExterior.Visible;
    // };

    Nodes.VBoxContainer_TextureRect.Pressed += OnClick;

    Nodes.VBoxContainer_TextureRect.MouseEntered += () => {
      (Nodes.VBoxContainer_TextureRect.Material as ShaderMaterial).Set("shader_parameter/width", 10.0);
    };

    Nodes.VBoxContainer_TextureRect.MouseExited += () => {
      (Nodes.VBoxContainer_TextureRect.Material as ShaderMaterial).Set("shader_parameter/width", 0.0);
    };


  }

  private void OnClick() {
    if (Data.State == CreatureState.WaitToBeAdmitted) {
      Root.Instance.Nodes.AnimalManager.Admit(Data);
    } else if (Data.State == CreatureState.WaitForTable) {
      Root.Instance.Nodes.AnimalManager.Sit(Data);
    } else if (Data.State == CreatureState.WaitForTalk) {
      Root.Instance.Nodes.AnimalManager.StartDialog(Data);
    }
  }
}
