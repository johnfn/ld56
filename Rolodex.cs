using Godot;
using ld56;
using System;

public partial class Rolodex : Sprite2D
{
  public Recipe[] UnlockedRecipes = [
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
  ];

  public Creature[] KnownGuests = [
   
  ];


  
  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }
}
