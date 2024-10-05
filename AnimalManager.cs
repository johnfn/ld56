using Godot;
using System.Collections.Generic;
namespace ld56;

using static Utils;

/**
 * creature state machine
 */
public enum CreatureState {
  NotSpawnedYet,
  WalkToEntrance,
  WaitToBeAdmitted,
  WalkInside,
  WaitForTable,
  WalkToTable,
  SittingAtTable,
}

public enum CurrentScreen {
  Nowhere,
  Exterior,
  Interior,
}

public enum GameMode {
  Normal,
  ChooseTable,
  Dialog,
}

public class SpawnedCreature {
  public required Creature Creature;
  public required double SpawnDelay;
  public required CreatureState State;
  public required Node2D? Instance;
  public required CurrentScreen CurrentScreen;
  public required HighlightCircle? SelectedChair;
  public required Dialog Dialog;
}

public class Chair {
  public required HighlightCircle Circle;
  public required SpawnedCreature? Creature;
}

public partial class AnimalManager : Node2D {
  public GameMode Mode = GameMode.Normal;
  public SpawnedCreature? CreatureCurrentlyBeingSit;
  public List<SpawnedCreature> UpcomingCreatures = [
    // new SpawnedCreature {
    //   Creature = AllCreatures.MrChicken,
    //   SpawnDelay = 0,
    //   State = CreatureState.NotSpawnedYet,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Nowhere,
    // },

    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      SpawnDelay = 0,
      State = CreatureState.SittingAtTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      Dialog = Dialogs.MrsCow,
    },

    new SpawnedCreature {
      Creature = AllCreatures.MrChicken,
      SpawnDelay = 0,
      State = CreatureState.SittingAtTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      Dialog = Dialogs.MrChicken,
    },

    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      SpawnDelay = 0,
      State = CreatureState.WaitForTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      Dialog = Dialogs.MrsCow,
    },

    new SpawnedCreature {
      Creature = AllCreatures.MrChicken,
      SpawnDelay = 0,
      State = CreatureState.WaitForTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      Dialog = Dialogs.MrChicken,
    },

    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      SpawnDelay = 10,
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Nowhere,
      SelectedChair = null,
      Dialog = Dialogs.MrsCow,
    },
  ];

  public List<Chair> Chairs = [];

  public override void _Ready() {
  }

  public void Initialize() {
    Root.Instance.ListOfCreatures.Initialize(UpcomingCreatures);

    // Initialize chairs
    foreach (var chair in Root.Instance.Nodes.Interior.Nodes.Chairs.GetChildren()) {
      if (chair is HighlightCircle highlightCircle) {
        Chairs.Add(new Chair {
          Circle = highlightCircle,
          Creature = null,
        });

        highlightCircle.Visible = false;
      }
    }
  }

  public override void _Process(double delta) {
    var entrance = Root.Instance.Nodes.Exterior.Nodes.AnimalWaitArea;
    var admit = Root.Instance.Nodes.Exterior.Nodes.AnimalAdmitArea;

    foreach (var animal in UpcomingCreatures) {
      var instance = animal.Instance;

      // hack for testing
      if (animal.Instance == null) {
        if (animal.State == CreatureState.WaitForTable) {
          animal.Instance = Spawn(animal);
          animal.Instance.GlobalPosition = Root.Instance.Nodes.Interior.Nodes.InteriorAnimalSpawnArea.GlobalPosition;
        }

        if (animal.State == CreatureState.SittingAtTable) {
          animal.Instance = Spawn(animal);

          // find an available chair
          var availableChair = Chairs.Find(c => c.Creature == null);
          if (availableChair == null) {
            continue;
          }

          animal.Instance.GlobalPosition = availableChair.Circle.GlobalPosition;
          availableChair.Creature = animal;
        }
      }

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

        case CreatureState.WalkToTable: {
            if (instance == null) {
              continue;
            }

            if (animal.SelectedChair == null) {
              continue;
            }

            var direction = (animal.SelectedChair.GlobalPosition - instance.GlobalPosition).Normalized();
            instance.Position += direction * 100 * (float)delta * (Root.Instance.HYPER ? 20 : 1);

            if (instance.GlobalPosition.DistanceTo(animal.SelectedChair.GlobalPosition) < 10) {
              animal.State = CreatureState.SittingAtTable;
            }

            break;
          }
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
    foreach (var chair in Chairs) {
      if (chair.Creature == null) {
        chair.Circle.Visible = true;
      }
    }

    CreatureCurrentlyBeingSit = spawnedCreature;
    Mode = GameMode.ChooseTable;
  }

  public void SelectChair(HighlightCircle circle) {
    if (CreatureCurrentlyBeingSit == null) {
      return;
    }

    if (CreatureCurrentlyBeingSit.Instance == null) {
      return;
    }

    CreatureCurrentlyBeingSit.SelectedChair = circle;
    CreatureCurrentlyBeingSit.State = CreatureState.WalkToTable;

    var chairToUpdate = Chairs.Find(c => c.Circle == circle);
    if (chairToUpdate == null) {
      return;
    }

    chairToUpdate.Creature = CreatureCurrentlyBeingSit;

    foreach (var chair in Chairs) {
      chair.Circle.Visible = false;
    }

    CreatureCurrentlyBeingSit = null;

    Mode = GameMode.Normal;
  }
}
