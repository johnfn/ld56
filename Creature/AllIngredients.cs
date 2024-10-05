using Godot;

namespace ld56;

public static class AllIngredients {
  public static readonly Ingredient CherryTomato = new() {
    Name = "Cherry Tomato",
    Description = "A small, round tomato.",
    Icon = GD.Load<Texture2D>("res://Assets/cherry_tomato.png"),
  };

  public static readonly Ingredient Basil = new() {
    Name = "Basil",
    Description = "A green herb with a strong aroma.",
    Icon = GD.Load<Texture2D>("res://Assets/basil_leaf.png"),
  };

  public static readonly Ingredient Garlic = new() {
    Name = "Garlic",
    Description = "A bulb with strong-smelling cloves.",
  };

  public static readonly Ingredient Onion = new() {
    Name = "Onion",
    Description = "A bulb with a strong aroma.",
  };

  public static readonly Ingredient Carrot = new() {
    Name = "Carrot",
    Description = "A long, orange root.",
  };

  public static readonly Ingredient Egg = new() {
    Name = "Egg",
    Description = "A small, round egg.",
  };
}
