using Godot;
namespace ld56;

public partial class InventoryList : GridContainer {
  public static InventoryList New() {
    return GD.Load<PackedScene>("res://Scenes/inventory_list.tscn").Instantiate<InventoryList>();
  }
  public InventoryList() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class InventoryListNodes {
    InventoryList parent;

    public InventoryListNodes(InventoryList parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/inventory_list.tscn
    private CookingIngredient? _CookingIngredient;
    public CookingIngredient CookingIngredient {
      get => _CookingIngredient ??= parent.GetNode<CookingIngredient>("CookingIngredient");
    }

    private CookingIngredient? _CookingIngredient2;
    public CookingIngredient CookingIngredient2 {
      get => _CookingIngredient2 ??= parent.GetNode<CookingIngredient>("CookingIngredient2");
    }

    private CookingIngredient? _CookingIngredient3;
    public CookingIngredient CookingIngredient3 {
      get => _CookingIngredient3 ??= parent.GetNode<CookingIngredient>("CookingIngredient3");
    }

    private CookingIngredient? _CookingIngredient4;
    public CookingIngredient CookingIngredient4 {
      get => _CookingIngredient4 ??= parent.GetNode<CookingIngredient>("CookingIngredient4");
    }

    private CookingIngredient? _CookingIngredient5;
    public CookingIngredient CookingIngredient5 {
      get => _CookingIngredient5 ??= parent.GetNode<CookingIngredient>("CookingIngredient5");
    }

  }

  public InventoryListNodes? _Nodes;
  public InventoryListNodes Nodes {
    get {
      return _Nodes ??= new InventoryListNodes(this);
    }
  }
}
