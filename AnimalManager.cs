using Godot;
using System;
using System.Collections.Generic;
namespace ld56;

using static Utils;

public enum CreatureState {
  NotSpawnedYet,
  WalkToEntrance,
  WaitToBeAdmitted,
  WalkToTable,
}

public class SpawnedCreature {
  public Creature Creature;
  public double SpawnDelay;
  public CreatureState State;
  public Node2D? Instance;
}

public partial class AnimalManager : Node2D {
  public List<SpawnedCreature> UpcomingAnimals = [
    new SpawnedCreature {
      Creature = AllCreatures.MrChicken,
      SpawnDelay = 0,
      State = CreatureState.NotSpawnedYet,
      Instance = null,
    },
    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      SpawnDelay = 10,
      State = CreatureState.NotSpawnedYet,
      Instance = null,
    },
  ];

  public override void _Ready() {

  }

  public override void _Process(double delta) {
    var entrance = Root.Instance.Nodes.Exterior.Nodes.AnimalDestinationArea;

    foreach (var animal in UpcomingAnimals) {
      switch (animal.State) {
        case CreatureState.NotSpawnedYet:
          animal.SpawnDelay -= delta;

          if (animal.SpawnDelay <= 0) {
            animal.Instance = Spawn(animal);
            animal.State = CreatureState.WalkToEntrance;
          }

          break;
        case CreatureState.WalkToEntrance:
          var instance = animal.Instance;
          if (instance == null) {
            continue;
          }

          var direction = (entrance.GlobalPosition - instance.GlobalPosition).Normalized();
          instance.Position += direction * 100 * (float)delta;

          break;
        case CreatureState.WaitToBeAdmitted:
          break;
        case CreatureState.WalkToTable:
          break;
      }
    }
  }

  public Node2D Spawn(SpawnedCreature animal) {
    var newAnimal = animal.Creature.Instantiate();

    AddChild(newAnimal);
    newAnimal.GlobalPosition = Root.Instance.Nodes.Exterior.Nodes.AnimalSpawnArea.GlobalPosition;

    return newAnimal;
  }
}
