using Godot;
namespace ld56;

public partial class AnimalManager : Node2D {
  public static AnimalManager New() {
    return GD.Load<PackedScene>("res://Scenes/animal_manager.tscn").Instantiate<AnimalManager>();
  }
  public AnimalManager() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class AnimalManagerNodes {
    AnimalManager parent;

    public AnimalManagerNodes(AnimalManager parent) {
      this.parent = parent;
    }
  }

  public AnimalManagerNodes? _Nodes;
  public AnimalManagerNodes Nodes {
    get {
      return _Nodes ??= new AnimalManagerNodes(this);
    }
  }
}
