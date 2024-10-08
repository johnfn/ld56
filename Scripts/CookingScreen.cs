using Godot;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Utils;

namespace ld56;

public partial class CookingScreen : Sprite2D {
  private Dictionary<IngredientId, CookingIngredient> idToIngredient = [];
  public static List<IngredientId> CookingList = [];
  public static CookingScreen Instance { get; private set; }
  private static bool _hasPressedCook = false;

  public override void _Ready() {
    Instance = this;

    Nodes.UI_CookingResultModal.Visible = false;

    Nodes.UI_IngredientsButton_IngredientsTooltip.Visible = false;
    Nodes.UI_RecipesButton_RecipesTooltip.Visible = false;

    Nodes.UI_IngredientsButton.MouseEntered += () => {
      Root.Instance.Nodes.SoundManager.PlayHoverSFX();
      Nodes.UI_IngredientsButton_IngredientsTooltip.Visible = true;
    };

    Nodes.UI_IngredientsButton.MouseExited += () => {
      Nodes.UI_IngredientsButton_IngredientsTooltip.Visible = false;
    };

    Nodes.UI_RecipesButton.MouseEntered += () => {
      Root.Instance.Nodes.SoundManager.PlayHoverSFX();
      Nodes.UI_RecipesButton_RecipesTooltip.Visible = true;
    };

    Nodes.UI_RecipesButton.MouseExited += () => {
      Nodes.UI_RecipesButton_RecipesTooltip.Visible = false;
    };

    Nodes.UI_IngredientsButton.Pressed += () => {
      Rolodex.Instance.Show();
      Rolodex.Instance.ChangeTab(Rolodex.RolodexTab.Ingredients);
    };

    Nodes.UI_RecipesButton.Pressed += () => {
      Rolodex.Instance.Show();
      Rolodex.Instance.ChangeTab(Rolodex.RolodexTab.Recipes);
    };

    Nodes.UI_CookButton.Pressed += () => {
      if (CookingList.Count == 0) {
        GenericDialog.Instance.Show("First, add some ingredients!");
        return;
      }

      _hasPressedCook = true;
      Cook();
    };

    Initialize();
  }

  public static async Task<Recipe> Cook(
    List<IngredientId>? desiredIngredients = null,
    Dictionary<MealQuality, MealResult>? mealResults = null
  ) {
    desiredIngredients ??= [];

    // if (GameState.HYPERSPEED) {
    //   return AllRecipes.ScrambledEggs;
    // }

    var prevMode = GameState.Mode;
    GameState.Mode = GameMode.Cooking;

    Root.Instance.UpdateCurrentScreen(GameScreen.Cooking);

    await Instance.Initialize();

    _hasPressedCook = false;

    while (!_hasPressedCook) {
      await Instance.ToSignal(Instance.GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    _hasPressedCook = false;

    var matchingRecipes = AllRecipes.Recipes.Where(r => r.Ingredients.All(ing => CookingList.Contains(ing.Id))).ToList();
    // sort by length of recipe, most first
    matchingRecipes.Sort((a, b) => b.Ingredients.Count.CompareTo(a.Ingredients.Count));

    var result = matchingRecipes.FirstOrDefault(
      AllRecipes.WhatTrashSoup
    );

    CookingList.ForEach(id => GameState.OwnedIngredients.Remove(AllIngredients.Ingredients.Find(i => i.Id == id)));

    Instance.ShowCookingCompleteModal(result);

    // wait for user to close the modal
    var hasClosed = false;
    Instance.Nodes.UI_CookingResultModal.OnClose += () => hasClosed = true;

    while (!hasClosed) {
      await Instance.ToSignal(Instance.GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    Root.Instance.UpdateCurrentScreen(GameScreen.Restaurant);

    GameState.Mode = prevMode;

    return result;
  }

  public async Task Initialize() {
    // This is only for the debug case where you start the game with
    // CookingScreen visible. If this is giving issues, we can remove it.

    await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

    foreach (var child in Nodes.UI_IngredientSlotsTexture_Container.GetChildren()) {
      child.QueueFree();
    }

    Rolodex.Instance.ClearSignals();

    Rolodex.Instance.OnClickIngredient += (ingredientId) => {
      if (GameState.Mode != GameMode.Cooking) {
        // apparently, this can always happen.
        return;
      }

      if (CookingList.Count >= 5) {
        GenericDialog.Instance.Show("You can only cook with 5 ingredients at a time!");
        return;
      }

      var numOwned = GameState.OwnedIngredients.Count(i => i.Id == ingredientId);
      var numCurrentlyUsed = CookingList.Count(id => id == ingredientId);

      if (numOwned <= numCurrentlyUsed) {
        GenericDialog.Instance.Show("You don't have any left!");
        return;
      }

      CookingList.Add(ingredientId);
      var ingredient = AllIngredients.Ingredients.Find(i => i.Id == ingredientId);
      var ingredientListItem = CookingIngredient.New();
      ingredientListItem.Nodes.PanelContainer_MarginContainer_QuantityLabel.Visible = false;
      ingredientListItem.Nodes.IngredientImage.Texture = ingredient.Icon;

      Nodes.UI_IngredientSlotsTexture_Container.AddChild(ingredientListItem);
      ingredientListItem.Pressed += () => {
        CookingList.Remove(ingredientId);
        Nodes.UI_IngredientSlotsTexture_Container.RemoveChild(ingredientListItem);
      };

      ingredientListItem.Nodes.NameLabel.Text = ingredient.DisplayName;
    };
  }

  private void ShowCookingCompleteModal(Recipe result) {
    Nodes.UI_CookingResultModal.Visible = true;

    if (result.Icon != null) {
      Nodes.UI_CookingResultModal.Nodes.TextureRect.Texture = result.Icon;
    }

    Nodes.UI_CookingResultModal.Nodes.MealNameLabel.Text = result.DisplayName;

    foreach (var ingredient in CookingList) {
      var ownedIngredients = GameState.OwnedIngredients;
      var ingredientToRemove = ownedIngredients.FirstOrDefault(x => x.Id == ingredient);

      if (ingredientToRemove != null) {
        ownedIngredients.Remove(ingredientToRemove);
      }
    }
  }
}
