using Godot;
using System;
using System.Collections.Generic;
namespace ld56;

public class SpawnedCreature {
  public Creature Creature;
  public double Delay;
}

public partial class AnimalManager : Node2D {
  public List<SpawnedCreature> UpcomingAnimals = [
    new SpawnedCreature {
      Creature = AllCreatures.MrChicken,
      Delay = 0,
    },
    new SpawnedCreature {
      Creature = AllCreatures.MrsCow,
      Delay = 10,
    },
  ];

  public override void _Ready() {

  }

  public override void _Process(double delta) {
    foreach (var animal in UpcomingAnimals) {
      animal.Delay -= delta;

      if (animal.Delay <= 0) {
        SpawnNextAnimal();
      }
    }
  }

  public void SpawnNextAnimal() {
    var chicken = Chicken.New();

    AddChild(chicken);
    chicken.GlobalPosition = Root.Instance.Nodes.Exterior.Nodes.AnimalSpawnArea.GlobalPosition;
  }
}
