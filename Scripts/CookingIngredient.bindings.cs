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
    private PanelContainer? _Tooltip;
    public PanelContainer Tooltip {
      get => _Tooltip ??= parent.GetNode<PanelContainer>("Tooltip");
    }

    private HSeparator? _Tooltip_HSeparator;
    public HSeparator Tooltip_HSeparator {
      get => _Tooltip_HSeparator ??= parent.GetNode<HSeparator>("Tooltip/HSeparator");
    }

    private VBoxContainer? _Tooltip_HSeparator_VBoxContainer;
    public VBoxContainer Tooltip_HSeparator_VBoxContainer {
      get => _Tooltip_HSeparator_VBoxContainer ??= parent.GetNode<VBoxContainer>("Tooltip/HSeparator/VBoxContainer");
    }

    private RichTextLabel? _Tooltip_HSeparator_VBoxContainer_Name;
    public RichTextLabel Tooltip_HSeparator_VBoxContainer_Name {
      get => _Tooltip_HSeparator_VBoxContainer_Name ??= parent.GetNode<RichTextLabel>("Tooltip/HSeparator/VBoxContainer/Name");
    }

    private RichTextLabel? _Tooltip_HSeparator_VBoxContainer_Description;
    public RichTextLabel Tooltip_HSeparator_VBoxContainer_Description {
      get => _Tooltip_HSeparator_VBoxContainer_Description ??= parent.GetNode<RichTextLabel>("Tooltip/HSeparator/VBoxContainer/Description");
    }

    private RichTextLabel? _Tooltip_HSeparator_Price;
    public RichTextLabel Tooltip_HSeparator_Price {
      get => _Tooltip_HSeparator_Price ??= parent.GetNode<RichTextLabel>("Tooltip/HSeparator/Price");
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
