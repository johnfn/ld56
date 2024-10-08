using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    Id = CreatureId.You,
    // TODO...
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk_Neutral.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk.png"),


  };

  public static readonly CreatureData Hazel = new() {
    DisplayName = "Hazel",
    Description = "Very polite. Unless you make her angry, that is.",
    Id = CreatureId.Hazel,
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
    Description = "Learning to skateboard… slowly.",
    Id = CreatureId.Chip,
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
    DisplayName = "Kero",
    Description = "The local banker. Working on his self-image.",
    Id = CreatureId.Kero,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog.png"),
    VoiceIndex = 1,
  };

  public static readonly CreatureData Rufus = new() {
    DisplayName = "Rufus",
    Description = "The librarian. Sometimes gets confused.",
    Id = CreatureId.Rufus,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Squirrel_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Squirrel.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Squirrel.png"),
    VoiceIndex = 0,
  };

  public static readonly CreatureData Bonnie = new() {
    DisplayName = "Bonnie",
    Description = "From out of state.",
    Id = CreatureId.Bonnie,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Hamster-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Hamster-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Hamster-2.png"),
    VoiceIndex = 3,
  };

  public static readonly CreatureData Poe = new() {
    DisplayName = "Poe",
    Description = "Not sure, but he might be haunted.",
    Id = CreatureId.Poe,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Squirrel-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Squirrel-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Squirrel-2.png"),
    VoiceIndex = 4,
  };

  public static readonly CreatureData Speedy = new() {
    DisplayName = "Speedy",
    Description = "The track star. Always in a hurry.",
    Id = CreatureId.Speedy,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse-2.png"),
    VoiceIndex = 5,
  };

  public static readonly CreatureData Lav = new() {
    DisplayName = "Lav",
    Description = "Your enigmatic neighbor. Obsessed with the cosmos.",
    Id = CreatureId.Lav,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Chipmunk-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Chipmunk-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Chipmunk-2.png"),
    VoiceIndex = 6,
  };

  public static readonly CreatureData Pip = new() {
    DisplayName = "Pip",
    Description = "Very friendly, but very indecisive.",
    Id = CreatureId.Pip,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Frog-2_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Frog-2.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Frog-2.png"),
    VoiceIndex = 7,
  };

  public static readonly CreatureData Emily = new() {
    DisplayName = "Emily",
    Description = "An aspiring poet. Friendly, but can get huffy. ",
    Id = CreatureId.Emily,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Hamster_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Hamster.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Hamster.png"),
    VoiceIndex = 8,
  };

  public static readonly CreatureData Tom = new() {
    DisplayName = "Tom Shortcoat",
    Description = "Private detective...?",
    Id = CreatureId.Tom,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Det-Cat_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Detective-Cat.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Detective-Cat.png"),
    VoiceIndex = 9,
  };

  public static readonly CreatureData Jerry = new() {
    DisplayName = "Jerry Fontina",
    Description = "Runs a pizzeria (and also maybe an organized crime family?).",
    Id = CreatureId.Jerry,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mob-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mob-Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mob-Mouse.png"),
    VoiceIndex = 10,
  };

  public static readonly CreatureData StuartS = new() {
    DisplayName = "Stuart Squeakins",
    Description = "Accountant at city hall and father of seven.",
    Id = CreatureId.StuartS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 11,
  };

  public static readonly CreatureData MinnieS = new() {
    DisplayName = "Minnie Squeakins",
    Description = "Elementary school teacher and mother of seven.",
    Id = CreatureId.MinnieS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 12,
  };

  public static readonly CreatureData CarrieS = new() {
    DisplayName = "Carrie Squeakins",
    Description = "Oldest Squeakins child. She used to babysit me.",
    Id = CreatureId.CarrieS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 13,
  };

  public static readonly CreatureData HarryS = new() {
    DisplayName = "Harry Squeakins",
    Description = "Second Squeakins child. Pro rock guitarist.",
    Id = CreatureId.HarryS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 14,
  };

  public static readonly CreatureData GaryS = new() {
    DisplayName = "Gary Squeakins",
    Description = "Third Squeakins child. He went to high school with me.",
    Id = CreatureId.GaryS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 15,
  };

  public static readonly CreatureData TerryS = new() {
    DisplayName = "Terry Squeakins",
    Description = "Fourth Squeakins child. Very shy.",
    Id = CreatureId.TerryS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 0,
  };

  public static readonly CreatureData SherryS = new() {
    DisplayName = "Sherry Squeakins",
    Description = "Fifth Squeakins child. One minute older than her twin, Merry.",
    Id = CreatureId.SherryS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 1,
  };


  public static readonly CreatureData MerryS = new() {
    DisplayName = "Merry Squeakins",
    Description = "Sixth Squeakins child. One minute younger than her twin, Sherry.",
    Id = CreatureId.MerryS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 2,
  };

  public static readonly CreatureData PuffS = new() {
    DisplayName = "Puff Squeakins",
    Description = "Youngest Squeakins child. He's in second grade.",
    Id = CreatureId.PuffS,
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
    Icon = GD.Load<Texture2D>("res://Assets/UI/UI_Character-Mouse_Happy.png"),
    FullBodyTexture = GD.Load<Texture2D>("res://Assets/Characters/Character_Mouse.png"),
    DialogPortraitTexture = GD.Load<Texture2D>("res://Assets/UI/UI_Portrait_Mouse.png"),
    VoiceIndex = 3,
  };

  public static readonly Dictionary<CreatureId, CreatureData> CreatureIdToData = new() {
    [Bonnie.Id] = Bonnie,
    [CarrieS.Id] = CarrieS,
    [Chip.Id] = Chip,
    [Emily.Id] = Emily,
    [GaryS.Id] = GaryS,
    [HarryS.Id] = HarryS,
    [Hazel.Id] = Hazel,
    [Jerry.Id] = Jerry,
    [Kero.Id] = Kero,
    [Lav.Id] = Lav,
    [MerryS.Id] = MerryS,
    [MinnieS.Id] = MinnieS,
    [Pip.Id] = Pip,
    [Poe.Id] = Poe,
    [PuffS.Id] = PuffS,
    [Rufus.Id] = Rufus,
    [SherryS.Id] = SherryS,
    [Speedy.Id] = Speedy,
    [StuartS.Id] = StuartS,
    [TerryS.Id] = TerryS,
    [Tom.Id] = Tom,
    [You.Id] = You,
  };
}
