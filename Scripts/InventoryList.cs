using Godot;
using System;
using System.Collections.Generic;

namespace ld56;

public partial class InventoryList : GridContainer {
  public event Action<IngredientId> OnClickIngredient;

  private Dictionary<IngredientId, int> ingredientCounts = [];
  private Dictionary<IngredientId, CookingIngredient> idToIngredientListItem = [];

  public void Initialize(List<Ingredient> displayedIngredients) {
    foreach (var child in GetChildren()) {
      child.QueueFree();
    }

    foreach (var ingredient in displayedIngredients) {
      if (ingredientCounts.TryGetValue(ingredient.Id, out int value)) {
        ingredientCounts[ingredient.Id] = ++value;
      } else {
        ingredientCounts[ingredient.Id] = 1;
      }
    }

    foreach (var (ingredientId, count) in ingredientCounts) {
      var ingredient = AllIngredients.Get(ingredientId);
      var ingredientListItem = CookingIngredient.New();

      AddChild(ingredientListItem);

      ingredientListItem.Nodes.Container_NameLabel.Text = ingredient.DisplayName;
      ingredientListItem.Nodes.Container_QuantityLabel.Text = "x" + count.ToString();

      ingredientListItem.OnClick += (ingredient) => {
        OnClickIngredient?.Invoke(ingredientId);
      };

      idToIngredientListItem[ingredientId] = ingredientListItem;
    }
  }

  public void ClearListeners() {
    OnClickIngredient = null;
  }

  public bool RemoveItemFromList(IngredientId ingredientId) {
    var quantity = ingredientCounts[ingredientId];

    if (quantity > 0) {
      quantity--;
      ingredientCounts[ingredientId] = quantity;
      idToIngredientListItem[ingredientId].Nodes.Container_QuantityLabel.Text = "x" + quantity.ToString();

      return true;
    } else {
      return false;
    }
  }
}
