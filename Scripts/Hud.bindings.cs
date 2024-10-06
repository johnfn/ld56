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

    private Button? _RolodexButton;
    public Button RolodexButton {
      get => _RolodexButton ??= parent.GetNode<Button>("RolodexButton");
    }

    private Button? _InteriorButton;
    public Button InteriorButton {
      get => _InteriorButton ??= parent.GetNode<Button>("InteriorButton");
    }

    private ColorRect? _Newspaper;
    public ColorRect Newspaper {
      get => _Newspaper ??= parent.GetNode<ColorRect>("Newspaper");
    }

    private TextureRect? _Newspaper_Newspaper;
    public TextureRect Newspaper_Newspaper {
      get => _Newspaper_Newspaper ??= parent.GetNode<TextureRect>("Newspaper/Newspaper");
    }

    private Label? _Newspaper_DaysLeft;
    public Label Newspaper_DaysLeft {
      get => _Newspaper_DaysLeft ??= parent.GetNode<Label>("Newspaper/DaysLeft");
    }

    private VBoxContainer? _Newspaper_NewspaperContentContainer;
    public VBoxContainer Newspaper_NewspaperContentContainer {
      get => _Newspaper_NewspaperContentContainer ??= parent.GetNode<VBoxContainer>("Newspaper/NewspaperContentContainer");
    }

    private Button? _Newspaper_CloseButton;
    public Button Newspaper_CloseButton {
      get => _Newspaper_CloseButton ??= parent.GetNode<Button>("Newspaper/CloseButton");
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

    private ListOfCreatures? _Container_MarginContainer_HBoxContainer_ListOfCreatures;
    public ListOfCreatures Container_MarginContainer_HBoxContainer_ListOfCreatures {
      get => _Container_MarginContainer_HBoxContainer_ListOfCreatures ??= parent.GetNode<ListOfCreatures>("Container/MarginContainer/HBoxContainer/ListOfCreatures");
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

    private NewspaperEntry? _Newspaper_NewspaperContentContainer_NewspaperEntry;
    public NewspaperEntry Newspaper_NewspaperContentContainer_NewspaperEntry {
      get => _Newspaper_NewspaperContentContainer_NewspaperEntry ??= parent.GetNode<NewspaperEntry>("Newspaper/NewspaperContentContainer/NewspaperEntry");
    }

    private Clock? _Clock;
    public Clock Clock {
      get => _Clock ??= parent.GetNode<Clock>("Clock");
    }

  }

  public HudNodes? _Nodes;
  public HudNodes Nodes {
    get {
      return _Nodes ??= new HudNodes(this);
    }
  }
}
