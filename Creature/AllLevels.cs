using System.Collections.Generic;
using System.Linq;
using ld56;

public static class AllLevels {
  public static List<List<SpawnedCreature>> Levels = [
    // Day 1
    [
      CreateSpawnedCreature(CreatureId.MrPig, "8:00 AM")
    ],

    // Day 2
    [
      new SpawnedCreature {
        Data = AllCreatures.Hazel,
        ReservationTime = Clock.GetTimeFromString("8:00 AM"),
        State = CreatureState.WaitForTalk,
        Instance = null,
        CurrentScreen = CurrentScreen.Interior,
        SelectedChair = null,
        GetDialog = () => AllDialog.Hazel,
      },
    ],

    // [
    //   new SpawnedCreature {
    //   Data = AllCreatures.MrPig,
    //   ReservationTime = Clock.GetTimeFromString("8:00 AM"),
    //   State = CreatureState.NotSpawnedYet,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Interior,
    //   SelectedChair = null,
    //   GetDialog = () => NextDialog.For[AllCreatures.MrPig],
    // },

    // new SpawnedCreature {
    //   Data = AllCreatures.MrMouse,
    //   ReservationTime = Clock.GetTimeFromString("10:00 AM"),
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

    // new SpawnedCreature {
    //   Data = AllCreatures.MrMouse,
    //   ReservationTime = Clock.GetTimeFromString("2:00 PM"),
    //   State = CreatureState.NotSpawnedYet,
    //   Instance = null,
    //   CurrentScreen = CurrentScreen.Interior,
    //   SelectedChair = null,
    //     GetDialog = () => NextDialog.For[AllCreatures.MrMouse],
    //   },
    // ]

  ];

  private static SpawnedCreature CreateSpawnedCreature(CreatureId creatureId, string reservationTime, CreatureState state = CreatureState.NotSpawnedYet) {
    var creature = FindCreatureById(creatureId);
    return new SpawnedCreature {
      Data = creature,
      ReservationTime = Clock.GetTimeFromString(reservationTime),
      State = CreatureState.NotSpawnedYet,
      Instance = null,
      CurrentScreen = CurrentScreen.Interior,
      SelectedChair = null,
      GetDialog = () => NextDialog.GetDialogForCreature(creatureId),
    };
  }

  private static Creature FindCreatureById(CreatureId id) {
    return AllCreatures.Creatures.FirstOrDefault(c => c.Id == id)
      ?? throw new System.Exception($"Creature with id {id} not found");
  }
}

