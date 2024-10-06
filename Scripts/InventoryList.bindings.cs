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
    private CookingIngredient? _CookingIngredient;
    public CookingIngredient CookingIngredient {
      get => _CookingIngredient ??= parent.GetNode<CookingIngredient>("CookingIngredient");
    }

    private CookingIngredient? _CookingIngredient2;
    public CookingIngredient CookingIngredient2 {
      get => _CookingIngredient2 ??= parent.GetNode<CookingIngredient>("CookingIngredient2");
    }

  }

  public InventoryListNodes? _Nodes;
  public InventoryListNodes Nodes {
    get {
      return _Nodes ??= new InventoryListNodes(this);
    }
  }
}
