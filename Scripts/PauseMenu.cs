using Godot;
using System;

public enum Menu {
  None,
  Main,
  Credits,
  Pause,
}

public partial class PauseMenu : ColorRect {
  public Menu CurrentMenu { get; private set; } = Menu.None;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    SetMenu(Menu.Main);


    Nodes.Background_MainMenuContent_ButtonsContainer_Play.Pressed += () => {
      SoundManager.Instance.PlayMusic(Music.Game);
      SetMenu(Menu.None);
    };

    Nodes.Background_MainMenuContent_ButtonsContainer_Credits.Pressed += () => {
      SetMenu(Menu.Credits);
      Nodes.Background_CreditsContent_MarginContainer2_BackButton.Pressed += () => {
        SetMenu(Menu.Main);
      };
    };

    Nodes.Background_MainMenuContent_ButtonsContainer_Exit.Pressed += () => {
      GetTree().Quit();
    };

    Nodes.Background_PauseMenuContent_ButtonsContainer_Resume.Pressed += () => {
      SetMenu(Menu.None);
    };

    Nodes.Background_PauseMenuContent_ButtonsContainer_MainMenu.Pressed += () => {
      SetMenu(Menu.Main);
    };

    Nodes.Background_PauseMenuContent_ButtonsContainer_Credits.Pressed += () => {
      SetMenu(Menu.Credits);
      Nodes.Background_CreditsContent_MarginContainer2_BackButton.Pressed += () => {
        SetMenu(Menu.Pause);
      };
    };
  }

  // Open the pause menu when the player presses escape.
  public override void _Input(InputEvent @event) {
    if (@event.IsActionPressed("escape")) {
      SetMenu(CurrentMenu == Menu.Pause ? Menu.None : Menu.Pause);
    }
  }

  public void SetMenu(Menu menu) {
    CurrentMenu = menu;

    Visible = menu != Menu.None;

    Nodes.Background_MainMenuContent.Visible = menu == Menu.Main;
    Nodes.Background_CreditsContent.Visible = menu == Menu.Credits;
    Nodes.Background_PauseMenuContent.Visible = menu == Menu.Pause;
  }
}
