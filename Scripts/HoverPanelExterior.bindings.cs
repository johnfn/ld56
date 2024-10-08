using Godot;
namespace ld56;

public partial class HoverPanelExterior : PanelContainer {
  public static HoverPanelExterior New() {
    return GD.Load<PackedScene>("res://Scenes/hover_panel_exterior.tscn").Instantiate<HoverPanelExterior>();
  }
  public HoverPanelExterior() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class HoverPanelExteriorNodes {
    HoverPanelExterior parent;

    public HoverPanelExteriorNodes(HoverPanelExterior parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/hover_panel_exterior.tscn
    private MarginContainer? _MarginContainer;
    public MarginContainer MarginContainer {
      get => _MarginContainer ??= parent.GetNode<MarginContainer>("MarginContainer");
    }

    private HBoxContainer? _MarginContainer_HBoxContainer;
    public HBoxContainer MarginContainer_HBoxContainer {
      get => _MarginContainer_HBoxContainer ??= parent.GetNode<HBoxContainer>("MarginContainer/HBoxContainer");
    }

    private TextureRect? _MarginContainer_HBoxContainer_Left;
    public TextureRect MarginContainer_HBoxContainer_Left {
      get => _MarginContainer_HBoxContainer_Left ??= parent.GetNode<TextureRect>("MarginContainer/HBoxContainer/Left");
    }

    private Label? _MarginContainer_HBoxContainer_Left_LeftLabel;
    public Label MarginContainer_HBoxContainer_Left_LeftLabel {
      get => _MarginContainer_HBoxContainer_Left_LeftLabel ??= parent.GetNode<Label>("MarginContainer/HBoxContainer/Left/LeftLabel");
    }

    private TextureRect? _MarginContainer_HBoxContainer_Right;
    public TextureRect MarginContainer_HBoxContainer_Right {
      get => _MarginContainer_HBoxContainer_Right ??= parent.GetNode<TextureRect>("MarginContainer/HBoxContainer/Right");
    }

    private Label? _MarginContainer_HBoxContainer_Right_RightLabel;
    public Label MarginContainer_HBoxContainer_Right_RightLabel {
      get => _MarginContainer_HBoxContainer_Right_RightLabel ??= parent.GetNode<Label>("MarginContainer/HBoxContainer/Right/RightLabel");
    }

  }

  public HoverPanelExteriorNodes? _Nodes;
  public HoverPanelExteriorNodes Nodes {
    get {
      return _Nodes ??= new HoverPanelExteriorNodes(this);
    }
  }
}
