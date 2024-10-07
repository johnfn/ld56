using Godot;

namespace ld56;

public partial class IngredientData : Resource {
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

  public IngredientData() {
    DisplayName = "New Ingredient";
    Description = "A new ingredient.";
    Icon = null;
    Id = IngredientId.Basil;
    Rarity = Rarity.Common;
    Cost = 10;
  }
}

