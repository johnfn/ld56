using Godot;

namespace ld56;

public enum IngredientId {
  CherryTomato,
  Basil,
  Garlic,
  Onion,
  Carrot,
  Egg,
}

public enum Rarity {
  Trash,
  Common,
  Uncommon,
  Rare,
  Epic,
  Legendary,
  Staggering,
  MindBending,
  GameBreaking,
  GodTier,
  Catastrophic,
}

public static class AllIngredients {
  public static readonly Ingredient CherryTomato = new() {
    DisplayName = "Cherry Tomato",
    Id = IngredientId.CherryTomato,
    Description = "A small, round tomato.",
    Icon = GD.Load<Texture2D>("res://Assets/Ingredients/cherry_tomato.png"),
    Rarity = Rarity.Common,
  };

  public static readonly Ingredient Basil = new() {
    DisplayName = "Basil",
    Id = IngredientId.Basil,
    Description = "A green herb with a strong aroma.",
    Icon = GD.Load<Texture2D>("res://Assets/Ingredients/basil_leaf.png"),
    Rarity = Rarity.Common,
  };

  public static readonly Ingredient Garlic = new() {
    DisplayName = "Garlic",
    Id = IngredientId.Garlic,
    Description = "A bulb with strong-smelling cloves.",
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/garlic.png"),
    Rarity = Rarity.Common,
  };

  public static readonly Ingredient Onion = new() {
    DisplayName = "Onion",
    Description = "A bulb with a strong aroma.",
    Id = IngredientId.Onion,
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/onion.png"),
    Rarity = Rarity.Common,
  };

  public static readonly Ingredient Carrot = new() {
    DisplayName = "Carrot",
    Id = IngredientId.Carrot,
    Description = "A long, orange root.",
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/carrot.png"),
    Rarity = Rarity.Common,
  };

  public static readonly Ingredient Egg = new() {
    DisplayName = "Egg",
    Description = "A small, round egg.",
    Id = IngredientId.Egg,
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/egg.png"),
    Rarity = Rarity.Common,
  };

  public static Ingredient Get(IngredientId name) {
    return name switch {
      IngredientId.CherryTomato => CherryTomato,
      IngredientId.Basil => Basil,
      IngredientId.Garlic => Garlic,
      IngredientId.Onion => Onion,
      IngredientId.Carrot => Carrot,
      IngredientId.Egg => Egg,
    };
  }
}
