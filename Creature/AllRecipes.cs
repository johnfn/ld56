using System.Collections.Generic;
using Godot;

namespace ld56;

public static class AllRecipes {
  public static List<Recipe> Recipes = new();

  internal static void LoadFromResources() {
    Recipes.Clear();
    var recipesFolder = "res://Resources/Recipes";
    var recipesFiles = Utils.ListDirContents(recipesFolder, "tres");
    foreach (var file in recipesFiles) {
      var recipe = ResourceLoader.Load<Recipe>($"{recipesFolder}/{file}");
      Recipes.Add(recipe);
    }

    GameState.UnlockedRecipes.Clear();
    foreach (var recipe in Recipes) {
      GameState.UnlockedRecipes.Add(recipe);
    }
  }
}
