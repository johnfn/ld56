using Godot;
using System;
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
    get => Nodes.HUD.Nodes.Container_MarginContainer_HBoxContainer_ListOfCreatures;
  }

  public float EndOfDayTime = 10f;
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

    Nodes.HUD.Nodes.DebugEndDay.Pressed += () => {
      EndDay();
    };

    Nodes.HUD.Nodes.Newspaper_CloseButton.Pressed += () => {
      HideNewspaper();
    };

    StartNewDay();
  }

  public void StartNewDay() {
    Nodes.HUD.Nodes.ClosingTimeOverlay.Visible = false;

    CurrentDayTime = 0f;
    DaysLeft--;
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
    CurrentDayTime += (float)delta / 10.0f;
    Nodes.HUD.Nodes.Clock.Nodes.ClockHand.Rotation = Mathf.DegToRad(118f - (CurrentDayTime / EndOfDayTime) * (118f + 30f));

    if (CurrentDayTime >= EndOfDayTime) {
      EndDay();
    } else if (Mathf.RadToDeg(Nodes.HUD.Nodes.Clock.Nodes.ClockHand.Rotation) < -0f) {
      // Closing time - tween in closing time overlay node.
      Nodes.HUD.Nodes.ClosingTimeOverlay.Modulate = new Color(1, 1, 1, 0);
      Nodes.HUD.Nodes.ClosingTimeOverlay.Visible = true;
      CreateTween().TweenProperty(
        Nodes.HUD.Nodes.ClosingTimeOverlay,
        "modulate",
        new Color(1, 1, 1, 1),
        1f
      );
    }
  }

  public void EndDay() {
    ShowNewspaper();
    StartNewDay(); // Reset the clock for the new day
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

  public void ShowNewspaper() {
    Nodes.HUD.Nodes.Newspaper.Visible = true;
    Nodes.HUD.Nodes.Newspaper_HBoxContainer_DaysLeft.Text = $"Days until the Dinernb Extravaganza: {DaysLeft}!";
    Engine.TimeScale = 0;
    Nodes.SoundManager.PlayPageTurnSFX();
  }

  public void HideNewspaper() {
    Nodes.HUD.Nodes.Newspaper.Visible = false;
    Engine.TimeScale = 1;
  }
}
