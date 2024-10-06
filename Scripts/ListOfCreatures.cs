using System.Collections.Generic;
using Godot;

namespace ld56;
using static Utils;

public class CreatureAndUiElement {
  public SpawnedCreature Creature;
  public UpcomingCreatureUi UiElement;
}

public partial class ListOfCreatures : HBoxContainer {
  List<CreatureAndUiElement> CreatureUiElements = [];

  public override void _Ready() {
  }

  public override void _Process(double delta) {
  }

  public void Initialize(List<SpawnedCreature> creatures) {
    GD.Print($"Initializing list of creatures with {creatures.Count} creatures");
    foreach (var creature in creatures) {
      var ui = UpcomingCreatureUi.New();
      ui.Initialize(creature);

      CreatureUiElements.Add(new CreatureAndUiElement {
        Creature = creature,
        UiElement = ui
      });
      AddChild(ui);
    }
  }

  public void Update(List<SpawnedCreature> creatures) {
    foreach (var creature in creatures) {
      var creatureAndUi = CreatureUiElements.Find(c => c.Creature == creature);
      creatureAndUi.UiElement.Update(creature);
    }
  }
}
