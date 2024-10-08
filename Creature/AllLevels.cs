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
        GetDialog = () => AllDialog.Hazel,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Chip,
        ReservationTime = Clock.GetTimeFromString("10:00 AM"),
        GetDialog = () => AllDialog.Chip,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Kero,
        ReservationTime = Clock.GetTimeFromString("3:00 PM"),
        GetDialog = () => AllDialog.Kero,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Rufus,
        ReservationTime = Clock.GetTimeFromString("5:00 PM"),
        GetDialog = () => AllDialog.Rufus,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },
    ],

    // Day 2
    [
      new SpawnedCreature {
        Data = AllCreatures.Bonnie,
        ReservationTime = Clock.GetTimeFromString("8:00 AM"),
        GetDialog = () => AllDialog.Bonnie,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Poe,
        ReservationTime = Clock.GetTimeFromString("10:00 AM"),
        GetDialog = () => AllDialog.Poe,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Tom,
        ReservationTime = Clock.GetTimeFromString("12:01 AM"),
        GetDialog = () => AllDialog.Tom,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Speedy,
        ReservationTime = Clock.GetTimeFromString("2:00 PM"),
        GetDialog = () => AllDialog.Speedy,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },
    ],

    // Day 3
    [
      

      new SpawnedCreature {
        Data = AllCreatures.Emily,
        ReservationTime = Clock.GetTimeFromString("8:00 AM"),
        GetDialog = () => AllDialog.Emily,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Jerry,
        ReservationTime = Clock.GetTimeFromString("10:00 PM"),
        GetDialog = () => AllDialog.Jerry,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Hazel,
        ReservationTime = Clock.GetTimeFromString("12:01 AM"),
        GetDialog = () => AllDialog.Hazel2,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },
    ],

    // Day 4
    [
      new SpawnedCreature {
        Data = AllCreatures.Pip,
        ReservationTime = Clock.GetTimeFromString("8:00 AM"),
        GetDialog = () => AllDialog.Speedy,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Emily,
        ReservationTime = Clock.GetTimeFromString("10:00 AM"),
        GetDialog = () => AllDialog.Emily2,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Jerry,
        ReservationTime = Clock.GetTimeFromString("12:01 PM"),
        GetDialog = () => AllDialog.Jerry,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },

      new SpawnedCreature {
        Data = AllCreatures.Lav,
        ReservationTime = Clock.GetTimeFromString("12:00 PM"),
        GetDialog = () => AllDialog.Lav,

        State = CreatureState.NotSpawnedYet,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
      },
    ]
  ];

}

