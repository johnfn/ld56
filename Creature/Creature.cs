using System;
using Godot;

namespace ld56;

public class Creature {
  public string Name { get; set; }
  public string Description { get; set; }
  public Func<SpawnedCreature, Node2D> Instantiate { get; set; }
}
