namespace ld56;

public static class AllCreatures {
  public static readonly Creature MrChicken = new() {
    Name = "Mr. Chicken",
    Description = "It's the neighborhood's richest chicken. It's always wearing a fancy hat and carrying a cane.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
  };

  public static readonly Creature MrsCow = new() {
    Name = "Mrs. Cow",
    Description = "A big, friendly cow. She's always smiling and waving at people.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
  };

  public static readonly Creature MrPig = new() {
    Name = "Mr. Pig",
    Description = "A big pig. It hates chickens.",
    Instantiate = (spawnedCreature) => {
      var creature = CreatureScene.New();
      creature.Initialize(spawnedCreature);
      return creature;
    },
  };
}
