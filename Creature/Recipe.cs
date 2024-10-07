using System.Collections.Generic;
using Godot;

namespace ld56;

public partial class Recipe : Resource {
  public string DisplayName { get; set; }
  public string Description { get; set; }
  public List<IngredientData> Ingredients { get; set; }

  public Texture2D Icon { get; set; }

  public Recipe() {
    DisplayName = "New Recipe";
    Description = "A new recipe.";
    Ingredients = new List<IngredientData>();
  }
}
