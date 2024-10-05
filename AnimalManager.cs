using Godot;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ld56;

using static Utils;

public enum CreatureState {
  NotSpawnedYet,
  WalkToEntrance,
  WaitToBeAdmitted,
  WalkToTable,
}

public enum CurrentScreen {
  Nowhere,
  Exterior,
  Interior,
}

public class SpawnedCreature {
  public required Creature Creature;
  public required double SpawnDelay;
  public required CreatureState State;
  public required Node2D? Instance;
  public required CurrentScreen CurrentScreen;
}

public partial class AnimalManager : Node2D {
  public List<SpawnedCreature> UpcomingCreatures = [
    new SpawnedCreature {
      Creature = AllCreatures.MrChicken,
      SpawnDelay = 0,
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Nowhere,
    },

    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      SpawnDelay = 10,
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Nowhere,
    },
  ];

  public override void _Ready() {
  }

  public void Initialize() {
    Root.Instance.ListOfCreatures.Initialize(UpcomingCreatures);
  }

  public override void _Process(double delta) {
    var entrance = Root.Instance.Nodes.Exterior.Nodes.AnimalDestinationArea;

    foreach (var animal in UpcomingCreatures) {
      switch (animal.State) {
        case CreatureState.NotSpawnedYet:
          animal.SpawnDelay -= delta;

          if (animal.SpawnDelay <= 0) {
            animal.Instance = Spawn(animal);
            animal.State = CreatureState.WalkToEntrance;
            animal.CurrentScreen = CurrentScreen.Exterior;
          }

          break;

        case CreatureState.WalkToEntrance:
          var instance = animal.Instance;

          if (instance == null) {
            continue;
          }

          var direction = (entrance.GlobalPosition - instance.GlobalPosition).Normalized();
          instance.Position += direction * 100 * (float)delta * (Root.Instance.HYPER ? 20 : 1);

          if (instance.GlobalPosition.DistanceTo(entrance.GlobalPosition) < 10) {
            animal.State = CreatureState.WaitToBeAdmitted;
          }

          break;

        case CreatureState.WaitToBeAdmitted:
          break;

        case CreatureState.WalkToTable:
          break;
      }
    }

    var listOfCreatures = Root.Instance.ListOfCreatures;

    listOfCreatures.Update(UpcomingCreatures);
  }

  public Node2D Spawn(SpawnedCreature animal) {
    var newAnimal = animal.Creature.Instantiate();

    AddChild(newAnimal);
    newAnimal.GlobalPosition = Root.Instance.Nodes.Exterior.Nodes.AnimalSpawnArea.GlobalPosition;

    return newAnimal;
  }
}
