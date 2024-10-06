using Godot;
namespace ld56;

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

    private Label? _Label2;
    public Label Label2 {
      get => _Label2 ??= parent.GetNode<Label>("Label2");
    }

    private VBoxContainer? _CookingList;
    public VBoxContainer CookingList {
      get => _CookingList ??= parent.GetNode<VBoxContainer>("CookingList");
    }

    private Button? _Button;
    public Button Button {
      get => _Button ??= parent.GetNode<Button>("Button");
    }

    private InventoryList? _InventoryList;
    public InventoryList InventoryList {
      get => _InventoryList ??= parent.GetNode<InventoryList>("InventoryList");
    }

    private CookingIngredient? _CookingList_CookingIngredient;
    public CookingIngredient CookingList_CookingIngredient {
      get => _CookingList_CookingIngredient ??= parent.GetNode<CookingIngredient>("CookingList/CookingIngredient");
    }

    private CookingResultModal? _CookingResultModal;
    public CookingResultModal CookingResultModal {
      get => _CookingResultModal ??= parent.GetNode<CookingResultModal>("CookingResultModal");
    }

  }

  public CookingScreenNodes? _Nodes;
  public CookingScreenNodes Nodes {
    get {
      return _Nodes ??= new CookingScreenNodes(this);
    }
  }
}
