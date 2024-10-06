using Godot;


public partial class CookingIngredient : Control {
  public static CookingIngredient New() {
    return GD.Load<PackedScene>("res://Scenes/cooking_ingredient.tscn").Instantiate<CookingIngredient>();
  }
  public CookingIngredient() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CookingIngredientNodes {
    CookingIngredient parent;

    public CookingIngredientNodes(CookingIngredient parent) {
      this.parent = parent;
    }
    private PanelContainer? _BuyTooltip;
    public PanelContainer BuyTooltip {
      get => _BuyTooltip ??= parent.GetNode<PanelContainer>("BuyTooltip");
    }

    private VBoxContainer? _BuyTooltip_VBoxContainer;
    public VBoxContainer BuyTooltip_VBoxContainer {
      get => _BuyTooltip_VBoxContainer ??= parent.GetNode<VBoxContainer>("BuyTooltip/VBoxContainer");
    }

    private RichTextLabel? _BuyTooltip_VBoxContainer_Name;
    public RichTextLabel BuyTooltip_VBoxContainer_Name {
      get => _BuyTooltip_VBoxContainer_Name ??= parent.GetNode<RichTextLabel>("BuyTooltip/VBoxContainer/Name");
    }

    private RichTextLabel? _BuyTooltip_VBoxContainer_Description;
    public RichTextLabel BuyTooltip_VBoxContainer_Description {
      get => _BuyTooltip_VBoxContainer_Description ??= parent.GetNode<RichTextLabel>("BuyTooltip/VBoxContainer/Description");
    }

    private Control? _BuyTooltip_VBoxContainer_Control;
    public Control BuyTooltip_VBoxContainer_Control {
      get => _BuyTooltip_VBoxContainer_Control ??= parent.GetNode<Control>("BuyTooltip/VBoxContainer/Control");
    }

    private RichTextLabel? _BuyTooltip_VBoxContainer_Price;
    public RichTextLabel BuyTooltip_VBoxContainer_Price {
      get => _BuyTooltip_VBoxContainer_Price ??= parent.GetNode<RichTextLabel>("BuyTooltip/VBoxContainer/Price");
    }

    private PanelContainer? _Container;
    public PanelContainer Container {
      get => _Container ??= parent.GetNode<PanelContainer>("Container");
    }

    private TextureRect? _Container_IngredientImage;
    public TextureRect Container_IngredientImage {
      get => _Container_IngredientImage ??= parent.GetNode<TextureRect>("Container/IngredientImage");
    }

    private HBoxContainer? _Container_HBoxContainer2;
    public HBoxContainer Container_HBoxContainer2 {
      get => _Container_HBoxContainer2 ??= parent.GetNode<HBoxContainer>("Container/HBoxContainer2");
    }

    private RichTextLabel? _Container_NameLabel;
    public RichTextLabel Container_NameLabel {
      get => _Container_NameLabel ??= parent.GetNode<RichTextLabel>("Container/NameLabel");
    }

    private RichTextLabel? _Container_QuantityLabel;
    public RichTextLabel Container_QuantityLabel {
      get => _Container_QuantityLabel ??= parent.GetNode<RichTextLabel>("Container/QuantityLabel");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
