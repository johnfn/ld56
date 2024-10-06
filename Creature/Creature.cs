using System;
using Godot;

namespace ld56;

public partial class Creature : Resource {
  public string DisplayName { get; set; }
  public string Description { get; set; }
  public Func<SpawnedCreature, Node2D> Instantiate { get; set; }
  public Texture2D Icon { get; set; }
  public Texture2D FullBodyTexture { get; set; }
  public Texture2D DialogPortraitTexture { get; set; }
  public Creature() {
    DisplayName = "New Creature";
    Description = "A new creature.";
  }
}
