using Godot;
using ld56;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using static Utils;

public partial class CookingScreen : Sprite2D {
  private Dictionary<IngredientId, CookingIngredient> idToIngredient = [];
  private List<IngredientId> cookingList = [];
  public static CookingScreen Instance { get; private set; }

  public override void _Ready() {
    Instance = this;

    Nodes.CookingResultModal.Visible = false;

    Initialize();
  }

  public static async Task<Recipe> Cook() {
    if (GameState.HYPERSPEED) {
      return AllRecipes.ScrambledEggs;
    }

    Root.Instance.UpdateCurrentScreen(GameScreen.Cooking);

    await Instance.Initialize();

    var hasPressedCook = false;
    Instance.Nodes.Button.Pressed += () => hasPressedCook = true;

    while (!hasPressedCook) {
      await Instance.ToSignal(Instance.GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    // TODO: Some sort of logic to figure out what we made.
    var result = AllRecipes.ScrambledEggs;

    Instance.ShowCookingCompleteModal(result);

    // wait for user to close the modal
    var hasClosed = false;
    Instance.Nodes.CookingResultModal.OnClose += () => hasClosed = true;

    while (!hasClosed) {
      await Instance.ToSignal(Instance.GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    Root.Instance.UpdateCurrentScreen(GameScreen.Restaurant);

    return result;
  }

  public async Task Initialize() {
    // This is only for the debug case where you start the game with
    // CookingScreen visible. If this is giving issues, we can remove it.
    await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

    var allIngredients = GameState.OwnedIngredients;

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

          cookingList.Add(ingredientName);
        }
      };

      idToIngredient[ingredientName] = cookingIngredient;
    }

  }

  private void ShowCookingCompleteModal(Recipe result) {
    Nodes.CookingResultModal.Visible = true;
    Nodes.CookingResultModal.Nodes.HBoxContainer_Title.Text = result.DisplayName;
    Nodes.CookingResultModal.Nodes.HBoxContainer_Description.Text = result.Description;

    foreach (var ingredient in cookingList) {
      var ownedIngredients = GameState.OwnedIngredients;
      var ingredientToRemove = ownedIngredients.FirstOrDefault(x => x.Id == ingredient);

      if (ingredientToRemove != null) {
        ownedIngredients.Remove(ingredientToRemove);
      }
    }

  }
}
