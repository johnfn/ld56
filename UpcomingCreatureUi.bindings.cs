using Godot;
namespace ld56;

public partial class UpcomingCreatureUi : ColorRect {
  public static UpcomingCreatureUi New() {
    return GD.Load<PackedScene>("res://upcoming_creature_ui.tscn").Instantiate<UpcomingCreatureUi>();
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
    private PanelContainer? _Popover;
    public PanelContainer Popover {
      get => _Popover ??= parent.GetNode<PanelContainer>("Popover");
    }

    private Label? _Popover_Label;
    public Label Popover_Label {
      get => _Popover_Label ??= parent.GetNode<Label>("Popover/Label");
    }

  }

  public UpcomingCreatureUiNodes? _Nodes;
  public UpcomingCreatureUiNodes Nodes {
    get {
      return _Nodes ??= new UpcomingCreatureUiNodes(this);
    }
  }
}
