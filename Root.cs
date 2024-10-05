using Godot;
using System;
using static Utils;

namespace ld56;

public enum GameScreen {
  Exterior,
  Restaurant,
  Rolodex,
  RecipeBook,
}

public partial class Root : Node2D {
  public GameScreen CurrentScreen { get; private set; } = GameScreen.Restaurant;
  public static Root Instance { get; private set; }

  public bool HYPER { get; private set; } = false;

  public ListOfCreatures ListOfCreatures {
    get => Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_ListOfCreatures;
  }

  public override void _Ready() {
    Instance = this;

    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToExterior.Pressed += () => {
      UpdateCurrentScreen(GameScreen.Exterior);
    };

    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRestaurant.Pressed += () => {
      UpdateCurrentScreen(GameScreen.Restaurant);
    };

    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRolodex.Pressed += () => {
      UpdateCurrentScreen(GameScreen.Rolodex);
    };

    UpdateCurrentScreen(CurrentScreen);

    Nodes.AnimalManager.Initialize();
  }

  public override void _Process(double delta) {
    HYPER = Input.IsKeyPressed(Key.Shift);
  }

  public void UpdateCurrentScreen(
    GameScreen newScreen
  ) {
    CurrentScreen = newScreen;

    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToExterior.Disabled = CurrentScreen == GameScreen.Exterior;
    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRestaurant.Disabled = CurrentScreen == GameScreen.Restaurant;
    Nodes.CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRolodex.Disabled = CurrentScreen == GameScreen.Rolodex;

    var node = CurrentScreen switch {
      GameScreen.Exterior => Nodes.Exterior,
      GameScreen.Restaurant => Nodes.Interior,
      GameScreen.Rolodex => Nodes.Rolodex,
      _ => throw new NotImplementedException(),
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
}
