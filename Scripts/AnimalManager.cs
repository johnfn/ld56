using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
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
  WaitForEveryoneToFinish,
  WalkToExit,
  Done,
}

public enum CurrentScreen {
  Nowhere,
  Exterior,
  Interior,
}

public class SpawnedCreature {
  public required CreatureData Data;
  public required double ReservationTime;
  public required CreatureState State;
  public required Node2D? Instance;
  public required CurrentScreen CurrentScreen;
  public required HighlightCircle? SelectedChair;
  public required Func<List<IDialogItem>> GetDialog;
}

public class Chair {
  public required HighlightCircle Circle;
  public required SpawnedCreature? SpawnedCreatureOnChair;
  public required int TableIndex;
}

public partial class AnimalManager : Node2D {
  public SpawnedCreature? CreatureCurrentlyBeingSit;
  public List<SpawnedCreature> Creatures = AllLevels.Levels[0];

  public List<Chair> Chairs = [];

  public override void _Ready() { }

  public void Initialize() {
    Root.Instance.ListOfCreatures.Initialize(Creatures);

    var tableIndex = 0;

    foreach (var table in Root.Instance.Nodes.Interior.Nodes.Tables.GetChildren()) {
      foreach (var chair in table.GetChildren()) {
        if (chair is HighlightCircle highlightCircle) {
          Chairs.Add(new Chair {
            Circle = highlightCircle,
            SpawnedCreatureOnChair = null,
            TableIndex = tableIndex,
          });

          highlightCircle.Visible = false;
        }
      }

      tableIndex++;
    }

    if (GameState.Mode == GameMode.Cooking) {
      Root.Instance.UpdateCurrentScreen(GameScreen.Cooking);
    }
  }

  public static bool AreSeatedNextToEachOther(CreatureData someCreature, CreatureData creature2) {
    var creature1Chair = Root.Instance.Nodes.AnimalManager.Chairs.Find(c => c.SpawnedCreatureOnChair?.Data == someCreature);
    var creature1TableIndex = creature1Chair?.TableIndex ?? -1;

    foreach (var chair in Root.Instance.Nodes.AnimalManager.Chairs) {
      if (chair.TableIndex == creature1TableIndex) {
        if (chair.SpawnedCreatureOnChair != null && chair.SpawnedCreatureOnChair.Data.DisplayName == creature2.DisplayName) {
          return true;
        }
      }
    }

    return false;
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
          var availableChair = Chairs.Find(c => c.SpawnedCreatureOnChair == null);
          if (availableChair == null) {
            continue;
          }

          animal.Instance.GlobalPosition = availableChair.Circle.GlobalPosition;
          availableChair.SpawnedCreatureOnChair = animal;
        }
      }

      switch (animal.State) {
        case CreatureState.NotSpawnedYet:
          if (GameState.CurrentDayTime > animal.ReservationTime) {
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
            instance.Position += direction * GameConstants.WALKING_SPEED * (float)delta;

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
              instance.Position += direction * GameConstants.WALKING_SPEED * (float)delta;

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
            instance.Position += direction * GameConstants.WALKING_SPEED * (float)delta;

            if (instance.GlobalPosition.DistanceTo(animal.SelectedChair.GlobalPosition) < 10) {
              animal.State = CreatureState.WaitForTalk;
            }

            break;
          }

        case CreatureState.WaitForEveryoneToFinish: {
            if (instance == null) {
              continue;
            }

            if (animal.SelectedChair == null) {
              continue;
            }

            var tableIndex = Chairs.Find(c => c.Circle == animal.SelectedChair)?.TableIndex ?? -1;

            if (tableIndex == -1) {
              GD.PushWarning($"No table index found for {animal.Data.DisplayName}");
              continue;
            }

            // get all chairs at this animals' table.

            var chairsAtTable = Chairs.FindAll(c => c.TableIndex == tableIndex);
            var numReadyToGo = 0;

            foreach (var candidateChair in chairsAtTable) {
              if (candidateChair.SpawnedCreatureOnChair != null) {
                if (candidateChair.SpawnedCreatureOnChair.State == CreatureState.WaitForEveryoneToFinish) {
                  numReadyToGo++;
                }
              }
            }

            if (numReadyToGo == chairsAtTable.Count) {
              foreach (var chair in chairsAtTable) {
                if (chair.SpawnedCreatureOnChair != null) {
                  chair.SpawnedCreatureOnChair.State = CreatureState.WalkToExit;

                  // give up seat

                  chair.SpawnedCreatureOnChair = null;
                }
              }
            }

            // We need this if we can't seat a full table.
            var areAllCreaturesReady = Creatures.All(c => c.State == CreatureState.WaitForEveryoneToFinish);
            if (areAllCreaturesReady) {
              animal.State = CreatureState.WalkToExit;
            }

            break;
          }

        case CreatureState.WalkToExit: {
            if (instance == null) {
              continue;
            }

            var direction = (interiorSpawn.GlobalPosition - instance.GlobalPosition).Normalized();
            instance.Position += direction * GameConstants.WALKING_SPEED * (float)delta;

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
    var newAnimal = spawnedCreature.Data.Instantiate(spawnedCreature);

    AddChild(newAnimal);
    newAnimal.GlobalPosition = Root.Instance.Nodes.Exterior.Nodes.AnimalSpawnArea.GlobalPosition;

    return newAnimal;
  }

  public void Admit(SpawnedCreature spawnedCreature) {
    spawnedCreature.State = CreatureState.WalkInside;
  }

  public void Sit(SpawnedCreature spawnedCreature) {
    foreach (var chair in Chairs) {
      if (chair.SpawnedCreatureOnChair == null) {
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

    chairToUpdate.SpawnedCreatureOnChair = CreatureCurrentlyBeingSit;

    foreach (var chair in Chairs) {
      chair.Circle.Visible = false;
    }

    CreatureCurrentlyBeingSit = null;

    GameState.Mode = GameMode.Normal;
  }

  public async void StartDialog(SpawnedCreature spawnedCreature) {
    if (GameState.Mode == GameMode.Normal) {
      GameState.Mode = GameMode.Dialog;

      await DialogBox.ShowDialog(spawnedCreature.GetDialog(), spawnedCreature.Data);
      GameState.Mode = GameMode.Normal;

      spawnedCreature.State = CreatureState.WaitForEveryoneToFinish;
    }
  }
}
