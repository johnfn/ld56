using System.Collections.Generic;
using Godot;

namespace ld56;
using static Utils;

public class CreatureAndUiElement {
  public SpawnedCreature Creature;
  public UpcomingCreatureUi UiElement;
}

public partial class ListOfCreatures : PanelContainer {
  List<CreatureAndUiElement> CreatureUiElements = [];

  public override void _Ready() {
  }

  public override void _Process(double delta) {
    if (GameState.Mode == GameMode.Cooking) {
      Visible = false;
    } else {
      Visible = true;
    }
  }

  public void Initialize(List<SpawnedCreature> creatures) {
    foreach (var child in Nodes.MarginContainer_VBoxContainer_CreatureList.GetChildren()) {
      child.QueueFree();
    }

    foreach (var creature in creatures) {
      var ui = UpcomingCreatureUi.New();
      ui.Initialize(creature);

      CreatureUiElements.Add(new CreatureAndUiElement {
        Creature = creature,
        UiElement = ui
      });

      Nodes.MarginContainer_VBoxContainer_CreatureList.AddChild(ui);
    }
  }

  public void Update(List<SpawnedCreature> creatures) {
    foreach (var creature in creatures) {
      var creatureAndUi = CreatureUiElements.Find(c => c.Creature == creature);

      if (creatureAndUi == null) {
        continue;
      }

      creatureAndUi.UiElement.Update(creature);
    }
  }
}
