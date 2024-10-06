using Godot;

namespace ld56;

public static class AllCreatures {
  public static readonly Creature MrChicken = new() {
    Name = "chipmunk",
    Description = "It's the neighborhood's richest chicke- uh, I mean chipmunk. It's always wearing a fancy hat and carrying a cane.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk.png"),
  };

  public static readonly Creature MrsCow = new() {
    Name = "cat",
    Description = "A big, friendly cat. She's always smiling and waving at people.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Det-Cat_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Detective-Cat.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Detective-Cat.png"),
  };

  public static readonly Creature MrPig = new() {
    Name = "frog",
    Description = "A big frog. It hates pigs.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog.png"),
  };

  public static readonly Creature MrHamster = new() {
    Name = "hamster",
    Description = "weee oooo yeee yaahhfh ehhehe!",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Hamster_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Hamster.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Hamster.png"),
  };

  public static readonly Creature MrMouse = new() {
    Name = "mouse",
    Description = "Flavor text here :)",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly Creature MrSquirrel = new() {
    Name = "squirrel",
    Description = "tee hee:3",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Squirrel_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Squirrel.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Squirrel.png"),
  };
}
