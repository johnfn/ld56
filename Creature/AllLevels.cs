
using System.Collections.Generic;
using ld56;

public static class AllLevels {
  public static List<List<SpawnedCreature>> Levels = [
    // Day 1
    [
      new SpawnedCreature {
      Data = AllCreatures.MrPig,
      ReservationTime = Clock.GetTimeFromString("8:00 AM"),
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.For[AllCreatures.MrPig],
    },

    // new SpawnedCreature {
    //   Data = AllCreatures.MrMouse,
    //   ReservationTime = Clock.GetTimeFromString("9:00 AM"),
    //   State = CreatureState.NotSpawnedYet,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Interior,
    //   SelectedChair = null,
    //   GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
    // },

    // new SpawnedCreature {
    //   Data = AllCreatures.MrPig,
    //   ReservationTime = Clock.GetTimeFromString("10:00 AM"),
    //   State = CreatureState.NotSpawnedYet,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Interior,
    //   SelectedChair = null,
    //   GetDialog = () => NextDialog.For[AllCreatures.MrPig],
    // },

    // new SpawnedCreature {
    //   Data = AllCreatures.MrMouse,
    //   ReservationTime = Clock.GetTimeFromString("12:00 PM"),
    //   State = CreatureState.NotSpawnedYet,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Interior,
    //   SelectedChair = null,
    //     GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
    //   },
    ],

    // Day 2
    [
      new SpawnedCreature {
      Data = AllCreatures.MrPig,
      ReservationTime = Clock.GetTimeFromString("8:00 AM"),
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.For[AllCreatures.MrPig],
    },

    new SpawnedCreature {
      Data = AllCreatures.MrMouse,
      ReservationTime = Clock.GetTimeFromString("10:00 AM"),
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
    },

    new SpawnedCreature {
      Data = AllCreatures.MrPig,
      ReservationTime = Clock.GetTimeFromString("10:00 AM"),
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.For[AllCreatures.MrPig],
    },

    new SpawnedCreature {
      Data = AllCreatures.MrMouse,
      ReservationTime = Clock.GetTimeFromString("12:00 PM"),
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
        GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
      },

    new SpawnedCreature {
      Data = AllCreatures.MrMouse,
      ReservationTime = Clock.GetTimeFromString("2:00 PM"),
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
        GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
      },
    ]

  ];
}

