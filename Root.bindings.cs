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
    private Sprite2D? _Interior;
    public Sprite2D Interior {
      get => _Interior ??= parent.GetNode<Sprite2D>("Interior");
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

    private Exterior? _Exterior;
    public Exterior Exterior {
      get => _Exterior ??= parent.GetNode<Exterior>("Exterior");
    }

    private Rolodex? _Rolodex;
    public Rolodex Rolodex {
      get => _Rolodex ??= parent.GetNode<Rolodex>("Rolodex");
    }

    private Camera? _Camera;
    public Camera Camera {
      get => _Camera ??= parent.GetNode<Camera>("Camera");
    }

    private ListOfCreatures? _CanvasLayer_Container_MarginContainer_HBoxContainer_ListOfCreatures;
    public ListOfCreatures CanvasLayer_Container_MarginContainer_HBoxContainer_ListOfCreatures {
      get => _CanvasLayer_Container_MarginContainer_HBoxContainer_ListOfCreatures ??= parent.GetNode<ListOfCreatures>("CanvasLayer/Container/MarginContainer/HBoxContainer/ListOfCreatures");
    }

    private AnimalManager? _AnimalManager;
    public AnimalManager AnimalManager {
      get => _AnimalManager ??= parent.GetNode<AnimalManager>("AnimalManager");
    }

  }

  public RootNodes? _Nodes;
  public RootNodes Nodes {
    get {
      return _Nodes ??= new RootNodes(this);
    }
  }
}
