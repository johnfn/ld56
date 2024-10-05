using Godot;
using ld56;
using System;
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

  // Page turn SFX
  [Export]
  public AudioStream[] PageTurnSFX;

  private int Page = 0;
  private int MaxEntriesPerPage = 5;

  private enum RolodexTab {
    Creatures,
    Recipes,
  }

  private RolodexTab Tab = RolodexTab.Creatures;


  public override void _Ready() {
    GD.Print(PageTurnSFX.Length);
    PopulatePages();

    Nodes.NextPageButton.Pressed += () => FlipPage(true);
    Nodes.PrevPageButton.Pressed += () => FlipPage(false);

    Nodes.RecipesTab.Pressed += () => ChangeTab(RolodexTab.Recipes);
    Nodes.CreaturesTab.Pressed += () => ChangeTab(RolodexTab.Creatures);
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
    var creatureEntry = GD.Load<PackedScene>("res://RolodexCreatureEntry.tscn").Instantiate<RolodexCreatureEntry>();
    // creatureEntry.Nodes.HBoxContainer_TextureRect.Texture = null; // TODO: Set this
    creatureEntry.Nodes.HBoxContainer_VBoxContainer_Name.Text = creature.Name;
    creatureEntry.Nodes.HBoxContainer_VBoxContainer_Characteristic.Text = creature.Description;

    return creatureEntry;
  }

  private RolodexRecipeEntry CreateRecipeEntry(Recipe recipe) {
    var recipeEntry = GD.Load<PackedScene>("res://RolodexRecipeEntry.tscn").Instantiate<RolodexRecipeEntry>();
    // recipeEntry.Nodes.HBoxContainer_TextureRect.Texture = recipe.Icon; // TODO: Set this
    recipeEntry.Nodes.HBoxContainer_VBoxContainer_Name.Text = recipe.Name;
    recipeEntry.Nodes.HBoxContainer_VBoxContainer_Characteristic.Text = recipe.Description;

    return recipeEntry;
  }

  private void FlipPage(bool forward) {
    PlayPageTurnSFX();

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
    PlayPageTurnSFX();
    Tab = tab;
    PopulatePages();
  }
  private void PlayPageTurnSFX() {
    GD.Randomize();
    if (PageTurnSFX.Length == 0) {
      GD.PushWarning("No page turn SFX set for Rolodex.");
      return;
    }
    var randomIndex = GD.Randi() % PageTurnSFX.Length;
    var randomPageTurnSFX = PageTurnSFX[randomIndex];
    Nodes.AudioStreamPlayer2D.Stream = randomPageTurnSFX;
    Nodes.AudioStreamPlayer2D.Play();
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
    }
  }

}
