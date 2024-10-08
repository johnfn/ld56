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
    };

    Initialize();
  }

  public static async Task<Recipe> Cook(
    CreatureId diner,
    List<IngredientId>? desiredIngredients = null,
    Dictionary<MealQuality, List<IDialogItem>>? mealResponses = null
  ) {
    desiredIngredients ??= [];
    mealResponses ??= AllDialog.MealResponse;

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

    var isNewRecipe = !GameState.KnownRecipes.Any(r => r.DisplayName == result.DisplayName);
    if (isNewRecipe) {
      GameState.KnownRecipes.Add(result);
    }

    Instance.ShowCookingCompleteModal(result, isNewRecipe);

    // wait for user to close the modal
    var hasClosed = false;
    Instance.Nodes.UI_CookingResultModal.OnClose += () => hasClosed = true;

    while (!hasClosed) {
      await Instance.ToSignal(Instance.GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    Instance.Nodes.UI_CookingResultModal.Visible = false;

    Root.Instance.UpdateCurrentScreen(GameScreen.Restaurant);

    // Grade the results

    var copiedList = result.Ingredients.ToList();
    var copiedDesiredIngredients = desiredIngredients.ToList();

    var numCorrect = 0;

    foreach (var ingredient in copiedList) {
      if (copiedDesiredIngredients.Any(id => id == ingredient.Id)) {
        var match = copiedDesiredIngredients.FirstOrDefault(id => id == ingredient.Id);

        numCorrect++;
        copiedDesiredIngredients.Remove(match);
      }
    }

    var grade = MealQuality.Miss;

    if (numCorrect == desiredIngredients.Count) {
      grade = MealQuality.Perfect;
    } else if (numCorrect > 0) {
      grade = MealQuality.Close;
    } else {
      grade = MealQuality.Miss;
    }

    if (desiredIngredients.Count == 0) {
      grade = MealQuality.Perfect;
    }

    GameState.Mode = GameMode.Dialog;
    await DialogBox.ShowDialog([
      new DialogItem { Text = $"Here's your {result.DisplayName}!", Speaker = CreatureId.You },
      new DialogItem { Text = "(...they begin eating...)", Speaker = diner },
      ..mealResponses[grade]
    ], CreatureId.You, true);
    GameState.Mode = GameMode.Cooking;

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
      ingredientListItem.Nodes.TextureRect_PanelContainer_MarginContainer_QuantityLabel.Visible = false;
      ingredientListItem.Nodes.TextureRect.Texture = ingredient.Icon;
      ingredientListItem.SelfModulate = new Color(1, 1, 1, 0f);
      ingredientListItem.Nodes.TextureRect_PanelContainer.Visible = false;

      Nodes.UI_IngredientSlotsTexture_Container.AddChild(ingredientListItem);
      ingredientListItem.Pressed += () => {
        CookingList.Remove(ingredientId);
        Nodes.UI_IngredientSlotsTexture_Container.RemoveChild(ingredientListItem);
      };

      ingredientListItem.Nodes.TextureRect_NameLabel.Text = ingredient.DisplayName;
    };
  }

  private void ShowCookingCompleteModal(Recipe result, bool isNewRecipe) {
    Nodes.UI_CookingResultModal.Visible = true;
    Nodes.UI_CookingResultModal.Nodes.RecipeAddedLabel.Visible = isNewRecipe;

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

    CookingList.Clear();
  }
}
