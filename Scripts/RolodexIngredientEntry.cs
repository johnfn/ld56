using Godot;
using System;
using ld56;
using System.Linq;

public partial class RolodexIngredientEntry : PanelContainer {
  private IngredientData _ingredientData;

  public override void _Ready() {
    this.Nodes.Button.Pressed += () => {
      Root.Instance.Nodes.SoundManager.PlayButtonPressSFX();
    };

    this.Nodes.Button.MouseEntered += () => {
      this.Scale = this.Scale * 1.1f;
      Root.Instance.Nodes.SoundManager.PlayHoverSFX();
    };

    this.Nodes.Button.MouseExited += () => {
      this.Scale = this.Scale / 1.1f;
    };
  }

  public override void _Process(double delta) {
    var quantity = GameState.OwnedIngredients.Count(i => i.Id == _ingredientData.Id);

    Nodes.HBoxContainer_TextureRect_Quantity.Text = $"x {quantity}";
  }

  public void Initialize(IngredientData ingredientData) {
    _ingredientData = ingredientData;

    if (ingredientData.Icon != null) {
      Nodes.HBoxContainer_TextureRect.Texture = ingredientData.Icon;
    }

    Nodes.HBoxContainer_TextContainer_Name.Text = ingredientData.DisplayName;
    Nodes.HBoxContainer_TextContainer_Description.Text = ingredientData.Description;
  }
}
