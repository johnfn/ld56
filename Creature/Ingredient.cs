using Godot;

namespace ld56;

public partial class Ingredient : Resource {
  [Export]
  public string Name { get; set; }
  [Export]
  public string Description { get; set; }

  [Export]
  public Texture2D Icon { get; set; }

  public Ingredient() {
    Name = "New Ingredient";
    Description = "A new ingredient.";
    Icon = null;
  }
}

