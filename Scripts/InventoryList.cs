using Godot;
using System;
using System.Collections.Generic;

namespace ld56;

public record TooltipInfo(string Name, string Description, int Cost);

public partial class InventoryList : GridContainer {
  public event Action<IngredientId> OnClickIngredient;
  public event Action<IngredientId> OnMouseEnterIngredient;
  public event Action<IngredientId> OnMouseExitIngredient;

  private Dictionary<IngredientId, int> ingredientCounts = [];
  private Dictionary<IngredientId, CookingIngredient> idToIngredientListItem = [];

  public void Initialize(List<IngredientData> displayedIngredients) {
    ClearListeners();

    foreach (var child in GetChildren()) {
      child.QueueFree();
    }

    ingredientCounts = [];

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

      ingredientListItem.Nodes.NameLabel.Text = ingredient.DisplayName;
      ingredientListItem.Nodes.QuantityLabel.Text = "x" + count.ToString();

      ingredientListItem.Pressed += () => {
        OnClickIngredient?.Invoke(ingredientId);
      };

      ingredientListItem.MouseEntered += () => {
        OnMouseEnterIngredient?.Invoke(ingredientId);
      };

      ingredientListItem.MouseExited += () => {
        OnMouseExitIngredient?.Invoke(ingredientId);
      };

      idToIngredientListItem[ingredientId] = ingredientListItem;
    }
  }

  public void ClearListeners() {
    OnClickIngredient = null;
    OnMouseEnterIngredient = null;
    OnMouseExitIngredient = null;
  }

  public bool RemoveItemFromList(IngredientId ingredientId) {
    var quantity = ingredientCounts[ingredientId];

    if (quantity > 0) {
      quantity--;
      ingredientCounts[ingredientId] = quantity;
      //idToIngredientListItem[ingredientId].Nodes.Container_QuantityLabel.Text = "x" + quantity.ToString();

      return true;
    } else {
      return false;
    }
  }

  public void ShowTooltip(IngredientId ingredientId, IngredientData ingredient) {
    idToIngredientListItem[ingredientId].Nodes.Tooltip.Visible = true;
    idToIngredientListItem[ingredientId].Nodes.Tooltip_MarginContainer_VBoxContainer_Title.Text = ingredient.DisplayName;
    idToIngredientListItem[ingredientId].Nodes.Tooltip_MarginContainer_VBoxContainer_Description.Text = ingredient.Description;
    idToIngredientListItem[ingredientId].Nodes.Tooltip_MarginContainer_VBoxContainer_Price.Text = "[color=gold]" + ingredient.Cost.ToString() + " gold[/color]";
  }

  public void HideTooltip(IngredientId ingredientId) {
    idToIngredientListItem[ingredientId].Nodes.Tooltip.Visible = false;
  }
}
