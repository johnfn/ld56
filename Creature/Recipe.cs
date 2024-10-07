using System.Collections.Generic;
using Godot;

namespace ld56;

[GlobalClass]
[Tool]

public partial class Recipe : Resource {
  [Export]
  public string DisplayName { get; set; }
  [Export]
  public string Description { get; set; }

  [Export]
  public Godot.Collections.Array<Ingredient> Ingredients { get; set; }

  [Export]
  public Texture2D Icon { get; set; }

  public Recipe() {
    DisplayName = "New Recipe";
    Description = "A new recipe.";
    Ingredients = new Godot.Collections.Array<Ingredient>();
  }
}
