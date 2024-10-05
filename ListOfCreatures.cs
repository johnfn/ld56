using System.Collections.Generic;
using Godot;

namespace ld56;
using static Utils;

public partial class ListOfCreatures : HBoxContainer {
  List<UpcomingCreatureUi> CreatureUiElements = [];

  public override void _Ready() {
  }

  public override void _Process(double delta) {
  }

  public void Initialize(List<SpawnedCreature> creatures) {
    foreach (var creature in creatures) {
      var ui = UpcomingCreatureUi.New();
      ui.Initialize(creature);

      CreatureUiElements.Add(ui);
      AddChild(ui);

      print(ui);
    }
  }

  public void Update(List<SpawnedCreature> creatures) {
  }
}
