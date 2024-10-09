using Godot;
namespace ld56;

public partial class ClickOnAChairLabel : PanelContainer {
  public static ClickOnAChairLabel New() {
    return GD.Load<PackedScene>("res://click_on_a_chair_label.tscn").Instantiate<ClickOnAChairLabel>();
  }
  public ClickOnAChairLabel() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ClickOnAChairLabelNodes {
    ClickOnAChairLabel parent;

    public ClickOnAChairLabelNodes(ClickOnAChairLabel parent) {
      this.parent = parent;
    }
    private MarginContainer? _MarginContainer;
    public MarginContainer MarginContainer {
      get => _MarginContainer ??= parent.GetNode<MarginContainer>("MarginContainer");
    }

    private Label? _MarginContainer_ClickOnAChairLabel;
    public Label MarginContainer_ClickOnAChairLabel {
      get => _MarginContainer_ClickOnAChairLabel ??= parent.GetNode<Label>("MarginContainer/ClickOnAChairLabel");
    }

  }

  public ClickOnAChairLabelNodes? _Nodes;
  public ClickOnAChairLabelNodes Nodes {
    get {
      return _Nodes ??= new ClickOnAChairLabelNodes(this);
    }
  }
}
