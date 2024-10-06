using System.Collections.Generic;

namespace ld56;

public static class AllRecipes {
  public static readonly Recipe TomatoSoupInACherryTomato = new() {
    DisplayName = "Tomato Soup",
    Description = "A small tomato is hollowed out and filled with a savory tomato soup.",
    Ingredients = [
      AllIngredients.CherryTomato,
      AllIngredients.Basil,
      AllIngredients.Garlic,
      AllIngredients.Onion,
    ],
  };

  public static readonly Recipe ScrambledEggs = new() {
    DisplayName = "Scrambled Eggs",
    Description = "Eggs are scrambled and served with a side of toast.",
    Ingredients = [
      AllIngredients.Onion,
    ],
  };
}
