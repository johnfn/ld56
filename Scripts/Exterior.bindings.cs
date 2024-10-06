using Godot;


public partial class Exterior : Sprite2D {
  public static Exterior New() {
    return GD.Load<PackedScene>("res://Scenes/exterior.tscn").Instantiate<Exterior>();
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

    private Area2D? _AnimalWaitArea;
    public Area2D AnimalWaitArea {
      get => _AnimalWaitArea ??= parent.GetNode<Area2D>("AnimalWaitArea");
    }

    private CollisionShape2D? _AnimalWaitArea_Shape;
    public CollisionShape2D AnimalWaitArea_Shape {
      get => _AnimalWaitArea_Shape ??= parent.GetNode<CollisionShape2D>("AnimalWaitArea/Shape");
    }

    private Area2D? _AnimalAdmitArea;
    public Area2D AnimalAdmitArea {
      get => _AnimalAdmitArea ??= parent.GetNode<Area2D>("AnimalAdmitArea");
    }

    private CollisionShape2D? _AnimalAdmitArea_Shape;
    public CollisionShape2D AnimalAdmitArea_Shape {
      get => _AnimalAdmitArea_Shape ??= parent.GetNode<CollisionShape2D>("AnimalAdmitArea/Shape");
    }

  }

  public ExteriorNodes? _Nodes;
  public ExteriorNodes Nodes {
    get {
      return _Nodes ??= new ExteriorNodes(this);
    }
  }
}
