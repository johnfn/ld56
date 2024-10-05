using System.Collections.Generic;
using Godot;

namespace ld56;

public partial class Recipe : Resource {
  public string Name { get; set; }
  public string Description { get; set; }
  public List<Ingredient> Ingredients { get; set; }

  public Texture2D Icon { get; set; }

  public Recipe() {
    Name = "New Recipe";
    Description = "A new recipe.";
    Ingredients = new List<Ingredient>();
  }
}
