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
    // Scene: ./Scenes/interior.tscn
    private Area2D? _InteriorAnimalSpawnArea;
    public Area2D InteriorAnimalSpawnArea {
      get => _InteriorAnimalSpawnArea ??= parent.GetNode<Area2D>("InteriorAnimalSpawnArea");
    }

    private CollisionShape2D? _InteriorAnimalSpawnArea_Shape;
    public CollisionShape2D InteriorAnimalSpawnArea_Shape {
      get => _InteriorAnimalSpawnArea_Shape ??= parent.GetNode<CollisionShape2D>("InteriorAnimalSpawnArea/Shape");
    }

    private Node2D? _Tables;
    public Node2D Tables {
      get => _Tables ??= parent.GetNode<Node2D>("Tables");
    }

    private Node2D? _Tables_Table1;
    public Node2D Tables_Table1 {
      get => _Tables_Table1 ??= parent.GetNode<Node2D>("Tables/Table1");
    }

    private Node2D? _Tables_Table2;
    public Node2D Tables_Table2 {
      get => _Tables_Table2 ??= parent.GetNode<Node2D>("Tables/Table2");
    }

    private Node2D? _Tables_Table3;
    public Node2D Tables_Table3 {
      get => _Tables_Table3 ??= parent.GetNode<Node2D>("Tables/Table3");
    }

    private Sprite2D? _TableGraphic;
    public Sprite2D TableGraphic {
      get => _TableGraphic ??= parent.GetNode<Sprite2D>("TableGraphic");
    }

    private Sprite2D? _TableGraphic2;
    public Sprite2D TableGraphic2 {
      get => _TableGraphic2 ??= parent.GetNode<Sprite2D>("TableGraphic2");
    }

    private Sprite2D? _TableGraphic3;
    public Sprite2D TableGraphic3 {
      get => _TableGraphic3 ??= parent.GetNode<Sprite2D>("TableGraphic3");
    }

    private HighlightCircle? _Tables_Table1_HighlightCircle;
    public HighlightCircle Tables_Table1_HighlightCircle {
      get => _Tables_Table1_HighlightCircle ??= parent.GetNode<HighlightCircle>("Tables/Table1/HighlightCircle");
    }

    private HighlightCircle? _Tables_Table1_HighlightCircle2;
    public HighlightCircle Tables_Table1_HighlightCircle2 {
      get => _Tables_Table1_HighlightCircle2 ??= parent.GetNode<HighlightCircle>("Tables/Table1/HighlightCircle2");
    }

    private HighlightCircle? _Tables_Table1_HighlightCircle3;
    public HighlightCircle Tables_Table1_HighlightCircle3 {
      get => _Tables_Table1_HighlightCircle3 ??= parent.GetNode<HighlightCircle>("Tables/Table1/HighlightCircle3");
    }

    private HighlightCircle? _Tables_Table1_HighlightCircle4;
    public HighlightCircle Tables_Table1_HighlightCircle4 {
      get => _Tables_Table1_HighlightCircle4 ??= parent.GetNode<HighlightCircle>("Tables/Table1/HighlightCircle4");
    }

    private HighlightCircle? _Tables_Table2_HighlightCircle;
    public HighlightCircle Tables_Table2_HighlightCircle {
      get => _Tables_Table2_HighlightCircle ??= parent.GetNode<HighlightCircle>("Tables/Table2/HighlightCircle");
    }

    private HighlightCircle? _Tables_Table2_HighlightCircle1;
    public HighlightCircle Tables_Table2_HighlightCircle1 {
      get => _Tables_Table2_HighlightCircle1 ??= parent.GetNode<HighlightCircle>("Tables/Table2/HighlightCircle1");
    }

    private HighlightCircle? _Tables_Table2_HighlightCircle2;
    public HighlightCircle Tables_Table2_HighlightCircle2 {
      get => _Tables_Table2_HighlightCircle2 ??= parent.GetNode<HighlightCircle>("Tables/Table2/HighlightCircle2");
    }

    private HighlightCircle? _Tables_Table2_HighlightCircle3;
    public HighlightCircle Tables_Table2_HighlightCircle3 {
      get => _Tables_Table2_HighlightCircle3 ??= parent.GetNode<HighlightCircle>("Tables/Table2/HighlightCircle3");
    }

    private HighlightCircle? _Tables_Table3_HighlightCircle5;
    public HighlightCircle Tables_Table3_HighlightCircle5 {
      get => _Tables_Table3_HighlightCircle5 ??= parent.GetNode<HighlightCircle>("Tables/Table3/HighlightCircle5");
    }

    private HighlightCircle? _Tables_Table3_HighlightCircle6;
    public HighlightCircle Tables_Table3_HighlightCircle6 {
      get => _Tables_Table3_HighlightCircle6 ??= parent.GetNode<HighlightCircle>("Tables/Table3/HighlightCircle6");
    }

    private HighlightCircle? _Tables_Table3_HighlightCircle7;
    public HighlightCircle Tables_Table3_HighlightCircle7 {
      get => _Tables_Table3_HighlightCircle7 ??= parent.GetNode<HighlightCircle>("Tables/Table3/HighlightCircle7");
    }

    private HighlightCircle? _Tables_Table3_HighlightCircle8;
    public HighlightCircle Tables_Table3_HighlightCircle8 {
      get => _Tables_Table3_HighlightCircle8 ??= parent.GetNode<HighlightCircle>("Tables/Table3/HighlightCircle8");
    }

  }

  public InteriorNodes? _Nodes;
  public InteriorNodes Nodes {
    get {
      return _Nodes ??= new InteriorNodes(this);
    }
  }
}
