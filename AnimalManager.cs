using Godot;
using System.Collections.Generic;
namespace ld56;

using static Utils;

public enum CreatureState {
  NotSpawnedYet,
  WalkToEntrance,
  WaitToBeAdmitted,
  WalkInside,
  WaitForTable,
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
    var entrance = Root.Instance.Nodes.Exterior.Nodes.AnimalWaitArea;
    var admit = Root.Instance.Nodes.Exterior.Nodes.AnimalAdmitArea;

    foreach (var animal in UpcomingCreatures) {
      var instance = animal.Instance;

      switch (animal.State) {
        case CreatureState.NotSpawnedYet:
          animal.SpawnDelay -= delta;

          if (animal.SpawnDelay <= 0) {
            animal.Instance = Spawn(animal);
            animal.State = CreatureState.WalkToEntrance;
            animal.CurrentScreen = CurrentScreen.Exterior;
          }

          break;

        case CreatureState.WalkToEntrance: {
            if (instance == null) {
              continue;
            }

            var direction = (entrance.GlobalPosition - instance.GlobalPosition).Normalized();
            instance.Position += direction * 100 * (float)delta * (Root.Instance.HYPER ? 20 : 1);

            if (instance.GlobalPosition.DistanceTo(entrance.GlobalPosition) < 10) {
              animal.State = CreatureState.WaitToBeAdmitted;
            }

            break;
          }

        case CreatureState.WaitToBeAdmitted:
          if (instance == null) {
            continue;
          }

          break;

        case CreatureState.WalkInside: {
            if (instance == null) {
              continue;
            }

            if (animal.CurrentScreen == CurrentScreen.Exterior) {
              var direction = (admit.GlobalPosition - instance.GlobalPosition).Normalized();
              instance.Position += direction * 100 * (float)delta * (Root.Instance.HYPER ? 20 : 1);

              if (instance.GlobalPosition.DistanceTo(admit.GlobalPosition) < 10) {
                animal.CurrentScreen = CurrentScreen.Interior;
                instance.GlobalPosition = Root.Instance.Nodes.Interior.Nodes.InteriorAnimalSpawnArea.GlobalPosition;
                animal.State = CreatureState.WaitForTable;
              }
            }

            break;
          }

        case CreatureState.WaitForTable:
          if (instance == null) {
            continue;
          }

          break;
      }
    }

    var listOfCreatures = Root.Instance.ListOfCreatures;

    listOfCreatures.Update(UpcomingCreatures);
  }

  public Node2D Spawn(SpawnedCreature spawnedCreature) {
    var newAnimal = spawnedCreature.Creature.Instantiate(spawnedCreature);

    AddChild(newAnimal);
    newAnimal.GlobalPosition = Root.Instance.Nodes.Exterior.Nodes.AnimalSpawnArea.GlobalPosition;

    return newAnimal;
  }

  public void Admit(SpawnedCreature spawnedCreature) {
    spawnedCreature.State = CreatureState.WalkInside;
  }

  public void Sit(SpawnedCreature spawnedCreature) {
    // TODO
    print("SIT TIME");
  }
}
