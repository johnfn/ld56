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
    private Sprite2D? _Checkmark;
    public Sprite2D Checkmark {
      get => _Checkmark ??= parent.GetNode<Sprite2D>("Checkmark");
    }

    private VBoxContainer? _VBoxContainer;
    public VBoxContainer VBoxContainer {
      get => _VBoxContainer ??= parent.GetNode<VBoxContainer>("VBoxContainer");
    }

    private Label? _VBoxContainer_NameLabel;
    public Label VBoxContainer_NameLabel {
      get => _VBoxContainer_NameLabel ??= parent.GetNode<Label>("VBoxContainer/NameLabel");
    }

    private Button? _VBoxContainer_TextureRect;
    public Button VBoxContainer_TextureRect {
      get => _VBoxContainer_TextureRect ??= parent.GetNode<Button>("VBoxContainer/TextureRect");
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
