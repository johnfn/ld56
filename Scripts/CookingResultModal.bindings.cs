using Godot;


public partial class CookingResultModal : Control {
  public static CookingResultModal New() {
    return GD.Load<PackedScene>("res://Scenes/cooking_result_modal.tscn").Instantiate<CookingResultModal>();
  }
  public CookingResultModal() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CookingResultModalNodes {
    CookingResultModal parent;

    public CookingResultModalNodes(CookingResultModal parent) {
      this.parent = parent;
    }
    private Button? _ClickOutside;
    public Button ClickOutside {
      get => _ClickOutside ??= parent.GetNode<Button>("ClickOutside");
    }

    private TextureRect? _Glow;
    public TextureRect Glow {
      get => _Glow ??= parent.GetNode<TextureRect>("Glow");
    }

    private TextureRect? _TextureRect;
    public TextureRect TextureRect {
      get => _TextureRect ??= parent.GetNode<TextureRect>("TextureRect");
    }

    private Label? _Label;
    public Label Label {
      get => _Label ??= parent.GetNode<Label>("Label");
    }

  }

  public CookingResultModalNodes? _Nodes;
  public CookingResultModalNodes Nodes {
    get {
      return _Nodes ??= new CookingResultModalNodes(this);
    }
  }
}
