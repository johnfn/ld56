using Godot;


public partial class Exterior : Sprite2D {
  public static Exterior New() {
    return GD.Load<PackedScene>("res://exterior.tscn").Instantiate<Exterior>();
  }
  public Exterior() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ExteriorNodes {
    Exterior parent;

    public ExteriorNodes(Exterior parent) {
      this.parent = parent;
    }
    private Area2D? _AnimalSpawnArea;
    public Area2D AnimalSpawnArea {
      get => _AnimalSpawnArea ??= parent.GetNode<Area2D>("AnimalSpawnArea");
    }

    private CollisionShape2D? _AnimalSpawnArea_Shape;
    public CollisionShape2D AnimalSpawnArea_Shape {
      get => _AnimalSpawnArea_Shape ??= parent.GetNode<CollisionShape2D>("AnimalSpawnArea/Shape");
    }

    private Area2D? _AnimalDestinationArea;
    public Area2D AnimalDestinationArea {
      get => _AnimalDestinationArea ??= parent.GetNode<Area2D>("AnimalDestinationArea");
    }

    private CollisionShape2D? _AnimalDestinationArea_Shape;
    public CollisionShape2D AnimalDestinationArea_Shape {
      get => _AnimalDestinationArea_Shape ??= parent.GetNode<CollisionShape2D>("AnimalDestinationArea/Shape");
    }

  }

  public ExteriorNodes? _Nodes;
  public ExteriorNodes Nodes {
    get {
      return _Nodes ??= new ExteriorNodes(this);
    }
  }
}
