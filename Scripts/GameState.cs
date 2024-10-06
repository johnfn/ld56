using System.Collections.Generic;
using ld56;

public enum GameMode {
  Normal,
  ChooseTable,
  Dialog,
  Cooking,
}

// TODO: Store overall day success / failure
public static class GameState {
  public static bool HYPERSPEED = false;
  public static GameMode Mode = GameMode.Normal;
  public static GameScreen CurrentScreen { get; set; } = GameScreen.Restaurant;

  public static List<Recipe> UnlockedRecipes = [
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
  ];

  public static List<Creature> KnownGuests = [
    AllCreatures.MrChicken,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
    AllCreatures.MrPig,
  ];

  public static List<Ingredient> KnownIngredients = [
    AllIngredients.CherryTomato,
    AllIngredients.Basil,
    AllIngredients.Garlic,
    AllIngredients.Onion,
    AllIngredients.Carrot,
    AllIngredients.Egg,
  ];

  public static List<Ingredient> OwnedIngredients = [
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.CherryTomato,
    AllIngredients.Basil,
    AllIngredients.Basil,
    AllIngredients.Basil,
  ];
}
