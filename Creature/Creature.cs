using System.Collections.Generic;
using Godot;

namespace ld56;

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
  public CreatureId Id { get; set; }

  [Export]
  public List<IngredientId> FavoriteIngredients { get; set; } = [];

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
