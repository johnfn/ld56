using Godot;


public partial class Interior : Sprite2D {
  public static Interior New() {
    return GD.Load<PackedScene>("res://interior.tscn").Instantiate<Interior>();
  }
  public Interior() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class InteriorNodes {
    Interior parent;

    public InteriorNodes(Interior parent) {
      this.parent = parent;
    }
    private Area2D? _InteriorAnimalSpawnArea;
    public Area2D InteriorAnimalSpawnArea {
      get => _InteriorAnimalSpawnArea ??= parent.GetNode<Area2D>("InteriorAnimalSpawnArea");
    }

    private CollisionShape2D? _InteriorAnimalSpawnArea_Shape;
    public CollisionShape2D InteriorAnimalSpawnArea_Shape {
      get => _InteriorAnimalSpawnArea_Shape ??= parent.GetNode<CollisionShape2D>("InteriorAnimalSpawnArea/Shape");
    }

  }

  public InteriorNodes? _Nodes;
  public InteriorNodes Nodes {
    get {
      return _Nodes ??= new InteriorNodes(this);
    }
  }
}
