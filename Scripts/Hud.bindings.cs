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

    private Label? _Gold;
    public Label Gold {
      get => _Gold ??= parent.GetNode<Label>("Gold");
    }

    private VBoxContainer? _Debug;
    public VBoxContainer Debug {
      get => _Debug ??= parent.GetNode<VBoxContainer>("Debug");
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

    private Button? _Debug_DebugAddGold;
    public Button Debug_DebugAddGold {
      get => _Debug_DebugAddGold ??= parent.GetNode<Button>("Debug/DebugAddGold");
    }

    private Panel? _PanelContainer;
    public Panel PanelContainer {
      get => _PanelContainer ??= parent.GetNode<Panel>("PanelContainer");
    }

    private RichTextLabel? _PanelContainer_GoodMorningLabel;
    public RichTextLabel PanelContainer_GoodMorningLabel {
      get => _PanelContainer_GoodMorningLabel ??= parent.GetNode<RichTextLabel>("PanelContainer/GoodMorningLabel");
    }

    private HBoxContainer? _PanelContainer_CheckHBox;
    public HBoxContainer PanelContainer_CheckHBox {
      get => _PanelContainer_CheckHBox ??= parent.GetNode<HBoxContainer>("PanelContainer/CheckHBox");
    }

    private RichTextLabel? _PanelContainer_ReservationLabel;
    public RichTextLabel PanelContainer_ReservationLabel {
      get => _PanelContainer_ReservationLabel ??= parent.GetNode<RichTextLabel>("PanelContainer/ReservationLabel");
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

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator {
      get => _PanelContainer_CheckHBox_DayIndicator ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator");
    }

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator2;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator2 {
      get => _PanelContainer_CheckHBox_DayIndicator2 ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator2");
    }

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator3;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator3 {
      get => _PanelContainer_CheckHBox_DayIndicator3 ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator3");
    }

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator4;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator4 {
      get => _PanelContainer_CheckHBox_DayIndicator4 ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator4");
    }

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator5;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator5 {
      get => _PanelContainer_CheckHBox_DayIndicator5 ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator5");
    }

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator6;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator6 {
      get => _PanelContainer_CheckHBox_DayIndicator6 ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator6");
    }

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator7;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator7 {
      get => _PanelContainer_CheckHBox_DayIndicator7 ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator7");
    }

    private DayIndicator? _PanelContainer_CheckHBox_DayIndicator8;
    public DayIndicator PanelContainer_CheckHBox_DayIndicator8 {
      get => _PanelContainer_CheckHBox_DayIndicator8 ??= parent.GetNode<DayIndicator>("PanelContainer/CheckHBox/DayIndicator8");
    }

  }

  public HudNodes? _Nodes;
  public HudNodes Nodes {
    get {
      return _Nodes ??= new HudNodes(this);
    }
  }
}
