using Godot;
namespace ld56;

public partial class Shop : ColorRect {
  public static Shop New() {
    return GD.Load<PackedScene>("res://Scenes/shop.tscn").Instantiate<Shop>();
  }
  public Shop() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ShopNodes {
    Shop parent;

    public ShopNodes(Shop parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/shop.tscn
    private PanelContainer? _PanelContainer;
    public PanelContainer PanelContainer {
      get => _PanelContainer ??= parent.GetNode<PanelContainer>("PanelContainer");
    }

    private MarginContainer? _PanelContainer_MarginContainer;
    public MarginContainer PanelContainer_MarginContainer {
      get => _PanelContainer_MarginContainer ??= parent.GetNode<MarginContainer>("PanelContainer/MarginContainer");
    }

    private VBoxContainer? _PanelContainer_MarginContainer_VBoxContainer;
    public VBoxContainer PanelContainer_MarginContainer_VBoxContainer {
      get => _PanelContainer_MarginContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("PanelContainer/MarginContainer/VBoxContainer");
    }

    private Label? _PanelContainer_MarginContainer_VBoxContainer_Label;
    public Label PanelContainer_MarginContainer_VBoxContainer_Label {
      get => _PanelContainer_MarginContainer_VBoxContainer_Label ??= parent.GetNode<Label>("PanelContainer/MarginContainer/VBoxContainer/Label");
    }

    private HBoxContainer? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer;
    public HBoxContainer PanelContainer_MarginContainer_VBoxContainer_HBoxContainer {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer ??= parent.GetNode<HBoxContainer>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer");
    }

    private VBoxContainer? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer;
    public VBoxContainer PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer ??= parent.GetNode<VBoxContainer>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer");
    }

    private TextureRect? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer_TextureRect;
    public TextureRect PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer_TextureRect {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer_TextureRect ??= parent.GetNode<TextureRect>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer/TextureRect");
    }

    private Label? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer_Label;
    public Label PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer_Label {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer_Label ??= parent.GetNode<Label>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer/Label");
    }

    private VBoxContainer? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2;
    public VBoxContainer PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2 {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2 ??= parent.GetNode<VBoxContainer>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer2");
    }

    private Label? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_ForSaleLabel;
    public Label PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_ForSaleLabel {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_ForSaleLabel ??= parent.GetNode<Label>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer2/ForSaleLabel");
    }

    private Label? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_NoneForSale;
    public Label PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_NoneForSale {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_NoneForSale ??= parent.GetNode<Label>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer2/NoneForSale");
    }

    private Label? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_YourInventoryLabel;
    public Label PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_YourInventoryLabel {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_YourInventoryLabel ??= parent.GetNode<Label>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer2/YourInventoryLabel");
    }

    private Button? _CloseButton;
    public Button CloseButton {
      get => _CloseButton ??= parent.GetNode<Button>("CloseButton");
    }

    private InventoryList? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_ShopInventoryList;
    public InventoryList PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_ShopInventoryList {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_ShopInventoryList ??= parent.GetNode<InventoryList>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer2/ShopInventoryList");
    }

    private InventoryList? _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_InventoryList;
    public InventoryList PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_InventoryList {
      get => _PanelContainer_MarginContainer_VBoxContainer_HBoxContainer_VBoxContainer2_InventoryList ??= parent.GetNode<InventoryList>("PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/VBoxContainer2/InventoryList");
    }

  }

  public ShopNodes? _Nodes;
  public ShopNodes Nodes {
    get {
      return _Nodes ??= new ShopNodes(this);
    }
  }
}
