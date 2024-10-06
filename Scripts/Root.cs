using Godot;
using System;
using static Utils;

namespace ld56;

public enum GameScreen {
  Exterior,
  Restaurant
}

public partial class Root : Node2D {
  public GameScreen CurrentScreen { get; private set; } = GameScreen.Restaurant;
  public static Root Instance { get; private set; }
  public ListOfCreatures ListOfCreatures {
    get => Nodes.HUD.Nodes.Container_MarginContainer_HBoxContainer_ListOfCreatures;
  }

  public float EndOfDayTime = 10f;
  public float CurrentDayTime { get; private set; } = 0f;

  public int DaysLeft = 8;

  public override void _Ready() {
    Instance = this;

    UpdateCurrentScreen(CurrentScreen);

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

    Nodes.HUD.Nodes.Newspaper_CloseButton.Pressed += () => {
      ToggleNewspaper();
    };

    StartNewDay();
  }

  public void StartNewDay() {
    Nodes.HUD.Nodes.ClosingTimeOverlay.Visible = false;

    CurrentDayTime = 0f;
    DaysLeft--;
    Nodes.HUD.Nodes.Newspaper_HBoxContainer_DaysLeft.Text = $"Days until the Dinernb Extravaganza: {DaysLeft}!";
  }

  public override void _Process(double delta) {
    if (Input.IsKeyPressed(Key.Shift)) {
      Engine.TimeScale = 20;
    } else {
      Engine.TimeScale = 1;
    }

    // Update clock
    CurrentDayTime += (float)delta / 10.0f;
    Nodes.HUD.Nodes.Clock_ClockHand.Rotation = Mathf.DegToRad(118f - (CurrentDayTime / EndOfDayTime) * (118f + 30f));

    if (CurrentDayTime >= EndOfDayTime) {
      ToggleNewspaper();
      StartNewDay(); // Reset the clock for the new day
    } else if (Mathf.RadToDeg(Nodes.HUD.Nodes.Clock_ClockHand.Rotation) < -0f) {
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

  public void UpdateCurrentScreen(
    GameScreen newScreen
  ) {
    CurrentScreen = newScreen;

    Nodes.HUD.Nodes.ExteriorButton.Visible = CurrentScreen != GameScreen.Exterior;
    Nodes.HUD.Nodes.InteriorButton.Visible = CurrentScreen != GameScreen.Restaurant;

    Sprite2D node = CurrentScreen switch {
      GameScreen.Exterior => Nodes.Exterior,
      GameScreen.Restaurant => Nodes.Interior,
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

  public void ToggleNewspaper() {
    Nodes.HUD.Nodes.Newspaper.Visible = !Nodes.HUD.Nodes.Newspaper.Visible;

    if (Nodes.HUD.Nodes.Newspaper.Visible) {
      Engine.TimeScale = 0;
    } else {
      Engine.TimeScale = 1;
    }

    Nodes.SoundManager.PlayPageTurnSFX();
  }
}
