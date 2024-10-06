using Godot;
namespace ld56;

public partial class Clock : TextureRect {
  public static Clock New() {
    return GD.Load<PackedScene>("res://clock.tscn").Instantiate<Clock>();
  }
  public Clock() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ClockNodes {
    Clock parent;

    public ClockNodes(Clock parent) {
      this.parent = parent;
    }
    private TextureRect? _ClockHand;
    public TextureRect ClockHand {
      get => _ClockHand ??= parent.GetNode<TextureRect>("ClockHand");
    }

    private PanelContainer? _TimeLabelContainer;
    public PanelContainer TimeLabelContainer {
      get => _TimeLabelContainer ??= parent.GetNode<PanelContainer>("TimeLabelContainer");
    }

    private MarginContainer? _TimeLabelContainer_MarginContainer;
    public MarginContainer TimeLabelContainer_MarginContainer {
      get => _TimeLabelContainer_MarginContainer ??= parent.GetNode<MarginContainer>("TimeLabelContainer/MarginContainer");
    }

    private Label? _TimeLabelContainer_MarginContainer_Label;
    public Label TimeLabelContainer_MarginContainer_Label {
      get => _TimeLabelContainer_MarginContainer_Label ??= parent.GetNode<Label>("TimeLabelContainer/MarginContainer/Label");
    }

  }

  public ClockNodes? _Nodes;
  public ClockNodes Nodes {
    get {
      return _Nodes ??= new ClockNodes(this);
    }
  }
}
