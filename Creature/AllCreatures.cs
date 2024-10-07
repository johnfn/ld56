using Godot;

namespace ld56;

public static class AllCreatures {
  public static readonly CreatureData Hazel = new() {
    DisplayName = "hazel",
    Description = "It's Hazel.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog-3_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog-3.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog-3.png"),
  };







  // public static readonly CreatureData MrChicken = new() {
  //   DisplayName = "chipmunk",
  //   Description = "It's the neighborhood's richest chicke- uh, I mean chipmunk. It's always wearing a fancy hat and carrying a cane.",
  //   Instantiate = (spawnedCreature) => {
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk.png"),
  // };

  // public static readonly CreatureData You = new() {
  //   DisplayName = "You",
  //   Description = "It's you! You shouldn't be reading this...",
  //   Instantiate = (spawnedCreature) => {
  //     GD.Print("You should not be reading this...");
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   // TODO...
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk.png"),
  // };

  // public static readonly CreatureData MrsCow = new() {
  //   DisplayName = "cat",
  //   Description = "A big, friendly cat. She's always smiling and waving at people.",
  //   Instantiate = (spawnedCreature) => {
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Det-Cat_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Detective-Cat.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Detective-Cat.png"),
  // };

  // public static readonly CreatureData MrPig = new() {
  //   DisplayName = "pig",
  //   Description = "A big pig. It hates frogs.",
  //   Instantiate = (spawnedCreature) => {
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog.png"),
  // };

  // public static readonly CreatureData MrHamster = new() {
  //   DisplayName = "hamster",
  //   Description = "weee oooo yeee yaahhfh ehhehe!",
  //   Instantiate = (spawnedCreature) => {
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Hamster_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Hamster.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Hamster.png"),
  // };

  // public static readonly CreatureData MrMouse = new() {
  //   DisplayName = "mouse",
  //   Description = "Flavor text here :)",
  //   Instantiate = (spawnedCreature) => {
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  // };

  // public static readonly CreatureData MrSquirrel = new() {
  //   DisplayName = "squirrel",
  //   Description = "tee hee:3",
  //   Instantiate = (spawnedCreature) => {
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Squirrel_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Squirrel.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Squirrel.png"),
  // };

  // public static readonly CreatureData MrBlegg = new() {
  //   DisplayName = "blegg",
  //   Description = "blegg is the bleggest bleg that ever blegged a blegg.",
  //   Instantiate = (spawnedCreature) => {
  //     var creature = CreatureScene.New();
  //     creature.Initialize(spawnedCreature);
  //     return creature;
  //   },
  //   Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Squirrel_Neutral.png"),
  //   FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Squirrel.png"),
  //   DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Squirrel.png"),
  // };
}
