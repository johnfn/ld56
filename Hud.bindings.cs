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

    private Button? _ExteriorButton;
    public Button ExteriorButton {
      get => _ExteriorButton ??= parent.GetNode<Button>("ExteriorButton");
    }

    private Button? _RolodexButton;
    public Button RolodexButton {
      get => _RolodexButton ??= parent.GetNode<Button>("RolodexButton");
    }

    private Button? _InteriorButton;
    public Button InteriorButton {
      get => _InteriorButton ??= parent.GetNode<Button>("InteriorButton");
    }

    private ListOfCreatures? _Container_MarginContainer_HBoxContainer_ListOfCreatures;
    public ListOfCreatures Container_MarginContainer_HBoxContainer_ListOfCreatures {
      get => _Container_MarginContainer_HBoxContainer_ListOfCreatures ??= parent.GetNode<ListOfCreatures>("Container/MarginContainer/HBoxContainer/ListOfCreatures");
    }

    private Rolodex? _Rolodex;
    public Rolodex Rolodex {
      get => _Rolodex ??= parent.GetNode<Rolodex>("Rolodex");
    }

    private DialogBox? _DialogBox;
    public DialogBox DialogBox {
      get => _DialogBox ??= parent.GetNode<DialogBox>("DialogBox");
    }

  }

  public HudNodes? _Nodes;
  public HudNodes Nodes {
    get {
      return _Nodes ??= new HudNodes(this);
    }
  }
}
