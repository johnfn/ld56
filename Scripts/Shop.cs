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
    Nodes.PanelContainer_HBoxContainer_VBoxContainer2_ShopInventoryList.Initialize(displayedIngredients);
    Nodes.PanelContainer_HBoxContainer_VBoxContainer2_InventoryList.Initialize(GameState.OwnedIngredients);
  }
}
