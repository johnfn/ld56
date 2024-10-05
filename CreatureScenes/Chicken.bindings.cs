using Godot;


public partial class Chicken : Sprite2D {
  public static Chicken New() {
    return GD.Load<PackedScene>("res://CreatureScenes/chicken.tscn").Instantiate<Chicken>();
  }
  public Chicken() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ChickenNodes {
    Chicken parent;

    public ChickenNodes(Chicken parent) {
      this.parent = parent;
    }
  }

  public ChickenNodes? _Nodes;
  public ChickenNodes Nodes {
    get {
      return _Nodes ??= new ChickenNodes(this);
    }
  }
}
