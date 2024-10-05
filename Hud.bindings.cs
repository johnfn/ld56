using Godot;
namespace ld56;

public partial class Hud : CanvasLayer {
  public static Hud New() {
    return GD.Load<PackedScene>("res://HUD.tscn").Instantiate<Hud>();
  }
  public Hud() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class HudNodes {
    Hud parent;

    public HudNodes(Hud parent) {
      this.parent = parent;
    }
    private Control? _Container;
    public Control Container {
      get => _Container ??= parent.GetNode<Control>("Container");
    }

    private MarginContainer? _Container_MarginContainer;
    public MarginContainer Container_MarginContainer {
      get => _Container_MarginContainer ??= parent.GetNode<MarginContainer>("Container/MarginContainer");
    }

    private HBoxContainer? _Container_MarginContainer_HBoxContainer;
    public HBoxContainer Container_MarginContainer_HBoxContainer {
      get => _Container_MarginContainer_HBoxContainer ??= parent.GetNode<HBoxContainer>("Container/MarginContainer/HBoxContainer");
    }

    private Button? _Container_MarginContainer_HBoxContainer_GoToExterior;
    public Button Container_MarginContainer_HBoxContainer_GoToExterior {
      get => _Container_MarginContainer_HBoxContainer_GoToExterior ??= parent.GetNode<Button>("Container/MarginContainer/HBoxContainer/GoToExterior");
    }

    private Button? _Container_MarginContainer_HBoxContainer_GoToRestaurant;
    public Button Container_MarginContainer_HBoxContainer_GoToRestaurant {
      get => _Container_MarginContainer_HBoxContainer_GoToRestaurant ??= parent.GetNode<Button>("Container/MarginContainer/HBoxContainer/GoToRestaurant");
    }

    private Button? _Container_MarginContainer_HBoxContainer_GoToRolodex;
    public Button Container_MarginContainer_HBoxContainer_GoToRolodex {
      get => _Container_MarginContainer_HBoxContainer_GoToRolodex ??= parent.GetNode<Button>("Container/MarginContainer/HBoxContainer/GoToRolodex");
    }

    private ListOfCreatures? _Container_MarginContainer_HBoxContainer_ListOfCreatures;
    public ListOfCreatures Container_MarginContainer_HBoxContainer_ListOfCreatures {
      get => _Container_MarginContainer_HBoxContainer_ListOfCreatures ??= parent.GetNode<ListOfCreatures>("Container/MarginContainer/HBoxContainer/ListOfCreatures");
    }

  }

  public HudNodes? _Nodes;
  public HudNodes Nodes {
    get {
      return _Nodes ??= new HudNodes(this);
    }
  }
}
