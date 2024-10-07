using Godot;
using System;
using System.Collections.Generic;

namespace ld56;
using static Utils;

public partial class Shop : ColorRect {
  public override void _Ready() {
  }

  public override void _Process(double delta) {
  }

  public void Initialize(List<Ingredient> displayedIngredients) {
    var shopList = Nodes.PanelContainer_HBoxContainer_VBoxContainer2_ShopInventoryList;
    var ownedList = Nodes.PanelContainer_HBoxContainer_VBoxContainer2_InventoryList;

    shopList.Initialize(displayedIngredients);
    ownedList.Initialize(GameState.OwnedIngredients);

    if (displayedIngredients.Count == 0) {
      Nodes.PanelContainer_HBoxContainer_VBoxContainer2_NoneForSale.Visible = true;
    } else {
      Nodes.PanelContainer_HBoxContainer_VBoxContainer2_NoneForSale.Visible = false;
    }

    shopList.OnMouseEnterIngredient += (ingredientId) => {
      shopList.ShowTooltip(ingredientId, AllIngredients.Ingredients.Find(i => i.Id == ingredientId));
    };

    shopList.OnMouseExitIngredient += (ingredientId) => {
      shopList.HideTooltip(ingredientId);
    };

    shopList.OnClickIngredient += (ingredientId) => {
      var ingredient = AllIngredients.Ingredients.Find(i => i.Id == ingredientId);
      if (GameState.Gold >= ingredient.Cost) {
        GameState.Gold -= ingredient.Cost;
        GameState.OwnedIngredients.Add(ingredient);

        var newDisplayedIngredients = new List<Ingredient>(displayedIngredients);
        newDisplayedIngredients.Remove(ingredient);

        Initialize(newDisplayedIngredients);
      } else {
        GenericDialog.Instance.Show("You don't have enough gold to buy that!");
      }
    };

    ownedList.OnMouseEnterIngredient += (ingredientId) => {
      ownedList.ShowTooltip(ingredientId, AllIngredients.Ingredients.Find(i => i.Id == ingredientId));
    };

    ownedList.OnMouseExitIngredient += (ingredientId) => {
      ownedList.HideTooltip(ingredientId);
    };

  }
}
