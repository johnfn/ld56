using Godot;
using ld56;
using System;
using System.Linq;

using static Utils;

public partial class Rolodex : ColorRect {
  public event Action<IngredientId> OnClickIngredient;

  public static Rolodex Instance { get; private set; }

  private int Page = 0;
  private int MaxEntriesPerPage = 4;

  public enum RolodexTab {
    Creatures,
    Recipes,
    Ingredients,
  }

  private RolodexTab Tab = RolodexTab.Creatures;

  public override void _Ready() {
    Instance = this;

    PopulatePages();

    Nodes.BookTexture_NextPageButton.Pressed += () => FlipPage(true);
    Nodes.BookTexture_PrevPageButton.Pressed += () => FlipPage(false);

    Nodes.BookTexture_RecipesTab.Pressed += () => ChangeTab(RolodexTab.Recipes);
    Nodes.BookTexture_CreaturesTab.Pressed += () => ChangeTab(RolodexTab.Creatures);
    Nodes.BookTexture_IngredientsTab.Pressed += () => ChangeTab(RolodexTab.Ingredients);

    // Make sure the viewports can handle the input.
    Nodes.BookTexture_PageContents_Page1_Page1.SetProcessInput(true);
    Nodes.BookTexture_PageContents_Page2_Page2.SetProcessInput(true);

    Nodes.ClickOutside.Pressed += () => {
      Root.Instance.ToggleRolodex();
    };

    Nodes.CloseRolodex.Pressed += () => {
      Root.Instance.ToggleRolodex();
    };
  }

  public void ClearSignals() {
    OnClickIngredient = null;
  }

  public void AddGuestEntry(CreatureData creature) {
    GameState.KnownGuests.Add(creature);
    PopulatePages();
  }

  public void AddRecipeEntry(Recipe recipe) {
    GameState.UnlockedRecipes.Add(recipe);
    PopulatePages();
  }


  private RolodexCreatureEntry CreateCreatureEntry(CreatureData creature) {
    var creatureEntry = GD.Load<PackedScene>("res://Scenes/RolodexCreatureEntry.tscn").Instantiate<RolodexCreatureEntry>();
    if (creature.Icon != null) {
      creatureEntry.Nodes.HBoxContainer_TextureRect.Texture = creature.Icon;
    }
    creatureEntry.Nodes.HBoxContainer_TextContainer_Name.Text = creature.DisplayName;
    // TODO: Populate any known characteristics.

    return creatureEntry;
  }

  private RolodexRecipeEntry CreateRecipeEntry(Recipe recipe) {
    var recipeEntry = GD.Load<PackedScene>("res://Scenes/RolodexRecipeEntry.tscn").Instantiate<RolodexRecipeEntry>();
    if (recipe.Icon != null) {
      recipeEntry.Nodes.HBoxContainer_TextureRect.Texture = recipe.Icon;
    }
    recipeEntry.Nodes.HBoxContainer_TextContainer_Name.Text = recipe.DisplayName;
    recipeEntry.Nodes.HBoxContainer_TextContainer_Description.Text = recipe.Description;


    recipeEntry.Nodes.HBoxContainer_TextContainer_Ingredients.GetChildren().ToList().ForEach(n => n.QueueFree());
    // Loop through the Godot.Collections.Array
    foreach (var ingredient in recipe.Ingredients) {
      var ingredientEntry = GD.Load<PackedScene>("res://Scenes/RolodexRecipeEntry_Ingredient.tscn").Instantiate<RolodexRecipeEntryIngredient>();
      ingredientEntry.Texture = ingredient.Icon;
      recipeEntry.Nodes.HBoxContainer_TextContainer_Ingredients.AddChild(ingredientEntry);
    }

    return recipeEntry;
  }

  private RolodexIngredientEntry CreateIngredientEntry(Ingredient ingredientData) {
    var ingredientEntry = GD.Load<PackedScene>("res://Scenes/RolodexIngredientEntry.tscn").Instantiate<RolodexIngredientEntry>();
    ingredientEntry.Initialize(ingredientData, GameState.CurrentScreen == GameScreen.Cooking);

    return ingredientEntry;
  }

  private void FlipPage(bool forward) {
    Root.Instance.Nodes.SoundManager.PlayPageTurnSFX();

    if (forward) {
      Page += 2;
    } else {
      Page -= 2;
    }

    PopulatePages();
  }

