
using System.Collections.Generic;
using ld56;

public static class AllLevels {
  public static List<List<SpawnedCreature>> Levels = [
    [
      new SpawnedCreature {
      Data = AllCreatures.MrPig,
      SpawnDelay = 0,
      State = CreatureState.WaitForTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.For[AllCreatures.MrPig],
    },

    new SpawnedCreature {
      Data = AllCreatures.MrMouse,
      SpawnDelay = 0,
      State = CreatureState.WaitForTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
    },

    new SpawnedCreature {
      Data = AllCreatures.MrPig,
      SpawnDelay = 0,
      State = CreatureState.WaitForTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.For[AllCreatures.MrPig],
    },

    new SpawnedCreature {
      Data = AllCreatures.MrMouse,
      SpawnDelay = 0,
      State = CreatureState.WaitForTable,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
        GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
      },
    ]
  ];
}

