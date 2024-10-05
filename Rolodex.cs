using Godot;
using ld56;
using System;
using System.Linq;

public partial class Rolodex : Sprite2D {
  public Recipe[] UnlockedRecipes = [
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
  ];

  public Creature[] KnownGuests = [
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

  private int Page = 0;
  private int MaxEntriesPerPage = 5;


  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    PopulatePages();

    Nodes.NextPageButton.Pressed += () => FlipPage(true);
    Nodes.PrevPageButton.Pressed += () => FlipPage(false);
  }

  private RolodexCreatureEntry CreateCreatureEntry(Creature creature) {
    var creatureEntry = GD.Load<PackedScene>("res://RolodexCreatureEntry.tscn").Instantiate<RolodexCreatureEntry>();
    // creatureEntry.Nodes.HBoxContainer_TextureRect.Texture = null; // TODO: Set this
    creatureEntry.Nodes.HBoxContainer_VBoxContainer_Name.Text = creature.Name;
    creatureEntry.Nodes.HBoxContainer_VBoxContainer_Characteristic.Text = creature.Description;

    return creatureEntry;
  }

  private void FlipPage(bool forward) {
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

    if (Page == KnownGuests.Length / MaxEntriesPerPage) {
      Nodes.NextPageButton.Disabled = true;
    } else {
      Nodes.NextPageButton.Disabled = false;
    }

    PopulatePages();
  }

  private void PopulatePages() {
    // Clear existing entries.
    Nodes.Page1Viewport_MarginContainer_Page1.GetChildren().ToList().ForEach(n => n.QueueFree());
    Nodes.Page2Viewport_MarginContainer_Page2.GetChildren().ToList().ForEach(n => n.QueueFree());


    // Populate the pages.
    var page1StartIndex = Page * MaxEntriesPerPage;
    var page2StartIndex = (Page * MaxEntriesPerPage) + MaxEntriesPerPage;
    var page2EndIndex = (Page * MaxEntriesPerPage) + MaxEntriesPerPage + MaxEntriesPerPage;

    for (int i = page1StartIndex; i < page2StartIndex; i++) {
      Nodes.Page1Viewport_MarginContainer_Page1.AddChild(CreateCreatureEntry(KnownGuests[i]));
    }

    for (int i = page2StartIndex; i < page2EndIndex; i++) {
      Nodes.Page2Viewport_MarginContainer_Page2.AddChild(CreateCreatureEntry(KnownGuests[i]));
    }
  }

}
