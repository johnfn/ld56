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
    private Sprite2D? _Shadow;
    public Sprite2D Shadow {
      get => _Shadow ??= parent.GetNode<Sprite2D>("Shadow");
    }

    private PanelContainer? _PanelContainer;
    public PanelContainer PanelContainer {
      get => _PanelContainer ??= parent.GetNode<PanelContainer>("PanelContainer");
    }

    private MarginContainer? _PanelContainer_MarginContainer;
    public MarginContainer PanelContainer_MarginContainer {
      get => _PanelContainer_MarginContainer ??= parent.GetNode<MarginContainer>("PanelContainer/MarginContainer");
    }

    private Label? _PanelContainer_MarginContainer_NameLabel;
    public Label PanelContainer_MarginContainer_NameLabel {
      get => _PanelContainer_MarginContainer_NameLabel ??= parent.GetNode<Label>("PanelContainer/MarginContainer/NameLabel");
    }

    private Button? _TextureRect;
    public Button TextureRect {
      get => _TextureRect ??= parent.GetNode<Button>("TextureRect");
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
