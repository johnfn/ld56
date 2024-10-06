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

    private HBoxContainer? _TimeLabelContainer_HBoxContainer;
    public HBoxContainer TimeLabelContainer_HBoxContainer {
      get => _TimeLabelContainer_HBoxContainer ??= parent.GetNode<HBoxContainer>("TimeLabelContainer/HBoxContainer");
    }

    private Label? _TimeLabelContainer_HBoxContainer_TimeLabel;
    public Label TimeLabelContainer_HBoxContainer_TimeLabel {
      get => _TimeLabelContainer_HBoxContainer_TimeLabel ??= parent.GetNode<Label>("TimeLabelContainer/HBoxContainer/TimeLabel");
    }

    private Control? _TimeLabelContainer_HBoxContainer_Spacer;
    public Control TimeLabelContainer_HBoxContainer_Spacer {
      get => _TimeLabelContainer_HBoxContainer_Spacer ??= parent.GetNode<Control>("TimeLabelContainer/HBoxContainer/Spacer");
    }

    private Label? _TimeLabelContainer_HBoxContainer_AMPMLabel;
    public Label TimeLabelContainer_HBoxContainer_AMPMLabel {
      get => _TimeLabelContainer_HBoxContainer_AMPMLabel ??= parent.GetNode<Label>("TimeLabelContainer/HBoxContainer/AMPMLabel");
    }

  }

  public ClockNodes? _Nodes;
  public ClockNodes Nodes {
    get {
      return _Nodes ??= new ClockNodes(this);
    }
  }
}
