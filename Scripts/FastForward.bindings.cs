using Godot;


public partial class FastForward : TextureButton {
  public static FastForward New() {
    return GD.Load<PackedScene>("res://Scenes/fast_forward.tscn").Instantiate<FastForward>();
  }
  public FastForward() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class FastForwardNodes {
    FastForward parent;

    public FastForwardNodes(FastForward parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/fast_forward.tscn
    private PanelContainer? _RecipesTooltip;
    public PanelContainer RecipesTooltip {
      get => _RecipesTooltip ??= parent.GetNode<PanelContainer>("RecipesTooltip");
    }

    private MarginContainer? _RecipesTooltip_MarginContainer;
    public MarginContainer RecipesTooltip_MarginContainer {
      get => _RecipesTooltip_MarginContainer ??= parent.GetNode<MarginContainer>("RecipesTooltip/MarginContainer");
    }

    private Label? _RecipesTooltip_MarginContainer_Label;
    public Label RecipesTooltip_MarginContainer_Label {
      get => _RecipesTooltip_MarginContainer_Label ??= parent.GetNode<Label>("RecipesTooltip/MarginContainer/Label");
    }

  }

  public FastForwardNodes? _Nodes;
  public FastForwardNodes Nodes {
    get {
      return _Nodes ??= new FastForwardNodes(this);
    }
  }
}
