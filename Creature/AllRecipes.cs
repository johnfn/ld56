using System.Collections.Generic;
using Godot;

namespace ld56;

public static class AllRecipes {
  public static List<Recipe> Recipes = new();

  internal static void LoadFromResources() {
    Recipes.Clear();
    GD.Print("Loading recipes from resources");
    var recipesFolder = "res://Resources/Recipes";
    var recipesFiles = Utils.ListDirContents(recipesFolder, "tres");
    GD.Print(recipesFiles.Count);
    foreach (var file in recipesFiles) {
      GD.Print(file);
      var recipe = ResourceLoader.Load<Recipe>($"{recipesFolder}/{file}");
      Recipes.Add(recipe);
    }
  }
}
