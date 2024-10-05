using Godot;
using System;
using static Utils;

public enum GameScreen {
  Exterior,
  Restaurant,
  Rolodex,
  RecipeBook,
}

public partial class Root : Node2D {
  public GameScreen CurrentScreen { get; private set; } = GameScreen.Restaurant;

  public override void _Ready() {
    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToExterior.Pressed += () => {
      UpdateCurrentScreen(GameScreen.Exterior);
    };

    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRestaurant.Pressed += () => {
      UpdateCurrentScreen(GameScreen.Restaurant);
    };

    UpdateCurrentScreen(CurrentScreen);
  }

  public override void _Process(double delta) {
  }

  private void UpdateCurrentScreen(
    GameScreen newScreen
  ) {
    CurrentScreen = newScreen;

    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToExterior.Disabled = CurrentScreen == GameScreen.Exterior;
    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRestaurant.Disabled = CurrentScreen == GameScreen.Restaurant;

    switch (CurrentScreen) {
      case GameScreen.Exterior:
        Nodes.Camera.Position = Nodes.Exterior.Position;
        break;
      case GameScreen.Restaurant:
        Nodes.Camera.Position = Nodes.Interior.Position;
        break;
    }

  }
}
