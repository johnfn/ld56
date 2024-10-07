using Godot;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Utils;

namespace ld56;

public partial class CookingScreen : Sprite2D {
  private Dictionary<IngredientId, CookingIngredient> idToIngredient = [];
  private static List<IngredientId> cookingList = [];
  public static CookingScreen Instance { get; private set; }

  public override void _Ready() {
    Instance = this;

    Nodes.UI_CookingResultModal.Visible = false;

    Nodes.UI_IngredientsButton_IngredientsTooltip.Visible = false;
    Nodes.UI_RecipesButton_RecipesTooltip.Visible = false;

    Nodes.UI_IngredientsButton.MouseEntered += () => {
      Nodes.UI_IngredientsButton_IngredientsTooltip.Visible = true;
    };

    Nodes.UI_IngredientsButton.MouseExited += () => {
      Nodes.UI_IngredientsButton_IngredientsTooltip.Visible = false;
    };

    Nodes.UI_RecipesButton.MouseEntered += () => {
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
      Cook();
    };

    Initialize();
  }

  public static async Task<Recipe> Cook() {
    if (GameState.HYPERSPEED) {
      return AllRecipes.ScrambledEggs;
    }

    Root.Instance.UpdateCurrentScreen(GameScreen.Cooking);

    await Instance.Initialize();

    var hasPressedCook = false;
    Instance.Nodes.UI_CookButton.Pressed += () => hasPressedCook = true;

    while (!hasPressedCook) {
      await Instance.ToSignal(Instance.GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    // TODO: Some sort of logic to figure out what we made.
    var result = AllRecipes.ScrambledEggs;

    // TODO: Remove them from the inventory.
    cookingList.ForEach(id => GameState.OwnedIngredients.Remove(AllIngredients.Get(id)));

    Instance.ShowCookingCompleteModal(result);

    // wait for user to close the modal
    var hasClosed = false;
    Instance.Nodes.UI_CookingResultModal.OnClose += () => hasClosed = true;

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

    Rolodex.Instance.OnClickIngredient += (ingredientId) => {
      cookingList.Add(ingredientId);
      var ingredient = AllIngredients.Get(ingredientId);
      var ingredientListItem = CookingIngredient.New();

      Nodes.UI_IngredientSlotsTexture_Container.AddChild(ingredientListItem);
      ingredientListItem.Pressed += () => {
        cookingList.Remove(ingredientId);
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

    foreach (var ingredient in cookingList) {
      var ownedIngredients = GameState.OwnedIngredients;
      var ingredientToRemove = ownedIngredients.FirstOrDefault(x => x.Id == ingredient);

      if (ingredientToRemove != null) {
        ownedIngredients.Remove(ingredientToRemove);
      }
    }
  }
}
