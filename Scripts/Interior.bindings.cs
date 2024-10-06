using Godot;
namespace ld56;

public partial class Interior : Sprite2D {
  public static Interior New() {
    return GD.Load<PackedScene>("res://Scenes/interior.tscn").Instantiate<Interior>();
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

    private Node2D? _Chairs;
    public Node2D Chairs {
      get => _Chairs ??= parent.GetNode<Node2D>("Chairs");
    }

    private HighlightCircle? _Chairs_HighlightCircle;
    public HighlightCircle Chairs_HighlightCircle {
      get => _Chairs_HighlightCircle ??= parent.GetNode<HighlightCircle>("Chairs/HighlightCircle");
    }

    private HighlightCircle? _Chairs_HighlightCircle2;
    public HighlightCircle Chairs_HighlightCircle2 {
      get => _Chairs_HighlightCircle2 ??= parent.GetNode<HighlightCircle>("Chairs/HighlightCircle2");
    }

    private HighlightCircle? _Chairs_HighlightCircle3;
    public HighlightCircle Chairs_HighlightCircle3 {
      get => _Chairs_HighlightCircle3 ??= parent.GetNode<HighlightCircle>("Chairs/HighlightCircle3");
    }

    private HighlightCircle? _Chairs_HighlightCircle4;
    public HighlightCircle Chairs_HighlightCircle4 {
      get => _Chairs_HighlightCircle4 ??= parent.GetNode<HighlightCircle>("Chairs/HighlightCircle4");
    }

  }

  public InteriorNodes? _Nodes;
  public InteriorNodes Nodes {
    get {
      return _Nodes ??= new InteriorNodes(this);
    }
  }
}
