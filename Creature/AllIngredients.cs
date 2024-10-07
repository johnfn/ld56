using System;
using Godot;
using System.IO;
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
    GD.Print(ingredientsFiles.Count);
    foreach (var file in ingredientsFiles) {
      GD.Print(file);
      var ingredient = ResourceLoader.Load<Ingredient>($"{ingredientsFolder}/{file}");
      Ingredients.Add(ingredient);
    }

    GameState.KnownIngredients.Clear();
    foreach (var ingredient in Ingredients) {
      GameState.KnownIngredients.Add(ingredient);
    }
  }
}
