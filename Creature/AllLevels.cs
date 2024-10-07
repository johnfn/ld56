using System.Collections.Generic;
using System.Linq;
using ld56;

public static class AllLevels {
  public static List<List<SpawnedCreature>> Levels = [
    // Day 1
    [
      new SpawnedCreature {
        Data = AllCreatures.Hazel,
        ReservationTime = Clock.GetTimeFromString("8:00 AM"),
        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
        GetDialog = () => AllDialog.Hazel,
      }
    ],

    // Day 2
    [
      new SpawnedCreature {
        Data = AllCreatures.Hazel,
        ReservationTime = Clock.GetTimeFromString("10:00 AM"),
        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
        GetDialog = () => AllDialog.Hazel,
      }
    ],
  ];

}

