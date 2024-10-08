using Godot;
using System;

namespace ld56;

public partial class CreatureScene : Node2D {
  private SpawnedCreature _data;
  public SpawnedCreature Data;

  public override void _Ready() {
    Nodes.HoverPanelExterior.SpawnedCreature = Data;

    // Show the hover panel on click
    // Nodes.TextureRect_HoverArea.Pressed += () => {
    //   Nodes.HoverPanelExterior.Visible = !Nodes.HoverPanelExterior.Visible;
    // };

    Nodes.TextureRect.Pressed += OnClick;

    Nodes.TextureRect.MouseEntered += () => {
      Root.Instance.Nodes.SoundManager.PlayHoverSFX();
      (Nodes.TextureRect.Material as ShaderMaterial).Set("shader_parameter/width", 10.0);
    };

    Nodes.TextureRect.MouseExited += () => {
      (Nodes.TextureRect.Material as ShaderMaterial).Set("shader_parameter/width", 0.0);
    };

    Nodes.PanelContainer.Visible = false;

    Nodes.TextureRect.MouseEntered += () => {
      Root.Instance.Nodes.SoundManager.PlayHoverSFX();
      Nodes.PanelContainer.Visible = true;
    };

    Nodes.TextureRect.MouseExited += () => {
      Nodes.PanelContainer.Visible = false;
    };
  }

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
    if (data.Data.FullBodyTexture != null) {
      Nodes.TextureRect.Icon = data.Data.FullBodyTexture;
    }
    Nodes.PanelContainer_MarginContainer_NameLabel.Text = data.Data.DisplayName;
    // Move the name's X coordinate over so it's centered
    Nodes.PanelContainer_MarginContainer_NameLabel.Position = new Vector2(-Nodes.PanelContainer_MarginContainer_NameLabel.Size.X / 2, Nodes.PanelContainer_MarginContainer_NameLabel.Position.Y);
  }


  private void OnClick() {
    if (Data.State == CreatureState.WaitToBeAdmitted) {
      Root.Instance.Nodes.AnimalManager.Admit(Data);
    } else if (Data.State == CreatureState.WaitForTable) {
      Root.Instance.Nodes.AnimalManager.Sit(Data);
    } else if (Data.State == CreatureState.WaitForTalk) {
      Root.Instance.Nodes.AnimalManager.StartDialog(Data);
    } else if (Data.State == CreatureState.WaitForEveryoneToFinish) {
      GenericDialog.Instance.Show($"{Data.Data.DisplayName} is satisfied, and is waiting for everyone else at the table to finish eating.");
    }
  }

  public override void _Process(double delta) {
  }
}
