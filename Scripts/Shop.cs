using Godot;
using System;
using System.Collections.Generic;

namespace ld56;

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
      shopList.ShowTooltip(ingredientId, new TooltipInfo(
        Name: "Egg",
        Description: "A delicious egg. Yum!"
      ));
    };

    shopList.OnMouseExitIngredient += (ingredientId) => {
      shopList.HideTooltip(ingredientId);
    };
  }
}
