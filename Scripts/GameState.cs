using System.Collections.Generic;
namespace ld56;

public enum GameMode {
  ReservationModal,
  Normal,
  ChooseTable,
  Dialog,
  Cooking,
  EndOfDay,
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
  CreatureData Creature,
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
  public static int Gold { get; set; } = IS_DEBUG ? 100 : 0;
  public static GameMode Mode { get; set; } = GameMode.Normal;
  public static GameScreen CurrentScreen { get; set; } = GameScreen.Exterior;
  public static List<CustomerResult> CustomerResults { get; set; } = [];
  public static float CurrentDayTime { get; set; } = 0f;

  public static List<Recipe> UnlockedRecipes = [
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
    AllRecipes.TomatoSoupInACherryTomato,
    AllRecipes.ScrambledEggs,
  ];

  public static List<CreatureData> KnownGuests = [
  ];

  public static List<IngredientData> KnownIngredients = [
    AllIngredients.CherryTomato,
    AllIngredients.Basil,
    AllIngredients.Garlic,
    AllIngredients.Onion,
    AllIngredients.Carrot,
    AllIngredients.Egg,
  ];

  public static List<IngredientData> OwnedIngredients = [
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
