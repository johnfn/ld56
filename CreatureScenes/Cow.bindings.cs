using Godot;


public partial class Cow : Sprite2D {
  public static Cow New() {
    return GD.Load<PackedScene>("res://CreatureScenes/cow.tscn").Instantiate<Cow>();
  }
  public Cow() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CowNodes {
    Cow parent;

    public CowNodes(Cow parent) {
      this.parent = parent;
    }
  }

  public CowNodes? _Nodes;
  public CowNodes Nodes {
    get {
      return _Nodes ??= new CowNodes(this);
    }
  }
}
