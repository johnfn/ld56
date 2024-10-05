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

    private Node2D? _Chairs;
    public Node2D Chairs {
      get => _Chairs ??= parent.GetNode<Node2D>("Chairs");
    }

    private Sprite2D? _Chairs_HighlightCircle;
    public Sprite2D Chairs_HighlightCircle {
      get => _Chairs_HighlightCircle ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle");
    }

    private Sprite2D? _Chairs_HighlightCircle2;
    public Sprite2D Chairs_HighlightCircle2 {
      get => _Chairs_HighlightCircle2 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle2");
    }

    private Sprite2D? _Chairs_HighlightCircle3;
    public Sprite2D Chairs_HighlightCircle3 {
      get => _Chairs_HighlightCircle3 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle3");
    }

    private Sprite2D? _Chairs_HighlightCircle4;
    public Sprite2D Chairs_HighlightCircle4 {
      get => _Chairs_HighlightCircle4 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle4");
    }

    private Sprite2D? _Chairs_HighlightCircle5;
    public Sprite2D Chairs_HighlightCircle5 {
      get => _Chairs_HighlightCircle5 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle5");
    }

    private Sprite2D? _Chairs_HighlightCircle6;
    public Sprite2D Chairs_HighlightCircle6 {
      get => _Chairs_HighlightCircle6 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle6");
    }

    private Sprite2D? _Chairs_HighlightCircle7;
    public Sprite2D Chairs_HighlightCircle7 {
      get => _Chairs_HighlightCircle7 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle7");
    }

    private Sprite2D? _Chairs_HighlightCircle8;
    public Sprite2D Chairs_HighlightCircle8 {
      get => _Chairs_HighlightCircle8 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle8");
    }

    private Sprite2D? _Chairs_HighlightCircle9;
    public Sprite2D Chairs_HighlightCircle9 {
      get => _Chairs_HighlightCircle9 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle9");
    }

    private Sprite2D? _Chairs_HighlightCircle10;
    public Sprite2D Chairs_HighlightCircle10 {
      get => _Chairs_HighlightCircle10 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle10");
    }

    private Sprite2D? _Chairs_HighlightCircle11;
    public Sprite2D Chairs_HighlightCircle11 {
      get => _Chairs_HighlightCircle11 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle11");
    }

    private Sprite2D? _Chairs_HighlightCircle12;
    public Sprite2D Chairs_HighlightCircle12 {
      get => _Chairs_HighlightCircle12 ??= parent.GetNode<Sprite2D>("Chairs/HighlightCircle12");
    }

  }

  public InteriorNodes? _Nodes;
  public InteriorNodes Nodes {
    get {
      return _Nodes ??= new InteriorNodes(this);
    }
  }
}
