using Godot;
using System;
using ld56;
using System.Linq;

using static Utils;

public partial class RolodexIngredientEntry : PanelContainer {
  private Ingredient _ingredientData;
  private bool _isClickable;

  public override void _Ready() {
    Nodes.HBoxContainer_TextureRect_AddLabel.Visible = false;

    if (_isClickable && GameState.OwnedIngredients.Count(i => i.Id == _ingredientData.Id) > 0) {
      this.Nodes.Button.Pressed += () => {
        Root.Instance.Nodes.SoundManager.PlayButtonPressSFX();
      };

      this.Nodes.Button.MouseEntered += () => {
        this.Scale = this.Scale * 1.1f;
        Root.Instance.Nodes.SoundManager.PlayHoverSFX();
        Nodes.HBoxContainer_TextureRect_AddLabel.Visible = true;
      };

      this.Nodes.Button.MouseExited += () => {
        this.Scale = this.Scale / 1.1f;
        Nodes.HBoxContainer_TextureRect_AddLabel.Visible = false;
      };

    }
  }

  public override void _Process(double delta) {
    var quantity = GameState.OwnedIngredients.Count(i => i.Id == _ingredientData.Id);
    var numUsedInCooking = CookingScreen.CookingList.Count(id => id == _ingredientData.Id);

    if (GameState.Mode == GameMode.Cooking) {
      quantity -= numUsedInCooking;
    }

    Nodes.Quantity.Text = $"x {quantity} ";
    if (quantity == 0) {
      Nodes.Quantity.AddThemeColorOverride("font_color", new Color(0, 0, 0, 0.5f));
    } else {
      Nodes.Quantity.AddThemeColorOverride("font_color", new Color(0, 0, 0, 1));
    }
  }

  public void Initialize(Ingredient ingredientData, bool isClickable) {
    _ingredientData = ingredientData;

    if (ingredientData.Icon != null) {
      Nodes.HBoxContainer_TextureRect.Texture = ingredientData.Icon;
    }

    _isClickable = isClickable;

    Nodes.HBoxContainer_TextContainer_Name.Text = ingredientData.DisplayName;
    Nodes.HBoxContainer_TextContainer_Description.Text = ingredientData.Description;
  }
}
