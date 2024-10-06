using Godot;
using ld56;
using System.Collections.Generic;
using System.Linq;

public partial class Rolodex : Sprite2D {
  public List<Recipe> UnlockedRecipes = [
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
  ];

  public List<Creature> KnownGuests = [
    AllCreatures.MrChicken,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
  ];

  public List<Ingredient> KnownIngredients = [
    AllIngredients.CherryTomato,
    AllIngredients.Basil,
    AllIngredients.Garlic,
    AllIngredients.Onion,
    AllIngredients.Carrot,
    AllIngredients.Egg,
  ];

  public List<Ingredient> OwnedIngredients = [
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.Basil,
    AllIngredients.Basil,
    AllIngredients.Basil,
  ];

  private int Page = 0;
  private int MaxEntriesPerPage = 5;

  private enum RolodexTab {
    Creatures,
    Recipes,
    Ingredients,
  }

  private RolodexTab Tab = RolodexTab.Creatures;

  public override void _Ready() {
    PopulatePages();

    Nodes.NextPageButton.Pressed += () => FlipPage(true);
    Nodes.PrevPageButton.Pressed += () => FlipPage(false);

    Nodes.RecipesTab.Pressed += () => ChangeTab(RolodexTab.Recipes);
    Nodes.CreaturesTab.Pressed += () => ChangeTab(RolodexTab.Creatures);
    Nodes.IngredientsTab.Pressed += () => ChangeTab(RolodexTab.Ingredients);
  }

  public void AddGuestEntry(Creature creature) {
    KnownGuests.Add(creature);
    PopulatePages();
  }

  public void AddRecipeEntry(Recipe recipe) {
    UnlockedRecipes.Add(recipe);
    PopulatePages();
  }


  private RolodexCreatureEntry CreateCreatureEntry(Creature creature) {
    var creatureEntry = GD.Load<PackedScene>("res://Scenes/RolodexCreatureEntry.tscn").Instantiate<RolodexCreatureEntry>();
    if (creature.Icon != null) {
      creatureEntry.Nodes.HBoxContainer_TextureRect.Texture = creature.Icon;
    }
    creatureEntry.Nodes.HBoxContainer_VBoxContainer_Name.Text = creature.Name;
    creatureEntry.Nodes.HBoxContainer_VBoxContainer_Characteristic.Text = creature.Description;

    return creatureEntry;
  }

  private RolodexRecipeEntry CreateRecipeEntry(Recipe recipe) {
    var recipeEntry = GD.Load<PackedScene>("res://Scenes/RolodexRecipeEntry.tscn").Instantiate<RolodexRecipeEntry>();
    if (recipe.Icon != null) {
      recipeEntry.Nodes.HBoxContainer_TextureRect.Texture = recipe.Icon;
    }
    recipeEntry.Nodes.HBoxContainer_VBoxContainer_Name.Text = recipe.Name;
    recipeEntry.Nodes.HBoxContainer_VBoxContainer_Characteristic.Text = recipe.Description;

    recipeEntry.Nodes.HBoxContainer_VBoxContainer_Ingredients.GetChildren().ToList().ForEach(n => n.QueueFree());
    recipe.Ingredients.ForEach(ingredient => {
      var textureRect = new TextureRect() {
        Texture = ingredient.Icon,
      };
      textureRect.ExpandMode = TextureRect.ExpandModeEnum.IgnoreSize;
      textureRect.StretchMode = TextureRect.StretchModeEnum.KeepAspectCentered;
      textureRect.CustomMinimumSize = new Vector2I(100, 100);
      recipeEntry.Nodes.HBoxContainer_VBoxContainer_Ingredients.AddChild(textureRect);
    });

    return recipeEntry;
  }

  private RolodexIngredientEntry CreateIngredientEntry(Ingredient ingredient) {
    var ingredientEntry = GD.Load<PackedScene>("res://Scenes/RolodexIngredientEntry.tscn").Instantiate<RolodexIngredientEntry>();
    if (ingredient.Icon != null) {
      ingredientEntry.Nodes.HBoxContainer_TextureRect.Texture = ingredient.Icon;
    }
    ingredientEntry.Nodes.HBoxContainer_VBoxContainer_Name.Text = ingredient.DisplayName;
    ingredientEntry.Nodes.HBoxContainer_VBoxContainer_Characteristic.Text = ingredient.Description;

    return ingredientEntry;
  }

  private void FlipPage(bool forward) {
    Root.Instance.Nodes.SoundManager.PlayPageTurnSFX();

    if (forward) {
      Page += 2;
    } else {
      Page -= 2;
    }

    if (Page == 0) {
      Nodes.PrevPageButton.Disabled = true;
    } else {
      Nodes.PrevPageButton.Disabled = false;
    }

    if (Page == KnownGuests.Count / MaxEntriesPerPage) {
      Nodes.NextPageButton.Disabled = true;
    } else {
      Nodes.NextPageButton.Disabled = false;
    }

    PopulatePages();
  }

  private void ChangeTab(RolodexTab tab) {
    Root.Instance.Nodes.SoundManager.PlayPageTurnSFX();
    Tab = tab;
    PopulatePages();
  }

  private void PopulatePages() {
    // Clear existing entries.
    Nodes.Page1Viewport_MarginContainer_Page1.GetChildren().ToList().ForEach(n => n.QueueFree());
    Nodes.Page2Viewport_MarginContainer_Page2.GetChildren().ToList().ForEach(n => n.QueueFree());

    var page1StartIndex = Page * MaxEntriesPerPage;
    var page2StartIndex = (Page * MaxEntriesPerPage) + MaxEntriesPerPage;
    var page2EndIndex = (Page * MaxEntriesPerPage) + MaxEntriesPerPage + MaxEntriesPerPage;



    if (Tab == RolodexTab.Creatures) {
      // Populate the pages.
      for (int i = page1StartIndex; i < page2StartIndex; i++) {
        if (i >= KnownGuests.Count) {
          break;
        }
        Nodes.Page1Viewport_MarginContainer_Page1.AddChild(CreateCreatureEntry(KnownGuests[i]));
      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= KnownGuests.Count) {
          break;
        }
        Nodes.Page2Viewport_MarginContainer_Page2.AddChild(CreateCreatureEntry(KnownGuests[i]));
      }
    } else if (Tab == RolodexTab.Recipes) {
      // TODO: Populate the recipes page.
      for (int i = page1StartIndex; i < page2StartIndex; i++) {
        if (i >= UnlockedRecipes.Count) {
          break;
        }
        Nodes.Page1Viewport_MarginContainer_Page1.AddChild(CreateRecipeEntry(UnlockedRecipes[i]));
      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= UnlockedRecipes.Count) {
          break;
        }
        Nodes.Page2Viewport_MarginContainer_Page2.AddChild(CreateRecipeEntry(UnlockedRecipes[i]));
      }
    } else if (Tab == RolodexTab.Ingredients) {

      for (int i = page1StartIndex; i < page2StartIndex; i++) {
        if (i >= KnownIngredients.Count) {
          break;
        }
        Nodes.Page1Viewport_MarginContainer_Page1.AddChild(CreateIngredientEntry(KnownIngredients[i]));
      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= KnownIngredients.Count) {
          break;
        }
        Nodes.Page2Viewport_MarginContainer_Page2.AddChild(CreateIngredientEntry(KnownIngredients[i]));
      }
    }
  }

}
