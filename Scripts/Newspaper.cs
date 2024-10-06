using Godot;
using ld56;
using System;
using System.Linq;

public partial class Newspaper : ColorRect {
  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    Visible = false;
    Nodes.Newspaper_CloseButton.Pressed += () => {
      Root.Instance.StartNewDay();
      Visible = false;
    };

  }

  public void ShowNewspaper() {
    Visible = true;

    if (Root.Instance.DaysLeft == 0) {
      Nodes.Newspaper_VBoxContainer_DaysLeft.Text = "The Dinernb Extravaganza is tomorrow!";
    } else {
      Nodes.Newspaper_VBoxContainer_DaysLeft.Text = $"Days until the Great Dinernb Extravaganza: {Root.Instance.DaysLeft}!";
    }

    var todaysResults = GameState.CustomerResults.Where(result => result.DayIndex == GameState.DayIndex).ToList();

    foreach (var child in Nodes.Newspaper_VBoxContainer_NewspaperContentContainer.GetChildren()) {
      child.QueueFree();
    }

    foreach (var result in todaysResults) {
      var entry = NewspaperEntry.New();

      entry.Nodes.TextContainer_Name.Text = result.Creature.Name;
      entry.Nodes.TextContainer_Description.Text = result.Satisfaction switch {
        CustomerSatisfaction.Elated => "Left a $5 tip and a 5 star review!",
        CustomerSatisfaction.Impressed => "Left a $5 tip and a 5 star review!",
        CustomerSatisfaction.Happy => "Left a $5 tip and a 5 star review!",
        CustomerSatisfaction.Okay => "Left a $2 tip and a 1 star review!",
        CustomerSatisfaction.Upset => "Left a $2 tip and a 3 star review.",
        CustomerSatisfaction.Unhappy => "Left a $2 tip and a 3 star review.",
        CustomerSatisfaction.Angry => "Left a $1 tip and a 1 star review.",
        CustomerSatisfaction.Furious => "Cursed at the staff and left no tip.",
        CustomerSatisfaction.GonnaMurderYou => "Threatened to kill the staff and left no tip.",
      };

      Nodes.Newspaper_VBoxContainer_NewspaperContentContainer.AddChild(entry);
    }

    Engine.TimeScale = 0;
    Root.Instance.Nodes.SoundManager.PlayPageTurnSFX();
  }
}
