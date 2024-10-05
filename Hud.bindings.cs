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

    private VBoxContainer? _Newspaper_HBoxContainer;
    public VBoxContainer Newspaper_HBoxContainer {
      get => _Newspaper_HBoxContainer ??= parent.GetNode<VBoxContainer>("Newspaper/HBoxContainer");
    }

    private Label? _Newspaper_HBoxContainer_DaysLeft;
    public Label Newspaper_HBoxContainer_DaysLeft {
      get => _Newspaper_HBoxContainer_DaysLeft ??= parent.GetNode<Label>("Newspaper/HBoxContainer/DaysLeft");
    }

    private Label? _Newspaper_HBoxContainer_DaysLeft2;
    public Label Newspaper_HBoxContainer_DaysLeft2 {
      get => _Newspaper_HBoxContainer_DaysLeft2 ??= parent.GetNode<Label>("Newspaper/HBoxContainer/DaysLeft2");
    }

    private Button? _Newspaper_CloseButton;
    public Button Newspaper_CloseButton {
      get => _Newspaper_CloseButton ??= parent.GetNode<Button>("Newspaper/CloseButton");
    }

    private TextureRect? _Clock;
    public TextureRect Clock {
      get => _Clock ??= parent.GetNode<TextureRect>("Clock");
    }

    private TextureRect? _Clock_ClockHand;
    public TextureRect Clock_ClockHand {
      get => _Clock_ClockHand ??= parent.GetNode<TextureRect>("Clock/ClockHand");
    }

    private ColorRect? _ClosingTimeOverlay;
    public ColorRect ClosingTimeOverlay {
      get => _ClosingTimeOverlay ??= parent.GetNode<ColorRect>("ClosingTimeOverlay");
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

  }

  public HudNodes? _Nodes;
  public HudNodes Nodes {
    get {
      return _Nodes ??= new HudNodes(this);
    }
  }
}
