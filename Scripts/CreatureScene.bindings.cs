using Godot;
namespace ld56;

public partial class CreatureScene : Node2D {
  public static CreatureScene New() {
    return GD.Load<PackedScene>("res://Scenes/CreatureScene.tscn").Instantiate<CreatureScene>();
  }
  public CreatureScene() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CreatureSceneNodes {
    CreatureScene parent;

    public CreatureSceneNodes(CreatureScene parent) {
      this.parent = parent;
    }
    private Button? _HoverArea;
    public Button HoverArea {
      get => _HoverArea ??= parent.GetNode<Button>("HoverArea");
    }

    private PanelContainer? _NameContainer;
    public PanelContainer NameContainer {
      get => _NameContainer ??= parent.GetNode<PanelContainer>("NameContainer");
    }

    private MarginContainer? _NameContainer_MarginContainer;
    public MarginContainer NameContainer_MarginContainer {
      get => _NameContainer_MarginContainer ??= parent.GetNode<MarginContainer>("NameContainer/MarginContainer");
    }

    private Label? _NameContainer_MarginContainer_NameLabel;
    public Label NameContainer_MarginContainer_NameLabel {
      get => _NameContainer_MarginContainer_NameLabel ??= parent.GetNode<Label>("NameContainer/MarginContainer/NameLabel");
    }

    private HoverPanelExterior? _HoverPanelExterior;
    public HoverPanelExterior HoverPanelExterior {
      get => _HoverPanelExterior ??= parent.GetNode<HoverPanelExterior>("HoverPanelExterior");
    }

  }

  public CreatureSceneNodes? _Nodes;
  public CreatureSceneNodes Nodes {
    get {
      return _Nodes ??= new CreatureSceneNodes(this);
    }
  }
}
