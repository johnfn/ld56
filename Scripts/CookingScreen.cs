using Godot;
using ld56;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static Utils;

public partial class CookingScreen : Sprite2D {
  private Dictionary<IngredientId, CookingIngredient> idToIngredient = [];

  public override void _Ready() {
    Initialize();
  }

  public async void Initialize() {
    await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

    var allIngredients = Root.Instance.Nodes.Rolodex.OwnedIngredients;

    var ingredientCounts = new Dictionary<IngredientId, int>();

    foreach (var ingredient in allIngredients) {
      if (ingredientCounts.TryGetValue(ingredient.Id, out int value)) {
        ingredientCounts[ingredient.Id] = ++value;
      } else {
        ingredientCounts[ingredient.Id] = 1;
      }
    }

    foreach (var child in Nodes.InventoryList.GetChildren()) {
      child.QueueFree();
    }

    foreach (var child in Nodes.CookingList.GetChildren()) {
      child.QueueFree();
    }

    foreach (var (ingredientName, count) in ingredientCounts) {
      var quantity = count;
      var ingredient = AllIngredients.Get(ingredientName);

      var cookingIngredient = CookingIngredient.New();

      Nodes.InventoryList.AddChild(cookingIngredient);
      cookingIngredient.Nodes.HBoxContainer_MarginContainer_VBoxContainer_NameLabel.Text = ingredient.DisplayName;
      cookingIngredient.Nodes.HBoxContainer_MarginContainer_VBoxContainer_QuantityLabel.Text = "x" + count.ToString();

      cookingIngredient.OnClick += (cookingIngredient) => {
        if (quantity > 0) {
          quantity--;

          cookingIngredient.Nodes.HBoxContainer_MarginContainer_VBoxContainer_QuantityLabel.Text = "x" + quantity.ToString();

          var newIngredient = CookingIngredient.New();
          Nodes.CookingList.AddChild(newIngredient);
          newIngredient.Nodes.HBoxContainer_MarginContainer_VBoxContainer_NameLabel.Text = ingredient.DisplayName;
          newIngredient.Nodes.HBoxContainer_MarginContainer_VBoxContainer_QuantityLabel.Text = "";
        }
      };

      idToIngredient[ingredientName] = cookingIngredient;
    }
  }
}
