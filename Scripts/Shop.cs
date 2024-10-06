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

    shopList.OnMouseEnterIngredient += (ingredientId) => {
      shopList.ShowTooltip(ingredientId, AllIngredients.Get(ingredientId));
    };

    shopList.OnMouseExitIngredient += (ingredientId) => {
      shopList.HideTooltip(ingredientId);
    };

    shopList.OnClickIngredient += (ingredientId) => {
      GD.Print($"About to buy {ingredientId}");

      var ingredient = AllIngredients.Get(ingredientId);
      if (GameState.Gold >= ingredient.Cost) {
        GD.Print($"Bought {ingredientId} for {ingredient.Cost} gold");

        GameState.Gold -= ingredient.Cost;
        GameState.OwnedIngredients.Add(ingredient);

        var newDisplayedIngredients = new List<Ingredient>(displayedIngredients);
        newDisplayedIngredients.Remove(ingredient);

        print(newDisplayedIngredients);
        Initialize(newDisplayedIngredients);
      } else {
        // TODO: Too expensive
      }
    };
  }
}
