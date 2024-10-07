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
      CreateSpawnedCreature(CreatureId.MrPig, "8:00 AM"),
      CreateSpawnedCreature(CreatureId.MrMouse, "10:00 AM"),
      CreateSpawnedCreature(CreatureId.MrPig, "10:00 AM"),
      CreateSpawnedCreature(CreatureId.MrMouse, "12:00 PM"),
      CreateSpawnedCreature(CreatureId.MrMouse, "2:00 PM"),
    ]
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

