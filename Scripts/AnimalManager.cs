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
  WaitForTalk,
  WalkToExit,
  Done,
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
  public required HighlightCircle? SelectedChair;
  public required List<IDialogItem> Dialog;
}

public class Chair {
  public required HighlightCircle Circle;
  public required SpawnedCreature? Creature;
}

public partial class AnimalManager : Node2D {
  public SpawnedCreature? CreatureCurrentlyBeingSit;
  public List<SpawnedCreature> Creatures = [
    // new SpawnedCreature {
    //   Creature = AllCreatures.MrChicken,
    //   SpawnDelay = 0,
    //   State = CreatureState.NotSpawnedYet,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Nowhere,
    // },

    // new SpawnedCreature {
    //   Creature = AllCreatures.MrsCow,
    //   SpawnDelay = 0,
    //   State = CreatureState.WalkToExit,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Interior,
    //   SelectedChair = null,
    //   Dialog = AllDialog.MrsCow,
    // },

    new SpawnedCreature {
      Creature = AllCreatures.MrChicken,
      SpawnDelay = 0,
      State = CreatureState.WaitForTalk,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      Dialog = AllDialog.MrChicken,
    },

    new SpawnedCreature {
      Creature = AllCreatures.MrChicken,
      SpawnDelay = 0,
      State = CreatureState.WaitForTalk,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      Dialog = AllDialog.MrChicken,
    },

    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      SpawnDelay = 0,
      State = CreatureState.WaitForTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      Dialog = AllDialog.MrsCow,
    },

    // new SpawnedCreature {
    //   Creature = AllCreatures.MrChicken,
    //   SpawnDelay = 0,
    //   State = CreatureState.WaitForTable,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Interior,
    //   SelectedChair = null,
    //   Dialog = AllDialog.MrChicken,
    // },

    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      SpawnDelay = 10,
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Nowhere,
      SelectedChair = null,
      Dialog = AllDialog.MrsCow,
    },
  ];

  public List<Chair> Chairs = [];

  public override void _Ready() {
  }

  public void Initialize() {
    Root.Instance.ListOfCreatures.Initialize(Creatures);

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

    if (GameState.Mode == GameMode.Cooking) {
      Root.Instance.UpdateCurrentScreen(GameScreen.Cooking);
    }
  }

  public override void _Process(double delta) {
    var entrance = Root.Instance.Nodes.Exterior.Nodes.AnimalWaitArea;
    var admit = Root.Instance.Nodes.Exterior.Nodes.AnimalAdmitArea;
    var interiorSpawn = Root.Instance.Nodes.Interior.Nodes.InteriorAnimalSpawnArea;

    foreach (var animal in Creatures) {
      var instance = animal.Instance;

      // hack for testing
      if (animal.Instance == null) {
        if (animal.State == CreatureState.WaitForTable) {
          animal.Instance = Spawn(animal);
          animal.Instance.GlobalPosition = interiorSpawn.GlobalPosition;
        }

        if (animal.State == CreatureState.WaitForTalk || animal.State == CreatureState.WalkToExit) {
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
            instance.Position += direction * 100 * (float)delta;

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
              instance.Position += direction * 100 * (float)delta;

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
            instance.Position += direction * 100 * (float)delta;

            if (instance.GlobalPosition.DistanceTo(animal.SelectedChair.GlobalPosition) < 10) {
              animal.State = CreatureState.WaitForTalk;
            }

            break;
          }

        case CreatureState.WalkToExit: {
            if (instance == null) {
              continue;
            }

            var direction = (interiorSpawn.GlobalPosition - instance.GlobalPosition).Normalized();
            instance.Position += direction * 100 * (float)delta;

            if (instance.GlobalPosition.DistanceTo(interiorSpawn.GlobalPosition) < 10) {
              FadeOutCreature(animal);

              animal.State = CreatureState.Done;
            }

            break;
          }

        case CreatureState.Done:
          break;
      }
    }

    var listOfCreatures = Root.Instance.ListOfCreatures;

    listOfCreatures.Update(Creatures);
  }

  public async void FadeOutCreature(SpawnedCreature creature) {
    var instance = creature.Instance;

    if (instance == null) {
      return;
    }

    for (int i = 0; i < 100; i++) {
      instance.Modulate = new Color(1, 1, 1, 1 - (i / 100f));
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
    }

    Creatures.Remove(creature);

    RemoveChild(instance);
    instance.QueueFree();
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
    GameState.Mode = GameMode.ChooseTable;
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

    GameState.Mode = GameMode.Normal;
  }

  public async void StartDialog(SpawnedCreature spawnedCreature) {
    if (GameState.Mode == GameMode.Normal) {
      GameState.Mode = GameMode.Dialog;

      await DialogBox.ShowDialog(spawnedCreature.Dialog, spawnedCreature.Creature);
      GameState.Mode = GameMode.Normal;

      spawnedCreature.State = CreatureState.WalkToExit;

      // give up seat

      var chair = Chairs.Find(c => c.Creature == spawnedCreature);

      if (chair != null) {
        chair.Creature = null;
      }
    }
  }
}
