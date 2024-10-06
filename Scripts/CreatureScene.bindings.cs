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
    private Label? _NameLabel;
    public Label NameLabel {
      get => _NameLabel ??= parent.GetNode<Label>("NameLabel");
    }

    private TextureRect? _TextureRect;
    public TextureRect TextureRect {
      get => _TextureRect ??= parent.GetNode<TextureRect>("TextureRect");
    }

    private Button? _TextureRect_HoverArea;
    public Button TextureRect_HoverArea {
      get => _TextureRect_HoverArea ??= parent.GetNode<Button>("TextureRect/HoverArea");
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
