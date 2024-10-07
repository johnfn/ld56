using System.Collections.Generic;
using Godot;

namespace ld56;

public static class AllCreatures {
  public static List<Creature> Creatures = new();

  public static Creature GetCreature(CreatureId creatureId) {
    return Creatures.Find(creature => creature.Id == creatureId);
  }

  internal static void LoadFromResources() {
    Creatures.Clear();
    var creaturesFolder = "res://Resources/Creatures";
    var creaturesFiles = Utils.ListDirContents(creaturesFolder, "tres");
    foreach (var file in creaturesFiles) {
      var creature = ResourceLoader.Load<Creature>($"{creaturesFolder}/{file}");
      Creatures.Add(creature);
    }

    GameState.KnownGuests.Clear();
    foreach (var creature in Creatures) {
      GameState.KnownGuests.Add(creature);
    }
  }
}
