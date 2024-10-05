using Godot;


public partial class Root : Node2D {
  public static Root New() {
    return GD.Load<PackedScene>("res://root.tscn").Instantiate<Root>();
  }
  public Root() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RootNodes {
    Root parent;

    public RootNodes(Root parent) {
      this.parent = parent;
    }
    private Sprite2D? _Exterior;
    public Sprite2D Exterior {
      get => _Exterior ??= parent.GetNode<Sprite2D>("Exterior");
    }

    private Sprite2D? _Interior;
    public Sprite2D Interior {
      get => _Interior ??= parent.GetNode<Sprite2D>("Interior");
    }

    private Camera2D? _Camera;
    public Camera2D Camera {
      get => _Camera ??= parent.GetNode<Camera2D>("Camera");
    }

    private CanvasLayer? _CanvasLayer;
    public CanvasLayer CanvasLayer {
      get => _CanvasLayer ??= parent.GetNode<CanvasLayer>("CanvasLayer");
    }

    private Control? _CanvasLayer_Container;
    public Control CanvasLayer_Container {
      get => _CanvasLayer_Container ??= parent.GetNode<Control>("CanvasLayer/Container");
    }

    private MarginContainer? _CanvasLayer_Container_MarginContainer;
    public MarginContainer CanvasLayer_Container_MarginContainer {
      get => _CanvasLayer_Container_MarginContainer ??= parent.GetNode<MarginContainer>("CanvasLayer/Container/MarginContainer");
    }

    private HBoxContainer? _CanvasLayer_Container_MarginContainer_HBoxContainer;
    public HBoxContainer CanvasLayer_Container_MarginContainer_HBoxContainer {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer ??= parent.GetNode<HBoxContainer>("CanvasLayer/Container/MarginContainer/HBoxContainer");
    }

    private Button? _CanvasLayer_Container_MarginContainer_HBoxContainer_Button;
    public Button CanvasLayer_Container_MarginContainer_HBoxContainer_Button {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer_Button ??= parent.GetNode<Button>("CanvasLayer/Container/MarginContainer/HBoxContainer/Button");
    }

    private Button? _CanvasLayer_Container_MarginContainer_HBoxContainer_Button2;
    public Button CanvasLayer_Container_MarginContainer_HBoxContainer_Button2 {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer_Button2 ??= parent.GetNode<Button>("CanvasLayer/Container/MarginContainer/HBoxContainer/Button2");
    }

  }

  public RootNodes? _Nodes;
  public RootNodes Nodes {
    get {
      return _Nodes ??= new RootNodes(this);
    }
  }
}
