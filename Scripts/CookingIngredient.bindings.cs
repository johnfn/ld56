using Godot;


public partial class CookingIngredient : PanelContainer {
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
    private VBoxContainer? _HBoxContainer;
    public VBoxContainer HBoxContainer {
      get => _HBoxContainer ??= parent.GetNode<VBoxContainer>("HBoxContainer");
    }

    private TextureRect? _HBoxContainer_IngredientImage;
    public TextureRect HBoxContainer_IngredientImage {
      get => _HBoxContainer_IngredientImage ??= parent.GetNode<TextureRect>("HBoxContainer/IngredientImage");
    }

    private MarginContainer? _HBoxContainer_MarginContainer;
    public MarginContainer HBoxContainer_MarginContainer {
      get => _HBoxContainer_MarginContainer ??= parent.GetNode<MarginContainer>("HBoxContainer/MarginContainer");
    }

    private HBoxContainer? _HBoxContainer_MarginContainer_HBoxContainer;
    public HBoxContainer HBoxContainer_MarginContainer_HBoxContainer {
      get => _HBoxContainer_MarginContainer_HBoxContainer ??= parent.GetNode<HBoxContainer>("HBoxContainer/MarginContainer/HBoxContainer");
    }

    private RichTextLabel? _HBoxContainer_MarginContainer_HBoxContainer_NameLabel;
    public RichTextLabel HBoxContainer_MarginContainer_HBoxContainer_NameLabel {
      get => _HBoxContainer_MarginContainer_HBoxContainer_NameLabel ??= parent.GetNode<RichTextLabel>("HBoxContainer/MarginContainer/HBoxContainer/NameLabel");
    }

    private RichTextLabel? _HBoxContainer_MarginContainer_HBoxContainer_QuantityLabel;
    public RichTextLabel HBoxContainer_MarginContainer_HBoxContainer_QuantityLabel {
      get => _HBoxContainer_MarginContainer_HBoxContainer_QuantityLabel ??= parent.GetNode<RichTextLabel>("HBoxContainer/MarginContainer/HBoxContainer/QuantityLabel");
    }

  }

  public CookingIngredientNodes? _Nodes;
  public CookingIngredientNodes Nodes {
    get {
      return _Nodes ??= new CookingIngredientNodes(this);
    }
  }
}
