using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using static Utils;

namespace ld56;

public enum GameScreen {
  Exterior,
  Restaurant,
  Cooking
}

public partial class Root : Node2D {
  public static Root Instance { get; private set; }
  public ListOfCreatures ListOfCreatures {
    get => Nodes.HUD.Nodes.ListOfCreatures;
  }

  public float EndOfDayTime = 10f;
  // This goes from 0 to 10.
  public float CurrentDayTime { get; private set; } = 0f;

  public int DaysLeft = 8;

  public override void _Ready() {
    Instance = this;

    UpdateCurrentScreen(GameState.CurrentScreen);

    Nodes.AnimalManager.Initialize();

    Nodes.HUD.Nodes.ExteriorButton.Pressed += () => {
      UpdateCurrentScreen(GameScreen.Exterior);
    };

    Nodes.HUD.Nodes.InteriorButton.Pressed += () => {
      UpdateCurrentScreen(GameScreen.Restaurant);
    };

    Nodes.HUD.Nodes.RolodexButton.Pressed += () => {
      ToggleRolodex();
    };

    Nodes.HUD.Nodes.Debug_DebugEndDay.Pressed += () => {
      EndDay();
    };

    Nodes.HUD.Nodes.Debug_DebugServeCustomer.Pressed += () => {
      GameState.CustomerResults.Add(new(
        Creature: AllCreatures.MrChicken,
        TipEarned: 10,
        Satisfaction: CustomerSatisfaction.Upset,
        DayIndex: GameState.DayIndex
      ));
    };

    Nodes.HUD.Nodes.Debug_DebugShowCook.Pressed += async () => {
      await CookingScreen.Cook();
    };

    Nodes.HUD.Nodes.Debug_DebugShowShop.Pressed += () => {
      DisplayShopHelper();
    };

    Nodes.HUD.Nodes.Debug_DebugAddGold.Pressed += () => {
      GameState.Gold += 100;
    };

    Nodes.HUD.Nodes.Shop.Nodes.CloseButton.Pressed += () => {
      HideShop();
    };

    Nodes.HUD.Nodes.Newspaper.Visible = false;
    Nodes.HUD.Nodes.Shop.Visible = false;
    Nodes.HUD.Nodes.Menus.Visible = false;

    Nodes.HUD.Nodes.Newspaper.Nodes.Newspaper_ShopButton.Pressed += () => {
      DisplayShopHelper();
    };
  }

  public void StartNewDay() {
    CurrentDayTime = 0f;
    GameState.DayIndex++;
    GameState.Mode = GameMode.Normal;
  }

  public void DisplayShopHelper() {
    // TODO: Figure out what they actually sell, lol.

    DisplayShop([
      AllIngredients.Egg,
      AllIngredients.Egg,
      AllIngredients.Egg,
    ]);
  }

  public static void DisplayShop(List<Ingredient> displayedIngredients) {
    Instance.Nodes.HUD.Nodes.Shop.Initialize(displayedIngredients);
    Instance.Nodes.HUD.Nodes.Shop.Visible = true;
  }

  public void HideShop() {
    Nodes.HUD.Nodes.Shop.Visible = false;
  }

  public override void _Process(double delta) {
    if (Input.IsKeyPressed(Key.Shift)) {
      Engine.TimeScale = 20;
    } else {
      Engine.TimeScale = 1;
    }

    if (Input.IsKeyPressed(Key.Ctrl)) {
      GameState.HYPERSPEED = true;
    } else {
      GameState.HYPERSPEED = false;
    }

    // Update clock
    if (GameState.Mode == GameMode.Normal || GameState.Mode == GameMode.ChooseTable) {
      CurrentDayTime += (float)delta / 10.0f;
    }

    if (CurrentDayTime >= EndOfDayTime) {
      EndDay();
    }
  }

  public void EndDay() {
    GameState.Mode = GameMode.EndOfDay;

    Nodes.HUD.Nodes.ClosingTimeOverlay.Modulate = new Color(1, 1, 1, 0);
    Nodes.HUD.Nodes.ClosingTimeOverlay.Visible = true;

    CreateTween().TweenProperty(
        Nodes.HUD.Nodes.ClosingTimeOverlay,
        "modulate",
        new Color(1, 1, 1, 1),
        1f
      );

    Nodes.HUD.Nodes.ClosingTimeOverlay.Visible = false;
    Nodes.HUD.Nodes.Clock.Reset();

    DaysLeft = GameState.DayIndexOfExtravaganza - GameState.DayIndex;
    Nodes.HUD.Nodes.Newspaper.ShowNewspaper();
  }

  public void UpdateCurrentScreen(
    GameScreen newScreen
  ) {
    GameState.CurrentScreen = newScreen;

    Nodes.HUD.Nodes.ExteriorButton.Visible = GameState.CurrentScreen != GameScreen.Exterior;
    Nodes.HUD.Nodes.InteriorButton.Visible = GameState.CurrentScreen != GameScreen.Restaurant;

    Sprite2D node = GameState.CurrentScreen switch {
      GameScreen.Exterior => Nodes.Exterior,
      GameScreen.Restaurant => Nodes.Interior,
      GameScreen.Cooking => Nodes.CookingScreen,
    };

    Nodes.Camera.Position = node.Position;

    Nodes.Camera.SetBounds(
      new Rect2(
        node.Position.X,
        node.Position.Y,
        node.GetRect().Size.X,
        node.GetRect().Size.Y
      )
    );
  }

  public void ToggleRolodex() {
    Nodes.HUD.Nodes.Rolodex.Visible = !Nodes.HUD.Nodes.Rolodex.Visible;
  }

  public void HideNewspaper() {
    Nodes.HUD.Nodes.Newspaper.Visible = false;
    Engine.TimeScale = 1;
  }
}
