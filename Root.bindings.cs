using Godot;
namespace ld56;

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

    private Sprite2D? _Rolodex;
    public Sprite2D Rolodex {
      get => _Rolodex ??= parent.GetNode<Sprite2D>("Rolodex");
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

    private Button? _CanvasLayer_Container_MarginContainer_HBoxContainer_GoToExterior;
    public Button CanvasLayer_Container_MarginContainer_HBoxContainer_GoToExterior {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer_GoToExterior ??= parent.GetNode<Button>("CanvasLayer/Container/MarginContainer/HBoxContainer/GoToExterior");
    }

    private Button? _CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRestaurant;
    public Button CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRestaurant {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRestaurant ??= parent.GetNode<Button>("CanvasLayer/Container/MarginContainer/HBoxContainer/GoToRestaurant");
    }

    private Button? _CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRolodex;
    public Button CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRolodex {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer_GoToRolodex ??= parent.GetNode<Button>("CanvasLayer/Container/MarginContainer/HBoxContainer/GoToRolodex");
    }

    private Camera? _Camera;
    public Camera Camera {
      get => _Camera ??= parent.GetNode<Camera>("Camera");
    }

    // Can't find a script for HBoxContainer, so we use a more basic type here. 
    private HBoxContainer? _CanvasLayer_Container_MarginContainer_HBoxContainer_ListOfPeople;
    public HBoxContainer CanvasLayer_Container_MarginContainer_HBoxContainer_ListOfPeople {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer_ListOfPeople ??= parent.GetNode<HBoxContainer>("CanvasLayer/Container/MarginContainer/HBoxContainer/ListOfPeople");
    }

  }

  public RootNodes? _Nodes;
  public RootNodes Nodes {
    get {
      return _Nodes ??= new RootNodes(this);
    }
  }
}
