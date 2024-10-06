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

    private Label? _Name;
    public Label Name {
      get => _Name ??= parent.GetNode<Label>("Name");
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
