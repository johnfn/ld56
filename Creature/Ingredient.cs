using Godot;

namespace ld56;

public partial class Ingredient : Resource {
  [Export]
  public string DisplayName { get; set; }

  [Export]
  public string Description { get; set; }

  [Export]
  public Texture2D Icon { get; set; }

  [Export]
  public IngredientId Id { get; set; }

  [Export]
  public Rarity Rarity { get; set; }

  public Ingredient() {
    DisplayName = "New Ingredient";
    Description = "A new ingredient.";
    Icon = null;
    Id = IngredientId.Basil;
    Rarity = Rarity.Common;
  }
}

