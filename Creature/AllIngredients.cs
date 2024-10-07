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
  public static readonly IngredientData CherryTomato = new() {
    DisplayName = "Cherry Tomato",
    Id = IngredientId.CherryTomato,
    Description = "A small, round tomato.",
    Icon = GD.Load<Texture2D>("res://Assets/Ingredients/cherry_tomato.png"),
    Rarity = Rarity.Common,
    Cost = 1,
  };

  public static readonly IngredientData Basil = new() {
    DisplayName = "Basil",
    Id = IngredientId.Basil,
    Description = "A green herb with a strong aroma.",
    Icon = GD.Load<Texture2D>("res://Assets/Ingredients/basil_leaf.png"),
    Rarity = Rarity.Common,
    Cost = 5,
  };

  public static readonly IngredientData Garlic = new() {
    DisplayName = "Garlic",
    Id = IngredientId.Garlic,
    Description = "A bulb with strong-smelling cloves.",
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/garlic.png"),
    Rarity = Rarity.Common,
    Cost = 1,
  };

  public static readonly IngredientData Onion = new() {
    DisplayName = "Onion",
    Description = "A bulb with a strong aroma.",
    Id = IngredientId.Onion,
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/onion.png"),
    Rarity = Rarity.Common,
    Cost = 10,
  };

  public static readonly IngredientData Carrot = new() {
    DisplayName = "Carrot",
    Id = IngredientId.Carrot,
    Description = "A long, orange root.",
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/carrot.png"),
    Rarity = Rarity.Common,
    Cost = 1,
  };

  public static readonly IngredientData Egg = new() {
    DisplayName = "Egg",
    Description = "A small, round egg.",
    Id = IngredientId.Egg,
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/egg.png"),
    Rarity = Rarity.Common,
    Cost = 5,
  };

  public static readonly IngredientData DiscountEgg = new() {
    DisplayName = "Egg",
    Description = "omg, these eggs are on sale!",
    Id = IngredientId.Egg,
    // Icon = GD.Load<Texture2D>("res://Assets/Ingredients/egg.png"),
    Rarity = Rarity.Common,
    Cost = 1,
  };

  public static IngredientData Get(IngredientId name) {
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
