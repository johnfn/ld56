using Godot;
using System.Collections.Generic;

namespace ld56;

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
  public static List<Ingredient> Ingredients = new();

  internal static void LoadFromResources() {
    Ingredients.Clear();
    var ingredientsFolder = "res://Resources/Ingredients";
    var ingredientsFiles = Utils.ListDirContents(ingredientsFolder, "tres");
    foreach (var file in ingredientsFiles) {
      var ingredient = ResourceLoader.Load<Ingredient>($"{ingredientsFolder}/{file}");
      Ingredients.Add(ingredient);
    }

    GameState.KnownIngredients.Add(Bean.Id);
    GameState.KnownIngredients.Add(Leaf.Id);
  }

  private static Ingredient _avocado;
  public static Ingredient Avocado => _avocado ??= Ingredients.Find(i => i.DisplayName == "Avocado");

  private static Ingredient _blueberry;
  public static Ingredient Blueberry => _blueberry ??= Ingredients.Find(i => i.DisplayName == "Blueberry");

  private static Ingredient _cheese;
  public static Ingredient Cheese => _cheese ??= Ingredients.Find(i => i.DisplayName == "Cheese");

  private static Ingredient _flour;
  public static Ingredient Flour => _flour ??= Ingredients.Find(i => i.DisplayName == "Flour");

  private static Ingredient _milk;
  public static Ingredient Milk => _milk ??= Ingredients.Find(i => i.DisplayName == "Milk");

  private static Ingredient _nectar;
  public static Ingredient Nectar => _nectar ??= Ingredients.Find(i => i.DisplayName == "Nectar");

  private static Ingredient _strawberry;
  public static Ingredient Strawberry => _strawberry ??= Ingredients.Find(i => i.DisplayName == "Strawberry");

  private static Ingredient _turnip;
  public static Ingredient Turnip => _turnip ??= Ingredients.Find(i => i.DisplayName == "Turnip");

  private static Ingredient _bean;
  public static Ingredient Bean => _bean ??= Ingredients.Find(i => i.DisplayName == "Bean");

  private static Ingredient _bread;
  public static Ingredient Bread => _bread ??= Ingredients.Find(i => i.DisplayName == "Bread");

  private static Ingredient _egg;
  public static Ingredient Egg => _egg ??= Ingredients.Find(i => i.DisplayName == "Egg");

  private static Ingredient _leaf;
  public static Ingredient Leaf => _leaf ??= Ingredients.Find(i => i.DisplayName == "Leaf");

  private static Ingredient _mushroom;
  public static Ingredient Mushroom => _mushroom ??= Ingredients.Find(i => i.DisplayName == "Mushroom");

  private static Ingredient _onion;
  public static Ingredient Onion => _onion ??= Ingredients.Find(i => i.DisplayName == "Onion");

  private static Ingredient _tomato;
  public static Ingredient Tomato => _tomato ??= Ingredients.Find(i => i.DisplayName == "Tomato");
}
