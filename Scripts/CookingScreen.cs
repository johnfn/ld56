using Godot;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Utils;

namespace ld56;

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

    foreach (var child in Nodes.CookingList.GetChildren()) {
      child.QueueFree();
    }

    Nodes.InventoryList.Initialize(GameState.OwnedIngredients);

    Nodes.InventoryList.ClearListeners();
    Nodes.InventoryList.OnClickIngredient += (ingredientId) => {
      var success = Nodes.InventoryList.RemoveItemFromList(ingredientId);

      if (success) {
        cookingList.Add(ingredientId);

        var ingredient = AllIngredients.Get(ingredientId);
        var ingredientListItem = CookingIngredient.New();

        Nodes.CookingList.AddChild(ingredientListItem);

        ingredientListItem.Nodes.Container_NameLabel.Text = ingredient.DisplayName;
      } else {
        // TODO: Show error somehow
      }
    };
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
