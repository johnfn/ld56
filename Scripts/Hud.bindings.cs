using Godot;
namespace ld56;

public partial class Hud : CanvasLayer {
  public static Hud New() {
    return GD.Load<PackedScene>("res://Scenes/HUD.tscn").Instantiate<Hud>();
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
    private Button? _RolodexButton;
    public Button RolodexButton {
      get => _RolodexButton ??= parent.GetNode<Button>("RolodexButton");
    }

    private Button? _InteriorButton;
    public Button InteriorButton {
      get => _InteriorButton ??= parent.GetNode<Button>("InteriorButton");
    }

    private ColorRect? _ClosingTimeOverlay;
    public ColorRect ClosingTimeOverlay {
      get => _ClosingTimeOverlay ??= parent.GetNode<ColorRect>("ClosingTimeOverlay");
    }

    private Label? _CustomersServed;
    public Label CustomersServed {
      get => _CustomersServed ??= parent.GetNode<Label>("CustomersServed");
    }

    private Control? _Debug;
    public Control Debug {
      get => _Debug ??= parent.GetNode<Control>("Debug");
    }

    private Button? _Debug_DebugEndDay;
    public Button Debug_DebugEndDay {
      get => _Debug_DebugEndDay ??= parent.GetNode<Button>("Debug/DebugEndDay");
    }

    private Button? _Debug_DebugServeCustomer;
    public Button Debug_DebugServeCustomer {
      get => _Debug_DebugServeCustomer ??= parent.GetNode<Button>("Debug/DebugServeCustomer");
    }

    private Button? _Debug_DebugShowShop;
    public Button Debug_DebugShowShop {
      get => _Debug_DebugShowShop ??= parent.GetNode<Button>("Debug/DebugShowShop");
    }

    private Button? _Debug_DebugShowCook;
    public Button Debug_DebugShowCook {
      get => _Debug_DebugShowCook ??= parent.GetNode<Button>("Debug/DebugShowCook");
    }

    private ListOfCreatures? _ListOfCreatures;
    public ListOfCreatures ListOfCreatures {
      get => _ListOfCreatures ??= parent.GetNode<ListOfCreatures>("ListOfCreatures");
    }

    private CoolButton? _ExteriorButton;
    public CoolButton ExteriorButton {
      get => _ExteriorButton ??= parent.GetNode<CoolButton>("ExteriorButton");
    }

    private Rolodex? _Rolodex;
    public Rolodex Rolodex {
      get => _Rolodex ??= parent.GetNode<Rolodex>("Rolodex");
    }

    private DialogBox? _DialogBox;
    public DialogBox DialogBox {
      get => _DialogBox ??= parent.GetNode<DialogBox>("DialogBox");
    }

    private Newspaper? _Newspaper;
    public Newspaper Newspaper {
      get => _Newspaper ??= parent.GetNode<Newspaper>("Newspaper");
    }

    private Shop? _Shop;
    public Shop Shop {
      get => _Shop ??= parent.GetNode<Shop>("Shop");
    }

    private Clock? _Clock;
    public Clock Clock {
      get => _Clock ??= parent.GetNode<Clock>("Clock");
    }

    private PauseMenu? _Menus;
    public PauseMenu Menus {
      get => _Menus ??= parent.GetNode<PauseMenu>("Menus");
    }

  }

  public HudNodes? _Nodes;
  public HudNodes Nodes {
    get {
      return _Nodes ??= new HudNodes(this);
    }
  }
}
