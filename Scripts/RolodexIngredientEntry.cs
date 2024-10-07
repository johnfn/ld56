using Godot;
using System;
using ld56;
using System.Linq;

using static Utils;

public partial class RolodexIngredientEntry : PanelContainer {
  private Ingredient _ingredientData;

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
    var numUsedInCooking = CookingScreen.CookingList.Count(id => id == _ingredientData.Id);

    if (GameState.Mode == GameMode.Cooking) {
      quantity -= numUsedInCooking;
    }

    Nodes.HBoxContainer_TextureRect_Quantity.Text = $"x {quantity}";
  }

  public void Initialize(Ingredient ingredientData) {
    _ingredientData = ingredientData;

    if (ingredientData.Icon != null) {
      Nodes.HBoxContainer_TextureRect.Texture = ingredientData.Icon;
    }

    Nodes.HBoxContainer_TextContainer_Name.Text = ingredientData.DisplayName;
    Nodes.HBoxContainer_TextContainer_Description.Text = ingredientData.Description;
  }
}
