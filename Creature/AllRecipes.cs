using System.Collections.Generic;
using Godot;

namespace ld56;

public static class AllRecipes {
  public static List<Recipe> Recipes = new();

  internal static void LoadFromResources() {
    Recipes.Clear();

    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/BeanSoup.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/BlueberryFlapjack.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/Flapjack.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/FluffFlapjack.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/GigaSalad.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/LactoseOmelet.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/MegaSalad.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/Omelet.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/OnionSoup.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/RoyalSkillet.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/Salad.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/SaladOfTheGodsSalad.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/StrawberryFlapjack.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/SyrupyFlapjack.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/TomatoSoup.tres"));
    Recipes.Add(ResourceLoader.Load<Recipe>("res://Resources/Recipes/VeggieOmelet.tres"));

    GameState.AllRecipes.Clear();
    foreach (var recipe in Recipes) {
      GameState.AllRecipes.Add(recipe);
    }
  }

  private static Recipe? _beanSoup;
  public static Recipe BeanSoup => _beanSoup ??= Recipes.Find(r => r.DisplayName == "Bean Soup");

  private static Recipe _blueberryFlapjack;
  public static Recipe BlueberryFlapjack => _blueberryFlapjack ??= Recipes.Find(r => r.DisplayName == "Blueberry Flapjack");

  private static Recipe _flapjack;
  public static Recipe Flapjack => _flapjack ??= Recipes.Find(r => r.DisplayName == "Flapjack");

  private static Recipe _fluffFlapjack;
  public static Recipe FluffFlapjack => _fluffFlapjack ??= Recipes.Find(r => r.DisplayName == "Fluff Flapjack");

  private static Recipe _gigaSalad;
  public static Recipe GigaSalad => _gigaSalad ??= Recipes.Find(r => r.DisplayName == "Giga Salad");

  private static Recipe _lactoseOmelet;
  public static Recipe LactoseOmelet => _lactoseOmelet ??= Recipes.Find(r => r.DisplayName == "Lactose Omelet");

  private static Recipe _megaSalad;
  public static Recipe MegaSalad => _megaSalad ??= Recipes.Find(r => r.DisplayName == "Mega Salad");

  private static Recipe _omelet;
  public static Recipe Omelet => _omelet ??= Recipes.Find(r => r.DisplayName == "Omelet");

  private static Recipe _onionSoup;
  public static Recipe OnionSoup => _onionSoup ??= Recipes.Find(r => r.DisplayName == "Onion Soup");

  private static Recipe _royalSkillet;
  public static Recipe RoyalSkillet => _royalSkillet ??= Recipes.Find(r => r.DisplayName == "Royal Skillet");

  private static Recipe _salad;
  public static Recipe Salad => _salad ??= Recipes.Find(r => r.DisplayName == "Salad");

  private static Recipe _saladOfTheGodsSalad;
  public static Recipe SaladOfTheGodsSalad => _saladOfTheGodsSalad ??= Recipes.Find(r => r.DisplayName == "Salad of the Gods Salad");

  private static Recipe _strawberryFlapjack;
  public static Recipe StrawberryFlapjack => _strawberryFlapjack ??= Recipes.Find(r => r.DisplayName == "Strawberry Flapjack");

  private static Recipe _syrupyFlapjack;
  public static Recipe SyrupyFlapjack => _syrupyFlapjack ??= Recipes.Find(r => r.DisplayName == "Syrupy Flapjack");

  private static Recipe _tomatoSoup;
  public static Recipe TomatoSoup => _tomatoSoup ??= Recipes.Find(r => r.DisplayName == "Tomato Soup");

  private static Recipe _veggieOmelet;
  public static Recipe VeggieOmelet => _veggieOmelet ??= Recipes.Find(r => r.DisplayName == "Veggie Omelet");

  private static Recipe _whatTrashSoup;
  public static Recipe WhatTrashSoup => _whatTrashSoup ??= Recipes.Find(r => r.DisplayName == "What-Trash Soup");


}
