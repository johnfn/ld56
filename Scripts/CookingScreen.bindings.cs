using Godot;


public partial class CookingScreen : Sprite2D {
  public static CookingScreen New() {
    return GD.Load<PackedScene>("res://Scenes/cooking_screen.tscn").Instantiate<CookingScreen>();
  }
  public CookingScreen() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CookingScreenNodes {
    CookingScreen parent;

    public CookingScreenNodes(CookingScreen parent) {
      this.parent = parent;
    }
    private Label? _Label;
    public Label Label {
      get => _Label ??= parent.GetNode<Label>("Label");
    }

    private VBoxContainer? _InventoryList;
    public VBoxContainer InventoryList {
      get => _InventoryList ??= parent.GetNode<VBoxContainer>("InventoryList");
    }

    private Label? _Label2;
    public Label Label2 {
      get => _Label2 ??= parent.GetNode<Label>("Label2");
    }

    private VBoxContainer? _CookingList;
    public VBoxContainer CookingList {
      get => _CookingList ??= parent.GetNode<VBoxContainer>("CookingList");
    }

    private CookingIngredient? _InventoryList_CookingIngredient;
    public CookingIngredient InventoryList_CookingIngredient {
      get => _InventoryList_CookingIngredient ??= parent.GetNode<CookingIngredient>("InventoryList/CookingIngredient");
    }

    private CookingIngredient? _CookingList_CookingIngredient;
    public CookingIngredient CookingList_CookingIngredient {
      get => _CookingList_CookingIngredient ??= parent.GetNode<CookingIngredient>("CookingList/CookingIngredient");
    }

  }

  public CookingScreenNodes? _Nodes;
  public CookingScreenNodes Nodes {
    get {
      return _Nodes ??= new CookingScreenNodes(this);
    }
  }
}
