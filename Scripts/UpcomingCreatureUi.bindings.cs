using Godot;
namespace ld56;

public partial class UpcomingCreatureUi : TextureRect {
  public static UpcomingCreatureUi New() {
    return GD.Load<PackedScene>("res://Scenes/upcoming_creature_ui.tscn").Instantiate<UpcomingCreatureUi>();
  }
  public UpcomingCreatureUi() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class UpcomingCreatureUiNodes {
    UpcomingCreatureUi parent;

    public UpcomingCreatureUiNodes(UpcomingCreatureUi parent) {
      this.parent = parent;
    }
    private Button? _Button;
    public Button Button {
      get => _Button ??= parent.GetNode<Button>("Button");
    }

    private PanelContainer? _Popover;
    public PanelContainer Popover {
      get => _Popover ??= parent.GetNode<PanelContainer>("Popover");
    }

    private MarginContainer? _Popover_MarginContainer;
    public MarginContainer Popover_MarginContainer {
      get => _Popover_MarginContainer ??= parent.GetNode<MarginContainer>("Popover/MarginContainer");
    }

    private VBoxContainer? _Popover_MarginContainer_VBoxContainer;
    public VBoxContainer Popover_MarginContainer_VBoxContainer {
      get => _Popover_MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("Popover/MarginContainer/VBoxContainer");
    }

    private Label? _Popover_MarginContainer_VBoxContainer_Title;
    public Label Popover_MarginContainer_VBoxContainer_Title {
      get => _Popover_MarginContainer_VBoxContainer_Title ??= parent.GetNode<Label>("Popover/MarginContainer/VBoxContainer/Title");
    }

    private Label? _Popover_MarginContainer_VBoxContainer_Status;
    public Label Popover_MarginContainer_VBoxContainer_Status {
      get => _Popover_MarginContainer_VBoxContainer_Status ??= parent.GetNode<Label>("Popover/MarginContainer/VBoxContainer/Status");
    }

    private Label? _Popover_MarginContainer_VBoxContainer_Location;
    public Label Popover_MarginContainer_VBoxContainer_Location {
      get => _Popover_MarginContainer_VBoxContainer_Location ??= parent.GetNode<Label>("Popover/MarginContainer/VBoxContainer/Location");
    }

    private Label? _Popover_MarginContainer_VBoxContainer_Description;
    public Label Popover_MarginContainer_VBoxContainer_Description {
      get => _Popover_MarginContainer_VBoxContainer_Description ??= parent.GetNode<Label>("Popover/MarginContainer/VBoxContainer/Description");
    }

  }

  public UpcomingCreatureUiNodes? _Nodes;
  public UpcomingCreatureUiNodes Nodes {
    get {
      return _Nodes ??= new UpcomingCreatureUiNodes(this);
    }
  }
}
