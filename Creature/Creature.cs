using System;
using System.Collections.Generic;
using Godot;

namespace ld56;

public enum MealQuality {
  Perfect,
  Close,
  Miss,
}

[System.Serializable]
public class MealResult {
  public List<string> Text;
  public Action Result;
}

[GlobalClass]
[Tool]
public partial class CreatureData : Resource {
  [Export]
  public string DisplayName { get; set; } = "New Creature";

  [Export]
  public string Description { get; set; } = "A new creature.";

  [Export]
  public Texture2D Icon { get; set; }

  [Export]
  public Texture2D FullBodyTexture { get; set; }

  [Export]
  public Texture2D DialogPortraitTexture { get; set; }

  [Export]
  public required CreatureId Id { get; set; }

  [Export]
  public int VoiceIndex { get; set; } = 0;

  // This will be set programmatically after loading
  [System.NonSerialized]
  public System.Func<SpawnedCreature, Node2D> Instantiate;

  public CreatureData() {
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    };
  }
}
