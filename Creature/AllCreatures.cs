using Godot;

namespace ld56;

public static class AllCreatures {
    public static readonly CreatureData You = new() {
    DisplayName = "You",
    Description = "It's you! You shouldn't be reading this...",
    Instantiate = (spawnedCreature) => {
      GD.Print("You should not be reading this...");
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    // TODO...
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk.png"),
  };
  
  public static readonly CreatureData Hazel = new() {
    DisplayName = "Hazel",
    Description = "Very polite.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog-3_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog-3.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog-3.png"),
  };

  public static readonly CreatureData Chip = new() {
    DisplayName = "Chip",
    Description = "Learning to skateboard.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk.png"),
  };

  public static readonly CreatureData Kero = new() {
    DisplayName = "Chip",
    Description = "Always on the lookout for some adventure.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog.png"),
  };

  public static readonly CreatureData Rufus = new() {
    DisplayName = "Rufus",
    Description = "Recently divorced.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Squirrel_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Squirrel.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Squirrel.png"),
  };

  public static readonly CreatureData Bonnie = new() {
    DisplayName = "Bonnie",
    Description = "Her glasses are purely cosmetic.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Hamster-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Hamster-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Hamster-2.png"),
  };

  public static readonly CreatureData Poe = new() {
    DisplayName = "Poe",
    Description = "Claims to be haunted.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Squirrel-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Squirrel-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Squirrel-2.png"),
  };

  public static readonly CreatureData Speedy = new() {
    DisplayName = "Speedy",
    Description = "Always in a hurry.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse-2.png"),
  };  

  public static readonly CreatureData Lav = new() {
    DisplayName = "Lav",
    Description = "Obessed with the cosmos.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk-2.png"),
  };

  public static readonly CreatureData Pip = new() {
    DisplayName = "Poe",
    Description = "Claims to be haunted.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog-2.png"),
  };

  public static readonly CreatureData Emily = new() {
    DisplayName = "Emily",
    Description = "Aspiring poet.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Hamster_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Hamster.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Hamster.png"),
  };

  public static readonly CreatureData Tom = new() {
    DisplayName = "Tom Shortcoat",
    Description = "Private detective...?",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Detective-Cat_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Detective-Cat.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Detective-Cat.png"),
  };

  public static readonly CreatureData Jerry = new() {
    DisplayName = "Jerry Fontina",
    Description = "Runs a pizzeria (and also maybe an organized crime family?).",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mob-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mob-Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mob-Mouse.png"),
  };

  public static readonly CreatureData StuartS = new() {
    DisplayName = "Stuart Squeakins",
    Description = "Accountant at city hall and father of seven.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData MinnieS = new() {
    DisplayName = "Minnie Squeakins",
    Description = "Elementary school teacher and mother of seven.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData CarrieS = new() {
    DisplayName = "Carrie Squeakins",
    Description = "Oldest Squeakins child. She used to babysit me.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData HarryS = new() {
    DisplayName = "Harry Squeakins",
    Description = "Second Squeakins child. Pro rock guitarist.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData GaryS = new() {
    DisplayName = "Gary Squeakins",
    Description = "Third Squeakins child. He went to high school with me.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData TerryS = new() {
    DisplayName = "Terry Squeakins",
    Description = "Fourth Squeakins child. Very shy.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData SherryS = new() {
    DisplayName = "Sherry Squeakins",
    Description = "Fifth Squeakins child. One minute older than her twin, Merry.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData MerryS = new() {
    DisplayName = "Merry Squeakins",
    Description = "Sixth Squeakins child. One minute younger than her twin, Sherry.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
  };

  public static readonly CreatureData PuffS = new() {
    DisplayName = "Puff Squeakins",
    Description = "Youngest Squeakins child. He's in second grade.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
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
