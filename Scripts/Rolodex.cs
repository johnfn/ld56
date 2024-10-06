using Godot;
using ld56;
using System.Collections.Generic;
using System.Linq;

public partial class Rolodex : ColorRect {

  [Signal]
  public delegate void OnClickIngredientEventHandler(IngredientId ingredientId);

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
    Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.SetProcessInput(true);
    Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.SetProcessInput(true);

    Nodes.ClickOutside.Pressed += () => {
      Root.Instance.ToggleRolodex();
    };
  }


  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouse mouseEvent) {
      Vector2 globalMousePos = mouseEvent.GlobalPosition;

      HandlePageInput(Nodes.BookTexture_LeftPageContents, Nodes.BookTexture_Page1Viewport, globalMousePos, mouseEvent, "Left");
      HandlePageInput(Nodes.BookTexture_RightPageContents, Nodes.BookTexture_Page2Viewport, globalMousePos, mouseEvent, "Right");
    }
  }

  private void HandlePageInput(Control pageContents, SubViewport viewport, Vector2 globalMousePos, InputEventMouse mouseEvent, string pageName) {
    if (pageContents.GetGlobalRect().HasPoint(globalMousePos)) {
      Vector2 localPosPage = pageContents.GetGlobalTransform().AffineInverse().BasisXform(globalMousePos);

      Vector2 viewportLocalPos = viewport.GlobalCanvasTransform.AffineInverse().BasisXform(globalMousePos);

      // Calculate the scale factor between the viewport and the texture rect
      float scaleX = viewport.Size.X / pageContents.Size.X;
      float scaleY = viewport.Size.Y / pageContents.Size.Y;
      Vector2 scaledPos = viewportLocalPos * new Vector2(scaleX, scaleY);

      // Create a new mouse event with the scaled position
      var scaledEvent = (InputEventMouse)mouseEvent.Duplicate();
      scaledEvent.Position = scaledPos;
      scaledEvent.GlobalPosition = scaledPos;

      // Push the scaled event to the viewport
      viewport.PushInput(scaledEvent);
    }
  }


  public void AddGuestEntry(Creature creature) {
    GameState.KnownGuests.Add(creature);
    PopulatePages();
  }

  public void AddRecipeEntry(Recipe recipe) {
    GameState.UnlockedRecipes.Add(recipe);
    PopulatePages();
  }


  private RolodexCreatureEntry CreateCreatureEntry(Creature creature) {
    var creatureEntry = GD.Load<PackedScene>("res://Scenes/RolodexCreatureEntry.tscn").Instantiate<RolodexCreatureEntry>();
    if (creature.Icon != null) {
      creatureEntry.Nodes.HBoxContainer_TextureRect.Texture = creature.Icon;
    }
    creatureEntry.Nodes.HBoxContainer_TextContainer_Name.Text = creature.Name;
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
    recipe.Ingredients.ForEach(ingredient => {
      var ingredientEntry = GD.Load<PackedScene>("res://Scenes/RolodexRecipeEntry_Ingredient.tscn").Instantiate<RolodexRecipeEntryIngredient>();
      ingredientEntry.Texture = ingredient.Icon;
      recipeEntry.Nodes.HBoxContainer_TextContainer_Ingredients.AddChild(ingredientEntry);
    });

    return recipeEntry;
  }

  private RolodexIngredientEntry CreateIngredientEntry(Ingredient ingredient) {
    var ingredientEntry = GD.Load<PackedScene>("res://Scenes/RolodexIngredientEntry.tscn").Instantiate<RolodexIngredientEntry>();
    if (ingredient.Icon != null) {
      ingredientEntry.Nodes.HBoxContainer_TextureRect.Texture = ingredient.Icon;
    }
    ingredientEntry.Nodes.HBoxContainer_TextContainer_Name.Text = ingredient.DisplayName;
    ingredientEntry.Nodes.HBoxContainer_TextContainer_Description.Text = ingredient.Description;

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
    Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.GetChildren().ToList().ForEach(n => n.QueueFree());
    Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.GetChildren().ToList().ForEach(n => n.QueueFree());

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
          Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.AddChild(separator);
        }
        Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.AddChild(CreateCreatureEntry(GameState.KnownGuests[i]));
      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= GameState.KnownGuests.Count) {
          break;
        }
        if (i != page2StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.AddChild(separator);
        }
        Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.AddChild(CreateCreatureEntry(GameState.KnownGuests[i]));

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
          Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.AddChild(separator);
        }
        Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.AddChild(CreateRecipeEntry(GameState.UnlockedRecipes[i]));
      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= GameState.UnlockedRecipes.Count) {
          break;
        }
        if (i != page2StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.AddChild(separator);
        }
        Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.AddChild(CreateRecipeEntry(GameState.UnlockedRecipes[i]));

      }
    } else if (Tab == RolodexTab.Ingredients) {

      for (int i = page1StartIndex; i < page2StartIndex; i++) {
        if (i >= GameState.KnownIngredients.Count) {
          break;
        }
        if (i != page1StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.AddChild(separator);
        }
        var ingredientEntry = CreateIngredientEntry(GameState.KnownIngredients[i]);
        ingredientEntry.Nodes.Button.Pressed += () => {
          EmitSignal(SignalName.OnClickIngredient, GameState.KnownIngredients[i].DisplayName);
        };
        Nodes.BookTexture_Page1Viewport_MarginContainer_Page1.AddChild(ingredientEntry);

      }

      for (int i = page2StartIndex; i < page2EndIndex; i++) {
        if (i >= GameState.KnownIngredients.Count) {
          break;
        }
        if (i != page2StartIndex) {
          // Add an HSeparator
          var separator = new HSeparator();
          Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.AddChild(separator);
        }
        var ingredientEntry = CreateIngredientEntry(GameState.KnownIngredients[i]);
        ingredientEntry.Nodes.Button.Pressed += () => {
          EmitSignal(SignalName.OnClickIngredient, GameState.KnownIngredients[i].DisplayName);
        };
        Nodes.BookTexture_Page2Viewport_MarginContainer_Page2.AddChild(ingredientEntry);

      }
    }
  }

}
