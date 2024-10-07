using Godot;

namespace ld56;

[GlobalClass]
[Tool]
public partial class Ingredient : Resource {
  [Export]
  public required string DisplayName { get; set; }

  [Export]
  public required string Description { get; set; }

  [Export]
  public Texture2D Icon { get; set; }

  [Export]
  public required IngredientId Id { get; set; }

  [Export]
  public required Rarity Rarity { get; set; }

  [Export]
  public required int Cost { get; set; }


  // This is called when the ingredient is loaded into memory.
  public Ingredient() {
    DisplayName = "New Ingredient";
    Description = "A new ingredient.";
    Icon = null;
    Id = IngredientId.None;
    Rarity = Rarity.Common;
    Cost = 10;
  }
}