  public void ChangeTab(RolodexTab tab) {
    Root.Instance.Nodes.SoundManager.PlayPageTurnSFX();
    Tab = tab;
    PopulatePages();
  }

  private void PopulatePages() {
    if (Page == 0) {
      Nodes.BookTexture_PrevPageButton.Visible = false;
    } else {
      Nodes.BookTexture_PrevPageButton.Visible = true;
    }

    if (Page == GameState.KnownGuests.Count / MaxEntriesPerPage) {
      Nodes.BookTexture_NextPageButton.Visible = false;
    } else {
      Nodes.BookTexture_NextPageButton.Visible = true;
    }

    // Clear existing entries.
    Nodes.BookTexture_PageContents_Page1_Page1.GetChildren().ToList().ForEach(n => n.QueueFree());
    Nodes.BookTexture_PageContents_Page2_Page2.GetChildren().ToList().ForEach(n => n.QueueFree());

    var page1StartIndex = Page * MaxEntriesPerPage;
    var page2StartIndex = (Page * MaxEntriesPerPage) + MaxEntriesPerPage;
    var page2EndIndex = (Page * MaxEntriesPerPage) + MaxEntriesPerPage + MaxEntriesPerPage;

    if (Tab == RolodexTab.Creatures) {
      // Populate the pages.
      for (int i = page1StartIndex; i < page2StartIndex; i++) {
        if (i >= GameState.KnownGuests.Count) {
          break;
        }
        // Add an HSeparator to the page, if it's not the last entry.
        if (i != page1StartIndex) {
          var separator = new HSeparator();
          Nodes.BookTexture_PageContents_Page1_Page1.AddChild(separator);
        }
        Nodes.BookTexture_PageContents_Page1_Page1.AddChild(CreateCreatureEntry(GameState.KnownGuests[i]));
      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= GameState.KnownGuests.Count) {
          break;
        }
        if (i != page2StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_PageContents_Page2_Page2.AddChild(separator);
        }
        Nodes.BookTexture_PageContents_Page2_Page2.AddChild(CreateCreatureEntry(GameState.KnownGuests[i]));

      }
    } else if (Tab == RolodexTab.Recipes) {
      // TODO: Populate the recipes page.
      for (int i = page1StartIndex; i < page2StartIndex; i++) {
        if (i >= GameState.UnlockedRecipes.Count) {
          break;
        }
        if (i != page1StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_PageContents_Page1_Page1.AddChild(separator);
        }
        Nodes.BookTexture_PageContents_Page1_Page1.AddChild(CreateRecipeEntry(GameState.UnlockedRecipes[i]));
      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= GameState.UnlockedRecipes.Count) {
          break;
        }
        if (i != page2StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_PageContents_Page2_Page2.AddChild(separator);
        }
        Nodes.BookTexture_PageContents_Page2_Page2.AddChild(CreateRecipeEntry(GameState.UnlockedRecipes[i]));

      }
    } else if (Tab == RolodexTab.Ingredients) {

      for (int i = page1StartIndex; i < page2StartIndex; i++) {
        // necessary because of closure stuff
        var ingredient = GameState.KnownIngredients[i];

        if (i >= GameState.KnownIngredients.Count) {
          break;
        }
        if (i != page1StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_PageContents_Page1_Page1.AddChild(separator);
        }
        var ingredientEntry = CreateIngredientEntry(ingredient);
        ingredientEntry.Nodes.Button.Pressed += () => {
          OnClickIngredient?.Invoke(ingredient.Id);
        };
        Nodes.BookTexture_PageContents_Page1_Page1.AddChild(ingredientEntry);

      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        // necessary because of closure stuff
        var ingredient = GameState.KnownIngredients[i];

        if (i >= GameState.KnownIngredients.Count) {
          break;
        }
        if (i != page2StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_PageContents_Page2_Page2.AddChild(separator);
        }
        var ingredientEntry = CreateIngredientEntry(ingredient);
        ingredientEntry.Nodes.Button.Pressed += () => {
          OnClickIngredient?.Invoke(ingredient.Id);
        };
        Nodes.BookTexture_PageContents_Page2_Page2.AddChild(ingredientEntry);
      }
    }
  }
}
