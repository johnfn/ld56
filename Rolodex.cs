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
    var creatureEntry = GD.Load<PackedScene>("res://RolodexCreatureEntry.tscn");

    // There can only be max 5 creatures per page.
    for (int i = 0; i < MaxEntriesPerPage; i++) {
      Nodes.Page1Viewport_MarginContainer_Page1.AddChild(CreateCreatureEntry(KnownGuests[i]));
    }

    for (int i = MaxEntriesPerPage; i < KnownGuests.Length; i++) {
      Nodes.Page2Viewport_MarginContainer_Page2.AddChild(CreateCreatureEntry(KnownGuests[i]));
    }
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
      Page++;
    } else {
      Page--;
    }

    // Repopulate the pages.
    Nodes.Page1Viewport_MarginContainer_Page1.GetChildren().ToList().ForEach(n => n.QueueFree());
    Nodes.Page2Viewport_MarginContainer_Page2.GetChildren().ToList().ForEach(n => n.QueueFree());

    for (int i = 0; i < Page * MaxEntriesPerPage; i++) {
      Nodes.Page1Viewport_MarginContainer_Page1.AddChild(CreateCreatureEntry(KnownGuests[i]));
    }

    for (int i = Page * MaxEntriesPerPage; i < (Page * MaxEntriesPerPage) + MaxEntriesPerPage; i++) {
      Nodes.Page2Viewport_MarginContainer_Page2.AddChild(CreateCreatureEntry(KnownGuests[i]));
    }
  }

}
