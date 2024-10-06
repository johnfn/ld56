using System.Collections.Generic;
namespace ld56;

public enum GameMode {
  Normal,
  ChooseTable,
  Dialog,
  Cooking,
}

public enum CustomerSatisfaction {
  Elated,
  Impressed,
  Happy,
  Okay,
  Unhappy,
  Upset,
  Angry,
  Furious,
  GonnaMurderYou,
}

public record CustomerResult(
  Creature Creature,
  int TipEarned,
  CustomerSatisfaction Satisfaction,
  int DayIndex
);

// TODO: Store overall day success / failure
public static class GameState {
  public static bool HYPERSPEED = false;
  public static bool IS_DEBUG = true;

  public static int DayIndexOfExtravaganza { get; set; } = 8;
  public static int DayIndex { get; set; } = 0;
  public static int Gold { get; set; } = 0;
  public static GameMode Mode { get; set; } = GameMode.Normal;
  public static GameScreen CurrentScreen { get; set; } = GameScreen.Restaurant;
  public static List<CustomerResult> CustomerResults { get; set; } = [];

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
