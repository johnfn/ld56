using Godot;
namespace ld56;

public partial class MorningModal : PanelContainer {
  public static MorningModal New() {
    return GD.Load<PackedScene>("res://Scenes/morning_modal.tscn").Instantiate<MorningModal>();
  }
  public MorningModal() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class MorningModalNodes {
    MorningModal parent;

    public MorningModalNodes(MorningModal parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/morning_modal.tscn
    private MarginContainer? _MarginContainer;
    public MarginContainer MarginContainer {
      get => _MarginContainer ??= parent.GetNode<MarginContainer>("MarginContainer");
    }

    private VBoxContainer? _MarginContainer_VBoxContainer;
    public VBoxContainer MarginContainer_VBoxContainer {
      get => _MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("MarginContainer/VBoxContainer");
    }

    private RichTextLabel? _MarginContainer_VBoxContainer_GoodMorningLabel;
    public RichTextLabel MarginContainer_VBoxContainer_GoodMorningLabel {
      get => _MarginContainer_VBoxContainer_GoodMorningLabel ??= parent.GetNode<RichTextLabel>("MarginContainer/VBoxContainer/GoodMorningLabel");
    }

    private RichTextLabel? _MarginContainer_VBoxContainer_ReservationLabel;
    public RichTextLabel MarginContainer_VBoxContainer_ReservationLabel {
      get => _MarginContainer_VBoxContainer_ReservationLabel ??= parent.GetNode<RichTextLabel>("MarginContainer/VBoxContainer/ReservationLabel");
    }

    private Control? _MarginContainer_VBoxContainer_Gap;
    public Control MarginContainer_VBoxContainer_Gap {
      get => _MarginContainer_VBoxContainer_Gap ??= parent.GetNode<Control>("MarginContainer/VBoxContainer/Gap");
    }

    private GridContainer? _MarginContainer_VBoxContainer_ReservationList;
    public GridContainer MarginContainer_VBoxContainer_ReservationList {
      get => _MarginContainer_VBoxContainer_ReservationList ??= parent.GetNode<GridContainer>("MarginContainer/VBoxContainer/ReservationList");
    }

    private Control? _MarginContainer_VBoxContainer_Control;
    public Control MarginContainer_VBoxContainer_Control {
      get => _MarginContainer_VBoxContainer_Control ??= parent.GetNode<Control>("MarginContainer/VBoxContainer/Control");
    }

    private Button? _MarginContainer_VBoxContainer_DoneButton;
    public Button MarginContainer_VBoxContainer_DoneButton {
      get => _MarginContainer_VBoxContainer_DoneButton ??= parent.GetNode<Button>("MarginContainer/VBoxContainer/DoneButton");
    }

  }

  public MorningModalNodes? _Nodes;
  public MorningModalNodes Nodes {
    get {
      return _Nodes ??= new MorningModalNodes(this);
    }
  }
}
